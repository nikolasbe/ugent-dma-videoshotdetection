using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Tisda
{
    class VideoManager
    {
        #region Static singleton variables
        
        private static object objLock = new Object();

        #endregion

        #region Member variables
        private string filename;
        enum State
        {
            Uninit,
            Stopped,
            Paused,
            Playing
        }
        private State m_State = State.Uninit;
        private DxPlay m_play = null;
        private List<Shot> shotlist = null;
        private List<Shot> filtered_shotlist = null;
        private String filter_keyword = "";

        #endregion

        public VideoManager() {
        }

        ~VideoManager()
        {
            if (m_play != null)
            {
                m_play.Dispose();
            }
        }

        //Getter-setter for the filename of the loaded file - "" if no file was loaded
        public String FileName
        {
            get
            {
                return filename;
            }
        }

        //Getter-setter for the lastly created shotlist - if tried to set a null, create an empty shotlist
        public List<Shot> ShotList
        {
            get
            {
                return this.shotlist;
            }
            set
            {
                if (value != null)
                {
                    this.shotlist = value;
                    filter("");
                }
                else
                {
                    this.shotlist = new List<Shot>();
                    filter("");
                }
                
            }
        }

        //Getter for the list of shots displayed in the GUI
        public List<Shot> FilteredShotList
        {
            //Apply an empty filter when there is no filtered shotlist to create one
            get
            {
                if (filtered_shotlist == null)
                {
                    filter("");
                }
                return filtered_shotlist;
            }
        }

        //Load a new video file - return true if succes, false otherwise
        public Boolean load(String filename, Control panel)
        {
            // Did the filename change?
            if (m_play != null && filename != this.filename)
            {
                // File name changed, close the old file
                m_play.Dispose();
                m_play = null;
                m_State = State.Uninit;
            }

            // If we have no file open
            if (m_play == null)
            {
                try
                {
                    // Open the file, provide a handle to play it in
                    this.filename = filename;
                    m_play = new DxPlay(panel, filename);

                    // Let us know when the file is finished playing
                    m_play.StopPlay += new DxPlay.DxPlayEvent(m_play_StopPlay);
                    m_State = State.Stopped;
                }
                catch (COMException ce)
                {
                    return false;
                }
            }

            //A new file was loaded
            return true;
        }

        //Play the loaded file if there is one
        public void play(Control panel)
        {
            //Only try to play when there is an m_play object
            if (m_play != null)
            {
                // If we were stopped, start
                if (m_State == State.Stopped || m_State == State.Paused)
                {
                    m_play.Start();
                    m_State = State.Playing;
                }
            }
            //There is no video file - we shouldn't get here because the GUI shouldn't allow it
            else
            {
                MessageBox.Show("There is no videofile to play", "Play Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Play the selected shot
        public void play(int start, int end)
        {
            //Only continue if there is an m_play object
            if (m_play != null)
            {
                //Set the correct parameters in m_play to play a shot
                m_play.PlayShot(start, end);
                //Let us know when the shot stopped playing
                m_play.StopPlay += new DxPlay.DxPlayEvent(m_play_StopPlayShot);
                //If the video was stopped or paused, start playing the shot
                if (m_State == State.Stopped || m_State == State.Paused)
                {
                    m_play.Start();
                    m_State = State.Playing;
                }
            }
            //There is no shot to play, we shouldn't get here because the GUI shouldn't allow it
            else
            {
                MessageBox.Show("There is no video file to play shot from", "Play Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Pause the video sequence
        public void pause()
        {
            // If we are playing, pause
            if (m_State == State.Playing)
            {
                m_play.Pause();
                m_State = State.Paused;
            }
        }

        //Stop the video sequence and set it to the beginning
        public void stop() {
            if (m_State == State.Playing || m_State == State.Paused)
            {
                m_play.Stop();
                m_State = State.Stopped;
                m_play.Rewind();
            }
        }

        //Filter the shotlist and add every appropriate shot to the filtered_shotlist
        public void filter(String keyword)
        {
            this.filter_keyword = keyword;
            //Start with an unfiltered list
            this.filtered_shotlist = new List<Shot>();
            //Don't filter if no keyword has been given
            if (!keyword.Equals(""))
            {
                //Remove each shot that isn't described with this keyword
                foreach (Shot shot in shotlist)
                {
                    foreach (String shot_keyword in shot.KeyWords)
                    {
                        if (shot_keyword.ToLowerInvariant().Contains(keyword.ToLowerInvariant()))
                        {
                            this.filtered_shotlist.Add(shot);
                            break;
                        }
                    }
                }
            }
            else
            {
                this.filtered_shotlist = shotlist;
            }
        }

        //Edit the info of one of the shots
        public void editShotInfo(String[] keywords, int filtered_index)
        {
            Shot shot = filtered_shotlist.ElementAt(filtered_index);
            shotlist.Find(o => o.End == shot.End).KeyWords = new List<String>(keywords);
            filter(filter_keyword);
        }

        //When the file stopped playing, rewind
        private void m_play_StopPlay(Object sender)
        {
            m_State = State.Stopped;

            // Rewind clip to beginning to allow DxPlay.Start to work again.
            m_play.Rewind();    
        }

        //When the shot stopped playing reset the video sequence
        private void m_play_StopPlayShot(Object sender)
        {
            m_State = State.Stopped;
            //m_play.Rewind();
            m_play.Reset();
        }
    }
}
