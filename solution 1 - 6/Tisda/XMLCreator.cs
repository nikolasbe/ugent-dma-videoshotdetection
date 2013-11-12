using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Tisda
{
    class XMLCreator
    {
        //Create an XML document that describes the video sequence
        public XmlDocument createShotsXML(int detection_method, object[] detection_args, List<Shot> shotlist, String filename)
        {
            XmlDocument xmldoc = new XmlDocument();

            //Create root
            XmlElement shotdetection_element = xmldoc.CreateElement("ShotDetection");
            shotdetection_element.SetAttribute("file", toSafeFileName(filename));
            xmldoc.AppendChild(shotdetection_element);

            //Create method_element
            XmlElement method_element = xmldoc.CreateElement("method");
            method_element.SetAttribute("nr", detection_method.ToString());
            //Create param_elements and add to method_elemnent
            int i = 1;
            foreach (object arg in detection_args)
            {
                XmlElement param_element = xmldoc.CreateElement("param" + i);
                param_element.InnerText = arg.ToString();
                method_element.AppendChild(param_element);
                i++;
            }
            shotdetection_element.AppendChild(method_element);

            //Create shots_element that contains each shot and append shot shotdetection_element
            XmlElement shots_element = xmldoc.CreateElement("shots");
            foreach (Shot shot in shotlist)
            {
                XmlElement shot_element = xmldoc.CreateElement("shot");
                XmlElement range_element = xmldoc.CreateElement("range");
                range_element.InnerText = shot.Start.ToString() + "-" + shot.End.ToString();
                shot_element.AppendChild(range_element);
                XmlElement keywords_element = xmldoc.CreateElement("keywords");
                foreach (String keyword in shot.KeyWords)
                {
                    XmlElement keyword_element = xmldoc.CreateElement("keyword");
                    keyword_element.InnerText = keyword;
                    keywords_element.AppendChild(keyword_element);
                }
                shot_element.AppendChild(keywords_element);
                shots_element.AppendChild(shot_element);
            }
            shotdetection_element.AppendChild(shots_element);
            
            return xmldoc;
        }

        //Extract SafeFileName from path
        private String toSafeFileName(String path){
            String[] splitted = path.Split('\\');
            String filename = splitted[splitted.Length - 1];
            return filename;
        }
    }
}
