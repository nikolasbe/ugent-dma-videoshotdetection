using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Xml;

namespace Tisda
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Argumenten - ZELF AANPASSEN INDIEN GEWENST
            String test_results_path = "C:\\Users\\Nikolas\\Downloads";
            String filename = "C:\\Users\\Nikolas\\Documents\\Universiteit\\1e Master Computerwetenschappen 2012 - 2013\\Ontwerp van multimediatoepassingen\\Lab_sessions\\Video_shot_detection_annotation_and_retrieval\\Test_files\\return_jedi_trailer_cuts-only.avi";
            String truth_filename = "C:\\Users\\Nikolas\\Documents\\Universiteit\\1e Master Computerwetenschappen 2012 - 2013\\Ontwerp van multimediatoepassingen\\Lab_sessions\\Video_shot_detection_annotation_and_retrieval\\Test_files\\return_jedi_trailer_cuts-only_GT.xml";
            int method_to_test = 2;

            test(test_results_path, filename, truth_filename, method_to_test);
        }

        static void test(String test_results_path, String filename, String truth_filename, int method_to_test)
        {
            //Creeer kortere filename voor bestandsnaam
            String short_filename = filename.Split('\\')[filename.Split('\\').Length - 1];
            //Creeer lijst met testargumenten
            TextWriter tw = new StreamWriter(test_results_path + "\\test_results_" + short_filename + "_" + method_to_test + ".txt");
            List<object[]> args_list = new List<object[]>();
            switch (method_to_test)
            {
                case 1:
                    args_list = testMethod1Args();
                    break;
                case 2:
                    args_list = testMethod2Args();
                    break;
                case 3:
                    args_list = testMethod3Args();
                    break;
                case 4:
                    args_list = testMethod4Args();
                    break;
                case 5:
                    args_list = testMethod5Args();
                    break;
                case 6:
                    args_list = testMethod6Args();
                    break;
                default:
                    break;
            }

            //Test uitvoeren voor alle mogelijke argumenten
            ShotDetector sd = new ShotDetector();
            Stopwatch sw = new Stopwatch();
            List<Shot> shotlist = new List<Shot>();
            XMLCreator xmlcreator = new XMLCreator();
            XMLComparator xmlcomp = new XMLComparator();
            long timepassed;
            double[] results;
            double recall, precision;
            foreach (object[] args in args_list)
            {
                //Meten van het detecteren van de shots
                sw.Reset();
                sw.Start();
                shotlist = sd.detectShotsStandAlone(method_to_test-1, filename, args);
                sw.Stop();
                timepassed = sw.ElapsedMilliseconds;
                //Aanmaken van XML op basis van shotlist
                XmlDocument own = xmlcreator.createShotsXML(method_to_test, args, shotlist, filename);
                XmlDocument truth = new XmlDocument();
                truth.Load(truth_filename);
                //Bereken recall en precision
                results = xmlcomp.performanceMeasures(truth, own);
                recall = results[0];
                precision = results[1];
                
                //Schrijf naar output
                String diag = "";
                foreach (object arg in args)
                {
                    diag += arg.ToString() + ";";
                }

                diag += timepassed + ";" + recall + ';' + precision;
                tw.WriteLine(diag);
                Debug.WriteLine(diag);
            }
            tw.Close();
        }

        static List<object[]> testMethod1Args()
        {
            List<object[]> list = new List<object[]>();
            for (int delta2 = 0; delta2 <= 3 * 255; delta2 += 50)
            {
                for (double delta3 = 0.0; delta3 <= 1.0; delta3 += 0.25)
                {
                    object[] args = new object[2];
                    //Args invullen
                    args[0] = delta2;
                    args[1] = delta3;
                    //Toevoegen aan de lijst
                    list.Add(args);
                }
            }
            return list;
        }

        static List<object[]> testMethod2Args()
        {
            List<object[]> list = new List<object[]>();
            int[] block_sizes = { 2, 4, 8, 16 };
            int[] window_sizes = { 2, 4, 8 };
            for (double treshold = 0.1; treshold <= 1.0; treshold += 0.25)
            {
                foreach (int block_size in block_sizes)
                {
                    foreach (int window_size in window_sizes)
                    {
                        object[] args = new object[3];
                        args[0] = treshold;
                        args[1] = block_size;
                        args[2] = window_size;
                        list.Add(args);
                    }
                }
                
            }
            return list;
        }

        static List<object[]> testMethod3Args()
        {
            List<object[]> list = new List<object[]>();
            int[] block_sizes = { 8, 16 };
            int[] steps = { 8, 16, 32 };
            for (double treshold = 0.0; treshold <= 1.0; treshold += 0.25)
            {
                foreach (int block_size in block_sizes)
                {
                    foreach (int step in steps)
                    {
                        object[] args = new object[3];
                        args[0] = treshold;
                        args[1] = block_size;
                        args[2] = step;
                        list.Add(args);
                    }
                }
            }
            return list;
        }

        static List<object[]> testMethod4Args()
        {
            List<object[]> list = new List<object[]>();
            return list;
        }

        static List<object[]> testMethod5Args()
        {
            List<object[]> list = new List<object[]>();
            return list;
        }

        static List<object[]> testMethod6Args()
        {
            List<object[]> list = new List<object[]>();
            return list;
        }
    }
}
