using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tisda
{
    class ShotDetector
    {
        private String[] detectionMethods = { "Exercise 1", "Exercise 2", "Exercise 3", "Exercise 4", "Exercise 5", "Exercise 6" };
        private ParameterPanel[] panels = { new Method1Panel(), new Method2Panel(), new Method3Panel(), new Method4Panel(), new Method5Panel(), new Method6Panel() };
        private Capture cam = null;
        private int detection_method = -1;
        private object[] detection_args;

        //Getter with the string description of each possible method
        public String[] DetectionMethods
        {
            get
            {
                return detectionMethods;
            }
        }

        //Getter-setter for the detection method used the last time detectShots was called
        public int DetectionMethod
        {
            get
            {
                return detection_method;
            }
            set
            {
                this.detection_method = value;
            }
        }

        //Getter-setter for the detection arguments used the last time detectShots was called
        public object[] DetectionArgs
        {
            get
            {
                return detection_args;
            }
            set
            {
                detection_args = value;
            }
        }

        //Getter for the panels for each detection method
        public ParameterPanel[] Panels
        {
            get
            {
                return panels;
            }
        }

        //Detect the shots in a give file with a given method
        public List<Shot> detectShots(int method, String filename)
        {
            //All possible parameters
            int delta2, block_size, window_size, bins, region_size, step, buffer;
            double delta3, threshold, var;

            cam = new Capture(filename);

            //Get the parameters
            object[] par = panels[method].getParams();

            //Update the videomanager with the detection parameters
            detection_method = method + 1;
            detection_args = par;

            //Extract the appropriate parameters and start detection
            switch (method)
            {
                case 0:
                    delta2 = (int)par[0];
                    delta3 = (double)par[1];
                    cam.StartMethod1(delta2, delta3);
                    break;
                case 1:
                    threshold = (double)par[0];
                    block_size = (int)par[1];
                    window_size = (int)par[2];
                    cam.StartMethod2(threshold, block_size, window_size);
                    break;
                case 2:
                    threshold = (double)par[0];
                    block_size = (int)par[1];
                    step = (int)par[2];
                    cam.StartMethod3(threshold, block_size, step);
                    break;
                case 3:
                    threshold = (double)par[0];
                    bins = (int)par[1];
                    cam.StartMethod4(threshold, bins);
                    break;
                case 4:
                    threshold = (double)par[0];
                    bins = (int)par[1];
                    region_size = (int)par[2];
                    cam.StartMethod5(threshold, bins, region_size);
                    break;
                case 5:
                    threshold = (double)par[0];
                    var = (double)par[1];
                    bins = (int)par[2];
                    region_size = (int)par[3];
                    buffer = (int)par[4];
                    cam.StartMethod6(threshold, var, bins, region_size, buffer);
                    break;
            }
            cam.WaitUntilDone();
            cam.FinalizeLastShot();

            //Extract the shotlist from the cam object
            List<Shot> shots = cam.shots;

            //Dispose of the cam object
            lock (this)
            {
               cam.Dispose();
               cam = null;
            }

            return shots;
        }

        public List<Shot> detectShotsStandAlone(int method, String filename, object[] par)
        {
            //All possible parameters
            int delta2, block_size, window_size, bins, region_size, step, buffer;
            double delta3, threshold, var;

            cam = new Capture(filename);

            //Update the videomanager with the detection parameters
            detection_method = method + 1;
            detection_args = par;

            //Extract the appropriate parameters and start detection
            switch (method)
            {
                case 0:
                    delta2 = (int)par[0];
                    delta3 = (double)par[1];
                    cam.StartMethod1(delta2, delta3);
                    break;
                case 1:
                    threshold = (double)par[0];
                    block_size = (int)par[1];
                    window_size = (int)par[2];
                    cam.StartMethod2(threshold, block_size, window_size);
                    break;
                case 2:
                    threshold = (double)par[0];
                    block_size = (int)par[1];
                    step = (int)par[2];
                    cam.StartMethod3(threshold, block_size, step);
                    break;
                case 3:
                    threshold = (double)par[0];
                    bins = (int)par[1];
                    cam.StartMethod4(threshold, bins);
                    break;
                case 4:
                    threshold = (double)par[0];
                    bins = (int)par[1];
                    region_size = (int)par[2];
                    cam.StartMethod5(threshold, bins, region_size);
                    break;
                case 5:
                    threshold = (double)par[0];
                    var = (double)par[1];
                    bins = (int)par[2];
                    region_size = (int)par[3];
                    buffer = (int)par[4];
                    cam.StartMethod6(threshold, var, bins, region_size, buffer);
                    break;
            }
            cam.WaitUntilDone();
            cam.FinalizeLastShot();

            //Extract the shotlist from the cam object
            List<Shot> shots = cam.shots;

            //Dispose of the cam object
            lock (this)
            {
                cam.Dispose();
                cam = null;
            }

            return shots;
        }
    }
}
