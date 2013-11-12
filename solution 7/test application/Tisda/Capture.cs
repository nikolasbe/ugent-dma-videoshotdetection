/****************************************************************************
While the underlying libraries are covered by LGPL, this sample is released 
as public domain.  It is distributed in the hope that it will be useful, but 
WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY 
or FITNESS FOR A PARTICULAR PURPOSE.  
*****************************************************************************/

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;
using System.IO;

using DirectShowLib;

namespace Tisda
{
    /// <summary> Summary description for MainForm. </summary>
    internal class Capture : ISampleGrabberCB, IDisposable
    {
        #region Member variables

        /// <summary> graph builder interface. </summary>
        private IFilterGraph2 m_FilterGraph = null;
        IMediaControl m_mediaCtrl = null;
        IMediaEvent m_MediaEvent = null;

        /// <summary> Dimensions of the image, calculated once in constructor. </summary>
        private int m_videoWidth;
        private int m_videoHeight;
        private int m_stride;
        public int m_Count = 0;
        public int m_Blacks = 0;

#if DEBUG
        // Allow you to "Connect to remote graph" from GraphEdit
        DsROTEntry m_rot = null;
#endif

        // Added for DMA project
        public int methodnr;
        public List<Shot> shots;
        private Shot currentshot;
        public byte[] prevFrame; //TODO: checken voor memory leaks (expliciet destructor?
        public int prevFrameBufferLen;
        public int[][] histogramPrevFrame;
        public int[][][] localHistogramPrevFrame;
        public List<int[][][]> localHistogramsBuffer;

        //method 1
        public int method1_delta2;
        public double method1_delta3;

        //method 2
        double method2_tresh;
        int method2and3_block_size;
        int method2_window_size;

        //method 3
        int method3_init_step;
        double method3_tresh;

        //method 4
        double method4_tresh;
        int method4_bins;

        //method 5
        double method5_tresh;
        int method5and6_bins;
        int method5and6_region_size;

        //method 6
        double method6_tresh;
        double method6_var;
        int method6_buffer;

        #endregion

        #region API

        [DllImport("Kernel32.dll", EntryPoint = "RtlMoveMemory")]
        private static extern void CopyMemory(IntPtr Destination, IntPtr Source, [MarshalAs(UnmanagedType.U4)] uint Length);

        #endregion


        //------------- Eigen methodes-------------------------

        //setters is gewoon .naam niet .setnaam
        public void StartMethod1(int delta2, double delta3)
        {
            methodnr = 1;
            method1_delta2 = delta2;
            method1_delta3 = delta3;
            this.Start();
        }

        public void StartMethod2(double tresh, int block_size, int window_size)
        {
            methodnr = 2;
            method2_tresh = tresh;
            method2and3_block_size = block_size;
            method2_window_size = window_size;
            this.Start();
        }

        public void StartMethod3(double tresh, int block_size, int step)
        {
            methodnr = 3;
            method2and3_block_size = block_size;
            method3_init_step = step;
            method3_tresh = tresh;

            this.Start();
        }

        public void StartMethod4(double tresh, int bins)
        {
            methodnr = 4;
            this.method4_tresh = tresh;
            this.method4_bins = bins;
            this.Start();
        }

        public void StartMethod5(double tresh, int bins, int region_size)
        {
            methodnr = 5;
            this.method5_tresh = tresh;
            this.method5and6_bins = bins;
            this.method5and6_region_size = region_size;
            this.Start();
        }

        public void StartMethod6(double threshold, double var, int bins, int region_size, int buffer)
        {
            methodnr = 6;
            this.method6_tresh = threshold;
            this.method6_var = var;
            this.method5and6_bins = bins;
            this.method5and6_region_size = region_size;
            this.method6_buffer = buffer;
            this.Start();
        }

        /// <summary> File name to scan</summary>
        public Capture(string FileName)
        {
            //INTIALISATIE
            methodnr = 1;
            method1_delta2 = 0;
            method1_delta3 = 0;
            method2_tresh = 0;
            method2and3_block_size = 0;
            method2_window_size = 0;
            method3_init_step = 0;
            method3_tresh = 0;
            method4_tresh = 0;
            method4_bins = 0;
            method5_tresh = 0;
            method5and6_bins = 0;
            method5and6_region_size = 0;
            method6_tresh = 0;
            method6_var = 0;
            method6_buffer = 0;

            shots = new List<Shot>();
            prevFrame = null;
            prevFrameBufferLen = 0;
            currentshot = null;
            histogramPrevFrame = null;
            localHistogramPrevFrame = null;
            localHistogramsBuffer = new List<int[][][]>();

            try
            {
                // Set up the capture graph
                SetupGraph(FileName);
            }
            catch
            {
                Dispose();
                throw;
            }
        }
        /// <summary> release everything. </summary>
        public void Dispose()
        {
            CloseInterfaces();
        }
        // Destructor
        ~Capture()
        {
            CloseInterfaces();
        }


        /// <summary> capture the next image </summary>
        public void Start()
        {
            int hr = m_mediaCtrl.Run();
            DsError.ThrowExceptionForHR(hr);
        }


        public void WaitUntilDone()
        {
            int hr;
            EventCode evCode;
            const int E_Abort = unchecked((int)0x80004004);

            do
            {
                System.Windows.Forms.Application.DoEvents();
                hr = this.m_MediaEvent.WaitForCompletion(100, out evCode);
            } while (hr == E_Abort);
            DsError.ThrowExceptionForHR(hr);
        }

        /// <summary> build the capture graph for grabber. </summary>
        private void SetupGraph(string FileName)
        {
            int hr;

            ISampleGrabber sampGrabber = null;
            IBaseFilter baseGrabFlt = null;
            IBaseFilter capFilter = null;
            IBaseFilter nullrenderer = null;

            // Get the graphbuilder object
            m_FilterGraph = new FilterGraph() as IFilterGraph2;
            m_mediaCtrl = m_FilterGraph as IMediaControl;
            m_MediaEvent = m_FilterGraph as IMediaEvent;

            IMediaFilter mediaFilt = m_FilterGraph as IMediaFilter;

            try
            {
#if DEBUG
                m_rot = new DsROTEntry(m_FilterGraph);
#endif

                // Add the video source
                hr = m_FilterGraph.AddSourceFilter(FileName, "Ds.NET FileFilter", out capFilter);
                DsError.ThrowExceptionForHR(hr);

                // Get the SampleGrabber interface
                sampGrabber = new SampleGrabber() as ISampleGrabber;
                baseGrabFlt = sampGrabber as IBaseFilter;

                ConfigureSampleGrabber(sampGrabber);

                // Add the frame grabber to the graph
                hr = m_FilterGraph.AddFilter(baseGrabFlt, "Ds.NET Grabber");
                DsError.ThrowExceptionForHR(hr);

                // ---------------------------------
                // Connect the file filter to the sample grabber

                // Hopefully this will be the video pin, we could check by reading it's mediatype
                IPin iPinOut = DsFindPin.ByDirection(capFilter, PinDirection.Output, 0);

                // Get the input pin from the sample grabber
                IPin iPinIn = DsFindPin.ByDirection(baseGrabFlt, PinDirection.Input, 0);

                hr = m_FilterGraph.Connect(iPinOut, iPinIn);
                DsError.ThrowExceptionForHR(hr);

                // Add the null renderer to the graph
                nullrenderer = new NullRenderer() as IBaseFilter;
                hr = m_FilterGraph.AddFilter(nullrenderer, "Null renderer");
                DsError.ThrowExceptionForHR(hr);

                // ---------------------------------
                // Connect the sample grabber to the null renderer

                iPinOut = DsFindPin.ByDirection(baseGrabFlt, PinDirection.Output, 0);
                iPinIn = DsFindPin.ByDirection(nullrenderer, PinDirection.Input, 0);

                hr = m_FilterGraph.Connect(iPinOut, iPinIn);
                DsError.ThrowExceptionForHR(hr);

                // Turn off the clock.  This causes the frames to be sent
                // thru the graph as fast as possible
                hr = mediaFilt.SetSyncSource(null);
                DsError.ThrowExceptionForHR(hr);

                // Read and cache the image sizes
                SaveSizeInfo(sampGrabber);
            }
            finally
            {
                if (capFilter != null)
                {
                    Marshal.ReleaseComObject(capFilter);
                    capFilter = null;
                }
                if (sampGrabber != null)
                {
                    Marshal.ReleaseComObject(sampGrabber);
                    sampGrabber = null;
                }
                if (nullrenderer != null)
                {
                    Marshal.ReleaseComObject(nullrenderer);
                    nullrenderer = null;
                }
            }
        }

        /// <summary> Read and store the properties </summary>
        private void SaveSizeInfo(ISampleGrabber sampGrabber)
        {
            int hr;

            // Get the media type from the SampleGrabber
            AMMediaType media = new AMMediaType();
            hr = sampGrabber.GetConnectedMediaType(media);
            DsError.ThrowExceptionForHR(hr);

            if ((media.formatType != FormatType.VideoInfo) || (media.formatPtr == IntPtr.Zero))
            {
                throw new NotSupportedException("Unknown Grabber Media Format");
            }

            // Grab the size info
            VideoInfoHeader videoInfoHeader = (VideoInfoHeader)Marshal.PtrToStructure(media.formatPtr, typeof(VideoInfoHeader));
            m_videoWidth = videoInfoHeader.BmiHeader.Width;
            m_videoHeight = videoInfoHeader.BmiHeader.Height;
            m_stride = m_videoWidth * (videoInfoHeader.BmiHeader.BitCount / 8);

            DsUtils.FreeAMMediaType(media);
            media = null;
        }

        /// <summary> Set the options on the sample grabber </summary>
        private void ConfigureSampleGrabber(ISampleGrabber sampGrabber)
        {
            AMMediaType media;
            int hr;

            // Set the media type to Video/RBG24
            media = new AMMediaType();
            media.majorType = MediaType.Video;
            media.subType = MediaSubType.RGB24;
            media.formatType = FormatType.VideoInfo;
            hr = sampGrabber.SetMediaType(media);
            DsError.ThrowExceptionForHR(hr);

            DsUtils.FreeAMMediaType(media);
            media = null;

            // Choose to call BufferCB instead of SampleCB
            hr = sampGrabber.SetCallback(this, 1);
            DsError.ThrowExceptionForHR(hr);
        }

        /// <summary> Shut down capture </summary>
        private void CloseInterfaces()
        {
            int hr;

            try
            {
                if (m_mediaCtrl != null)
                {
                    // Stop the graph
                    hr = m_mediaCtrl.Stop();
                    m_mediaCtrl = null;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

#if DEBUG
            if (m_rot != null)
            {
                m_rot.Dispose();
            }
#endif

            if (m_FilterGraph != null)
            {
                Marshal.ReleaseComObject(m_FilterGraph);
                m_FilterGraph = null;
            }
            GC.Collect();
        }

        /// <summary> sample callback, NOT USED. </summary>
        int ISampleGrabberCB.SampleCB(double SampleTime, IMediaSample pSample)
        {
            Marshal.ReleaseComObject(pSample);
            return 0;
        }

        /// <summary> buffer callback, COULD BE FROM FOREIGN THREAD. </summary>
        unsafe int ISampleGrabberCB.BufferCB(double SampleTime, IntPtr pBuffer, int BufferLen)
        {
            switch (methodnr)
            {

                case 1:
                    PixelDifferenceSD(pBuffer, BufferLen);
                    break;
                case 2:
                    ExhaustiveMotionEstimation(pBuffer, BufferLen);
                    break;
                case 3:
                    OptimizedMotionEstimationSD(pBuffer, BufferLen);
                    break;
                case 4:
                    GlobalHistogramSD(pBuffer, BufferLen);
                    break;
                case 5:
                    LocalHistogramSD(pBuffer, BufferLen);
                    break;
                case 6:
                    GeneralizedLocalHistogramSD(pBuffer, BufferLen);
                    break;
                default:
                    break;
            }
            Console.WriteLine("Sample Time: " + SampleTime);
            prevFrame = new byte[BufferLen];

            Marshal.Copy(pBuffer, prevFrame, 0, BufferLen);
            prevFrameBufferLen = BufferLen;

            // Increment frame number.  Done this way, frame are zero indexed.
            m_Count++;

            return 0;
        }

        //==================================Method1===========================================
        unsafe void PixelDifferenceSD(IntPtr pBuffer, int BufferLen)
        {
            byte* pb = (byte*)pBuffer;
            int diffcounter = 0;
            if (prevFrame != null)
            {
                for (int x = 0; x < m_videoHeight; x++)
                {
                    for (int y = 0; (y < m_videoWidth); y++)
                    {
                        // calculate color difference for one pixel (between current and previous frame)
                        int d = Math.Abs((*pb) - prevFrame[(x * m_videoWidth + y) * 3]);
                        pb++;
                        d += Math.Abs((*pb) - prevFrame[((x * m_videoWidth + y) * 3) + 1]);
                        pb++;
                        d += Math.Abs((*pb) - prevFrame[((x * m_videoWidth + y) * 3) + 2]);
                        pb++;

                        // if difference is large enough, add 1 to diffcounter
                        if (d > method1_delta2)
                            diffcounter++;
                    }

                }
                if ((double)diffcounter / (m_videoHeight * m_videoWidth) > method1_delta3)
                {
                    currentshot.End = m_Count - 1;
                    shots.Add(currentshot);
                    Bitmap b = DeepCopyBitmapGenerator(pBuffer);
                    currentshot = new Shot("Startframe " + m_Count, m_Count, -1, b);

                }

            }
            else
            {
                Bitmap b = DeepCopyBitmapGenerator(pBuffer);
                currentshot = new Shot("Startframe " + m_Count, 0, -1, b); //-1 is placeholder for end not known
            }

        }

        //==================================Method2===========================================
        unsafe void ExhaustiveMotionEstimation(IntPtr pBuffer, int BufferLen)
        {
            if (prevFrame != null)
            {
                // calculate difference
                double diff = ExhaustiveMotionEstimationCompareHelper(pBuffer, BufferLen);
                if (diff > method2_tresh)
                {
                    // add shot
                    currentshot.End = m_Count - 1;
                    shots.Add(currentshot);
                    Bitmap b = DeepCopyBitmapGenerator(pBuffer);
                    currentshot = new Shot("Startframe " + m_Count, m_Count, -1, b);
                }
            }
            else
            {
                Bitmap b = DeepCopyBitmapGenerator(pBuffer);
                currentshot = new Shot("Startframe " + m_Count, 0, -1, b); //-1 is placeholder for end not known

            }

        }

        unsafe double ExhaustiveMotionEstimationCompareHelper(IntPtr pBuffer, int BufferLen)
        {
            byte* pb = (byte*)pBuffer;
            int currentIndex = 0;
            int hblocks = m_videoHeight / method2and3_block_size;
            int wblocks = m_videoWidth / method2and3_block_size;

            long difference = 0;
            // for each block in current frame
            for (int i = 0; i < hblocks; i++)
            {
                for (int j = 0; j < wblocks; j++)
                {
                    long temp = long.MaxValue;
                    // loop over window
                    for (int k = -method2_window_size; k <= method2_window_size; k++)
                    {
                        for (int l = -method2_window_size; l <= method2_window_size; l++)
                        {
                            // calculate position in previous frame
                            int displacement = (k * m_videoWidth + l) * 3;
                            int indextemp = currentIndex + displacement;
                            // if calculated position of block is not fully in frame, don't use the block
                            if (j * method2and3_block_size + l >= 0 && i * method2and3_block_size + k >= 0 && (i + 1) * method2and3_block_size + k - 1 < m_videoHeight && (j + 1) * method2and3_block_size + l - 1 < m_videoWidth)
                            {
                                // compare blocks
                                long diffreturn = BlockComp(pb, indextemp);
                                // keep minimal difference
                                if (diffreturn <= temp)
                                    temp = diffreturn;
                            }
                        }
                    }
                    // don't increment pointer on last iteration
                    if (!(i == hblocks - 1 && j == wblocks - 1))
                    {
                        pb += 3 * method2and3_block_size;
                        currentIndex += 3 * method2and3_block_size;
                    }
                    difference += temp;
                }
                // don't increment pointer on last iteration
                if (i != hblocks - 1)
                {
                    pb += 3 * m_videoWidth * (method2and3_block_size - 1);
                    currentIndex += 3 * m_videoWidth * (method2and3_block_size - 1);
                }
            }
            return (double)difference / m_videoHeight / m_videoWidth / 3 / 255;
        }

        unsafe private long BlockComp(byte* curr, int prev)
        {
            long difference = 0;
            //also uses m_videoWidth and blocksize
            for (int i = 0; i < method2and3_block_size; i++)
            {
                for (int j = 0; j < method2and3_block_size * 3; j++) //*3 for different colors
                {
                    difference += Math.Abs((*curr) - prevFrame[prev]);
                    curr++;
                    prev++;
                }
                curr = curr + (m_videoWidth - method2and3_block_size) * 3;
                prev = prev + (m_videoWidth - method2and3_block_size) * 3;
            }
            return difference;
        }

        //==================================Method3===========================================
        public unsafe void OptimizedMotionEstimationSD(IntPtr pBuffer, int BufferLen)
        {
            if (prevFrame != null)
            {
                // calculate difference
                double diff = OptimizedMotionEstimationCompareHelper(pBuffer, BufferLen);
                if (diff > method3_tresh)
                {
                    // add shot
                    currentshot.End = m_Count - 1;
                    shots.Add(currentshot);
                    Bitmap b = DeepCopyBitmapGenerator(pBuffer);
                    currentshot = new Shot("Startframe " + m_Count, m_Count, -1, b);
                }
            }
            else
            {
                Bitmap b = DeepCopyBitmapGenerator(pBuffer);
                currentshot = new Shot("Startframe " + m_Count, 0, -1, b); //-1 is placeholder for end not known

            }
        }

        unsafe double OptimizedMotionEstimationCompareHelper(IntPtr pBuffer, int BufferLen)
        {
            byte* pb = (byte*)pBuffer;
            int currentIndex = 0;
            int hblocks = m_videoHeight / method2and3_block_size;
            int wblocks = m_videoWidth / method2and3_block_size;

            long difference = 0;
            // loop over all blocks
            for (int i = 0; i < hblocks; i++)
            {
                for (int j = 0; j < wblocks; j++)
                {
                    // look for best match and calculate difference
                    difference += OptimizedMotionEstimationNeighbourSearch(pb, currentIndex, i, j);
                    // don't increment pointer on last iteration
                    if (!(i == hblocks - 1 && j == wblocks - 1))
                    {
                        pb += 3 * method2and3_block_size;
                        currentIndex += 3 * method2and3_block_size;
                    }
                }
                // don't increment pointer on last iteration
                if (i != hblocks - 1)
                {
                    pb += 3 * m_videoWidth * (method2and3_block_size - 1);
                    currentIndex += 3 * m_videoWidth * (method2and3_block_size - 1);
                }
            }
            return (double)difference / m_videoHeight / m_videoWidth / 3 / 255;
        }

        unsafe long OptimizedMotionEstimationNeighbourSearch(byte* bytepointer, int index, int ipos, int jpos)
        {
            byte* pb = bytepointer;
            int currentIndex = index;

            long difference = 0;
            int step = method3_init_step;
            bool flag = true;

            // i and j are offset in number of pixels
            int i = ipos * method2and3_block_size;
            int j = jpos * method2and3_block_size;

            // logaritmic search
            while (flag)
            {
                long temp = long.MaxValue;
                int newi = 0;
                int newj = 0;
                int newcurrentIndex = 0;

                // iterate over 9 candidates
                for (int k = -step; k <= step; k += step)
                {
                    for (int l = -step; l <= step; l += step)
                    {
                        // calculate position of candidate in previous frame
                        int displacement = (k * m_videoWidth + l) * 3;
                        int indextemp = currentIndex + displacement;
                        // make sure block is fully in frame
                        if (j + l >= 0 && i + k >= 0 && i + method2and3_block_size + k - 1 < m_videoHeight && j + method2and3_block_size + l - 1 < m_videoWidth)
                        {
                            //compare blocks and update if necessary
                            long diffreturn = BlockComp(pb, indextemp);
                            // keep track of best match
                            if (diffreturn <= temp)
                            {
                                temp = diffreturn;
                                newi = i + k;
                                newj = j + l;
                                newcurrentIndex = indextemp;
                            }
                        }
                    }
                }

                //prepare next iteration
                i = newi;
                j = newj;
                currentIndex = newcurrentIndex;
                difference = temp;
                if (step == 1)
                    // stop
                    flag = false;
                else
                    // divide step by 2 for logaritmic search round best match
                    step = step / 2;
            }

            return difference;
        }

        //==================================Method4===========================================
        private unsafe void GlobalHistogramSD(IntPtr pBuffer, int BufferLen)
        {
            // one histogram for each color value (R, G and B)
            int[][] histogramCurrentFrame = new int[3][];

            for (int i = 0; i < 3; i++)
            {
                // number of bins
                histogramCurrentFrame[i] = new int[method4_bins];
            }

            // Create histogram for current frame
            CreateHistogram(pBuffer, ref histogramCurrentFrame);

            if (prevFrame != null)
            {
                // calculate difference between current and previous frame histogram
                if (HistogramDifference(ref histogramCurrentFrame, ref histogramPrevFrame) > method4_tresh)
                {
                    // add shot
                    currentshot.End = m_Count - 1;
                    shots.Add(currentshot);
                    Bitmap b = DeepCopyBitmapGenerator(pBuffer);
                    currentshot = new Shot("Startframe " + m_Count, m_Count, -1, b);
                    histogramPrevFrame = histogramCurrentFrame;
                }
            }
            else
            {
                Bitmap b = DeepCopyBitmapGenerator(pBuffer);
                currentshot = new Shot("Startframe " + m_Count, 0, -1, b); //-1 is placeholder for end not known
                histogramPrevFrame = histogramCurrentFrame;
            }

        }

        private unsafe void CreateHistogram(IntPtr pBuffer, ref int[][] histogram)
        {
            byte* pb = (byte*)pBuffer;
            // number of colours per bin (ceil(256/bins))
            int coloursPerBin = (int)Math.Ceiling(256.0 / (double)method4_bins);

            for (int index = 0; index < m_videoWidth * m_videoHeight; index++)
            {
                int binIndex = ((int)*pb) / coloursPerBin;
                // add one pixel to specific R-bin
                histogram[0][binIndex]++;

                // move pointer to next value
                pb++;
                binIndex = ((int)*pb) / coloursPerBin;
                // add one pixel to specific G-bin
                histogram[1][binIndex]++;

                // move pointer to next value
                pb++;
                binIndex = ((int)*pb) / coloursPerBin;
                // add one pixel to specific B-bin
                histogram[2][binIndex]++;

                // move pointer to next value
                pb++;
            }
        }

        private double HistogramDifference(ref int[][] histo1, ref int[][] histo2)
        {
            double differenceR = 0.0, differenceG = 0.0, differenceB = 0.0;

            for (int i = 0; i < method4_bins; i++)
            {
                differenceR += Math.Abs(histo1[0][i] - histo2[0][i]);
                differenceG += Math.Abs(histo1[1][i] - histo2[1][i]);
                differenceB += Math.Abs(histo1[2][i] - histo2[2][i]);
            }

            double maxDiff = m_videoWidth * m_videoHeight * 2;
            return (differenceR + differenceG + differenceB) / 3.0 / maxDiff;
        }

        //==================================Method5===========================================
        private unsafe void LocalHistogramSD(IntPtr pBuffer, int BufferLen)
        {
            // allowed region sizes: 2x2, 4x4,8x8, 16x16 (will fit in test videos)
            int numberOfLocalHist = m_videoWidth * m_videoHeight / method5and6_region_size;
            // one local histogram for each color value (R, G and B)
            int[][][] localHistogramCurrentFrame = new int[numberOfLocalHist][][];

            for (int i = 0; i < numberOfLocalHist; i++)
            {
                // RGB-values per localHistogram
                localHistogramCurrentFrame[i] = new int[3][];
                for (int j = 0; j < 3; j++)
                {
                    // number of bins
                    localHistogramCurrentFrame[i][j] = new int[method5and6_bins];
                }
            }

            // create local histrograms
            CreateLocalHistograms(pBuffer, ref localHistogramCurrentFrame);

            if (prevFrame != null)
            {
                // if difference is large enough
                if (LocalHistogramDifference(ref localHistogramCurrentFrame, ref localHistogramPrevFrame) > method5_tresh)
                {
                    // add shot
                    currentshot.End = m_Count - 1;
                    shots.Add(currentshot);
                    Bitmap b = DeepCopyBitmapGenerator(pBuffer);
                    currentshot = new Shot("Startframe " + m_Count, m_Count, -1, b);
                    localHistogramPrevFrame = localHistogramCurrentFrame;
                }
            }
            else
            {
                Bitmap b = DeepCopyBitmapGenerator(pBuffer);
                currentshot = new Shot("Startframe " + m_Count, 0, -1, b); //-1 is placeholder for end not known
                localHistogramPrevFrame = localHistogramCurrentFrame;
            }
        }

        private unsafe void CreateLocalHistograms(IntPtr pBuffer, ref int[][][] localHistograms)
        {
            // assume that the frame can always be divided in equal square blocks of method5_region_size pixels
            // allowed sizes: 2x2,4x4,8x8,16x16
            int width = (int)Math.Sqrt((double)method5and6_region_size);

            byte* pb = (byte*)pBuffer;
            // number of colours per bin (ceil(256/bins))
            int coloursPerBin = (int)Math.Ceiling(256.0 / (double)method5and6_bins);

            for (int index = 0; index < m_videoWidth * m_videoHeight; index++)
            {
                // xy-value of block in frame
                int x = index % m_videoWidth;
                int y = index / m_videoWidth;
                // which local histogram?
                int localrow = y / width;
                int local = localrow * (m_videoWidth / width) + x / width;

                int binIndex = ((int)*pb) / coloursPerBin;
                // add one pixel to specific bin (for R-value)
                localHistograms[local][0][binIndex]++;
                // move pointer to next value of the pixel
                pb++;

                binIndex = ((int)*pb) / coloursPerBin;
                // add one pixel to specific bin (for G-value)
                localHistograms[local][1][binIndex]++;
                pb++;

                binIndex = ((int)*pb) / coloursPerBin;
                // add one pixel to specific bin (for B-value)
                localHistograms[local][2][binIndex]++;
                if (index != m_videoHeight * m_videoWidth - 1)
                    pb++;

            }
        }

        private double LocalHistogramDifference(ref int[][][] histo1, ref int[][][] histo2)
        {
            double differenceR = 0.0, differenceG = 0.0, differenceB = 0.0;

            for (int i = 0; i < m_videoWidth * m_videoHeight / method5and6_region_size; i++)
            {
                for (int j = 0; j < method5and6_bins; j++)
                {
                    differenceR += Math.Abs(histo1[i][0][j] - histo2[i][0][j]);
                    differenceG += Math.Abs(histo1[i][1][j] - histo2[i][1][j]);
                    differenceB += Math.Abs(histo1[i][2][j] - histo2[i][2][j]);
                }
            }

            double maxDiff = m_videoWidth * m_videoHeight * 2;
            return (differenceR + differenceG + differenceB) / 3.0 / maxDiff;
        }

        //==================================Method6===========================================
        private unsafe void GeneralizedLocalHistogramSD(IntPtr pBuffer, int BufferLen)
        {
            // constants and allocation
            int numberOfLocalHist = m_videoWidth * m_videoHeight / method5and6_region_size;
            int[][][] localHistogramCurrentFrame = new int[numberOfLocalHist][][];
            for (int i = 0; i < numberOfLocalHist; i++)
            {
                localHistogramCurrentFrame[i] = new int[3][];
                for (int j = 0; j < 3; j++)
                {
                    localHistogramCurrentFrame[i][j] = new int[method5and6_bins];
                }
            }

            // start first shot
            if (prevFrame == null)
            {
                Bitmap b = DeepCopyBitmapGenerator(pBuffer);
                currentshot = new Shot("Startframe " + m_Count, 0, -1, b); //-1 is placeholder for end not known
            }

            // Calculate local histograms of current frame
            CreateLocalHistograms(pBuffer, ref localHistogramCurrentFrame);

            if (localHistogramsBuffer.Count == method6_buffer)
            {
                int count = 0;
                double mean = 0.0;
                double[] differences = LocalHistrogramAllDifferences(ref localHistogramCurrentFrame);

                // how many previous frames differ?
                for (int i = 0; i < differences.Length; i++)
                {
                    mean += (double)differences[i];
                    if (differences[i] > method6_tresh)
                    {
                        count++;
                    }
                }
                mean = mean / method6_buffer;

                // if differences are all larger than threshold => cut
                if (count == method6_buffer)
                {
                    currentshot.End = m_Count - 1;
                    shots.Add(currentshot);
                    Bitmap b = DeepCopyBitmapGenerator(pBuffer);
                    currentshot = new Shot("Startframe " + m_Count, m_Count, -1, b);

                    //flush histogram-buffer
                    localHistogramsBuffer.Clear();
                }

                // id not all differences are larger, but some are above threshold
                if (count > 0 && count < method6_buffer)
                {
                    // calculate variance of differences
                    double var = 0.0;
                    for (int i = 0; i < differences.Length; i++)
                    {
                        var += ((double)differences[i] - mean) * ((double)differences[i] - mean);
                    }
                    var = var / method6_buffer;

                    // if variance is large => gradual transition
                    if (var > method6_var)
                    {
                        currentshot.End = m_Count - 1;
                        shots.Add(currentshot);
                        Bitmap b = DeepCopyBitmapGenerator(pBuffer);
                        currentshot = new Shot("Startframe " + m_Count, m_Count, -1, b);

                        //flush histogram-buffer
                        localHistogramsBuffer.Clear();
                    }

                    // add current to buffer and remove first one
                    localHistogramsBuffer.RemoveAt(0);
                    localHistogramsBuffer.Add(localHistogramCurrentFrame);
                }

                // 
                if (count == 0)
                {
                    // add current to buffer and remove first one 
                    localHistogramsBuffer.RemoveAt(0);
                    localHistogramsBuffer.Add(localHistogramCurrentFrame);
                }
            }
            else
            {
                // just add local histograms of frame to list untill buffer is full
                localHistogramsBuffer.Add(localHistogramCurrentFrame);
            }
        }

        private double[] LocalHistrogramAllDifferences(ref int[][][] currentHisto)
        {
            double[] differences = new double[method6_buffer];

            for (int i = 0; i < method6_buffer; i++)
            {
                // calculate difference between current histogram and histograms in buffer
                int[][][] fromList = localHistogramsBuffer[i];
                differences[i] = LocalHistogramDifference(ref currentHisto, ref fromList);
            }
            return differences;
        }

        //==================================Other===========================================
        public void FinalizeLastShot()
        {
            currentshot.End = m_Count - 1;//! -1 omdat er nog ++ was gedaan
            shots.Add(currentshot);
        }

        private unsafe Bitmap DeepCopyBitmapGenerator(IntPtr pBuffer)
        {
            Bitmap copy = null;
            Bitmap b = new Bitmap(m_videoWidth, m_videoHeight, m_stride, PixelFormat.Format24bppRgb, pBuffer);
            b.RotateFlip(RotateFlipType.RotateNoneFlipY);
            using (MemoryStream stream = new MemoryStream())
            {
                b.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                copy = new Bitmap(stream);
                stream.Close();
            }

            return copy;
        }

    }

}