using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Tisda
{
    class XMLComparator
    {
        //deze methode rekent beiden in één keer uit
        public double[] performanceMeasures(XmlDocument truth, XmlDocument own)
        {
            //==============TRUTH=============
            // Get last child of truth = ShotDetection
            XmlNode truth_det = truth.LastChild;
            // Number of detected shots
            int numberOfShots = truth_det.ChildNodes.Count;
            List<int> beginFrames = new List<int>();

            // Get first shot
            XmlNode shot = truth.LastChild.FirstChild;
            beginFrames.Add(Convert.ToInt32(shot.InnerText.Split('-')[0]));

            for (int i = 1; i < numberOfShots; i++)
            {
                // Go to next shot
                shot = shot.NextSibling;
                beginFrames.Add(Convert.ToInt32(shot.InnerText.Split('-')[0]));
            }

            //==============OWN=============
            XmlNode own_det = own.FirstChild;
            XmlNode own_shot = own_det.FirstChild.NextSibling.FirstChild;
            int numberOfShots_own = own_det.FirstChild.NextSibling.ChildNodes.Count;

            List<int> beginFrames_own = new List<int>();

            // Get first shot
            beginFrames_own.Add(Convert.ToInt32(own_shot.FirstChild.InnerText.Split('-')[0]));

            for (int i = 1; i < numberOfShots_own; i++)
            {
                // Go to next shot
                own_shot = own_shot.NextSibling;
                beginFrames_own.Add(Convert.ToInt32(own_shot.FirstChild.InnerText.Split('-')[0]));
            }

            double[] res = calculatePerformance(beginFrames_own, beginFrames);

            return res;
        } //eerste double is recall, tweede is precision

        //hulpfunctie
        private double[] calculatePerformance(List<int> result, List<int> truth)
        {
            int truepos = 0;
            int falsepos = 0;

            foreach (int i in result)
            {
                if (truth.Remove(i))
                    truepos++;
                else
                    falsepos++;

            }

            int falseneg = truth.Count;
            double recall = ((double)truepos) / (truepos + falseneg);
            double precision = ((double)truepos) / (truepos + falsepos);
            double[] ret = { recall, precision };
            return ret;
        }
    }
}
