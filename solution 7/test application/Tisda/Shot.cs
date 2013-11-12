using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tisda
{
    class Shot
    {
        private List<String> keywords;
        private int start;
        private int end;
        Bitmap frame;

        //Constructor
        public Shot(String description, int start, int end, Bitmap frame)
        {
            keywords = new List<String>();
            keywords.Add(description);
            this.start = start;
            this.end = end;
            this.frame = frame;
        }

        //Getter-setter for list of keywords associated with this shot
        public List<String> KeyWords
        {
            set
            {
                keywords = value;
            }

            get
            {
                return keywords;
            }
        }

        //Getter-setter for startframe of this shot
        public int Start
        {
            get
            {
                return start;
            }
            set
            {
                start = value;
            }
        }

        //Getter-setter for endframe of this shot
        public int End
        {
            get
            {
                return end;
            }
            set
            {
                end = value;
            }
        }

        //Representative bitframe for this shot
        public Bitmap Frame
        {
            get
            {
                return frame;
            }
        }

        //ToString takes every keyword and links them together with ',' then puts [start-end] behind it
        public override string ToString()
        {
            String keywordString = "";
            foreach (String keyword in keywords)
            {
                keywordString += keyword;
                keywordString += ", ";
            }
            keywordString.Remove(keywordString.Length - 1);
            keywordString += "[" + start + "-" + end + "]";
            return keywordString;
        }
    }
}