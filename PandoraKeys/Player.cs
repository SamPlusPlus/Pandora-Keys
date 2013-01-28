/*
 * Copyright (C) 2010 Samuel Haddad, 
 * and individual contributors.
 *
 * This program is free software; you can redistribute it and/or
 * modify it under the terms of the GNU General Public License
 * as published by the Free Software Foundation; either version 3
 * of the License, or (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
 */

using System.Collections;
using System.Web;
using System.Windows.Forms;
using System.Text;
using System;

namespace PandoraKeys
{
    public class Player
    {
        private readonly WebBrowser _webBrowser;

        public Player(WebBrowser webBrowser)
        {
            _webBrowser = webBrowser;
        }

        //Constants Button Actions
        private enum Buttons { Dislike, Like, Play, Pause, Skip };

        public void Dislike()
        {
            PressButton(Buttons.Dislike);
        }

        public void Like()
        {
            PressButton(Buttons.Like);
        }

        public void PlayPause()
        {
            PressButton(IsPaused ? Buttons.Play : Buttons.Pause);
        }

        public void Skip()
        {
            PressButton(Buttons.Skip);
        }
        public void Reset()
        {
            _webBrowser.Refresh();
        }
        public bool IsPaused
        {
            get
            {
                try
                {
                    return Doc.GetElementById("playbackControl").FirstChild.Children[(int)Buttons.Pause].Style.ToLower().Contains("none");
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool IsThumbsUp
        {
            get
            {
                try
                {
                    return !Doc.GetElementById("thumbup").Style.Contains("none");
                }
                catch
                {
                    return false;
                }
            }

        }

        public Station[] Stations
        {
            get
            {
                ArrayList stationlist = new ArrayList();

                try
                {
                    HtmlElementCollection elc = _webBrowser.Document.GetElementById("stationList").Children;
                    foreach (HtmlElement el in elc)
                    {
                        HtmlElement tel = el;
                        Station st = new Station();
                        // if we have a checkbox then shuffle is selected
                        if (el.InnerHtml.Contains("checkbox"))
                        {
                            while (tel.Children.Count > 0) tel = tel.FirstChild;
                            tel = tel.Parent;
                            HtmlElementCollection children = tel.Children;
                            tel = children[2];
                        }

                        while (tel.Children.Count > 0) tel = tel.FirstChild;

                        string eltext = el.OuterHtml;
                        st.IsSelected = false;
                        // flag the selectd station for the drop down list
                        if (eltext.Contains("selected")) st.IsSelected = true;
                        // shuffleStationLabelCurrent - in shuffle mode this song is from this station
                        if (eltext.Contains("shuffleStationLabelCurrent")) st.IsCurrent = true;

                        // grab the station title
                        st.Title = tel.InnerText;
                        stationlist.Add(st);
                    }
                }
                catch
                {
                }
                Station[] s = (Station[])stationlist.ToArray(typeof(Station));
                return s;
            }
        }

        // find and return the url for the background skin style which includes the the ref for the image
        public string Skin
        {
            get
            {
                try
                {
                    HtmlElement skin = _webBrowser.Document.GetElementById("skinStyle");
                    return skin.GetAttribute("href");
                }
                catch
                {
                    return "";
                }
            }

        }

        public Song Song
        {
            get
            {
                // scan the document for Song Title, Artist, Album Title, Album image URL, Time Remaining
                var s = new Song();

                //The webbrowser isn't fully loaded let's just return a default song.
                if (_webBrowser.Document == null)
                {
                    return s;
                }

                //TODO: Refactor this

//                HtmlElementCollection col = null;
//                mshtml.IHTMLDocument2 domDoc = (mshtml.IHTMLDocument2)_webBrowser.Document.DomDocument;
//                string doc = domDoc.body.innerHTML;
//                int st;
//                int end;

              //  try
              //  {
                    //Get song
                    try {s.Title = _webBrowser.Document.InvokeScript("getSongTitle").ToString();}catch{}

                    //Get AlbumARt
                    try {s.AlbumArtURL = _webBrowser.Document.InvokeScript("getAlbumArt").ToString();} catch{}

                    //Get Artist
                    try{ s.Artist = _webBrowser.Document.InvokeScript("getArtist").ToString(); } catch{}

                    // Album Title
                    try { s.AlbumTitle = _webBrowser.Document.InvokeScript("getAlbumTitle").ToString(); } catch{}

                     //RemainingTime
                    try { s.TimeRemaining = TimeToSeconds(_webBrowser.Document.InvokeScript("getRemainingTime").ToString()); } catch{}

                    //ElapsedTime
                    try { s.ElapsedTime = TimeToSeconds(_webBrowser.Document.InvokeScript("getElapsedTime").ToString()); } catch{}

//                    try
//                    {
//                        // Time remaining
//                        st = doc.IndexOf("class=remainingTime");
//                        st = doc.IndexOf(">", st) + 2;
//                        end = doc.IndexOf("<", st);
//
//                        string[] temp = doc.Substring(st, end - st).Split(':');
//                        for (int i = 0; i < temp.Length; i++) s.TimeRemaining = (60 * s.TimeRemaining) + int.Parse(temp[i]);
//
//                        // Elapsed Time
//                        st = doc.IndexOf("class=elapsedTime");
//                        st = doc.IndexOf(">", st) + 1;
//                        end = doc.IndexOf("<", st);
//
//                        temp = doc.Substring(st, end - st).Split(':');
//                        for (int i = 0; i < temp.Length; i++) s.ElapsedTime = (60 * s.ElapsedTime) + int.Parse(temp[i]);
//
//                    }
//                    catch
//                    {
//                        s.TimeRemaining = 0;
//                        s.ElapsedTime = 0;
//                    }
//                }
//                catch
//                {
//                    s.TimeRemaining = 0;
//                }
                return s;
            }

        }

        private int TimeToSeconds(string time)
        {
            //Todo Fix Logic Here
            string[] times = time.Split(':');
            
            if (times.Length == 2)
            {
                //Minutes + seconds
                return new TimeSpan(0, Math.Abs(int.Parse(times[0])), Math.Abs(int.Parse(times[1]))).Seconds;
            }
            else if(times.Length == 3)
            {
                //Hours + Minutes + seconds
                return new TimeSpan(Math.Abs(int.Parse(times[0])), Math.Abs(int.Parse(times[1])), Math.Abs(int.Parse(times[2]))).Seconds;
            }

            //We couldn't figure out the string
            return 0;
        }

        private void SelectStation(string cmds, ref StringBuilder log)
        {
            log.Append("\nSelectStation");
            try
            {
                string[] cmd = cmds.Split('=');
                bool foundstation = false;
                HtmlElementCollection elc = Doc.GetElementById("stationList").Children;
                foreach (HtmlElement el in elc)
                {
                    HtmlElement tel = el;
                    if (el.InnerHtml.Contains("checkbox"))
                    {
                        while (tel.Children.Count > 0) tel = tel.FirstChild;
                        tel = tel.Parent;
                        HtmlElementCollection children = tel.Children;
                        tel = children[2];
                    }

                    while (tel.Children.Count > 0) tel = tel.FirstChild;
                    if (tel.InnerText.CompareTo(HttpUtility.UrlDecode(cmd[1])) == 0)
                    {
                        log.Append("\n*************** Found station: " + HttpUtility.UrlDecode(cmd[1]));
                        foundstation = true;
                        tel.InvokeMember("click");
                    }


                }
                if (!foundstation) log.Append("\n *****************\nStation not found! " + HttpUtility.UrlDecode(cmd[1]));
            }
            catch
            {
                log.Append("\n***************************   catch");
            }

        }

        public bool Command(string cmds, ref StringBuilder log)
        {
            log.Append("\ncmd switch");
            try
            {
                switch (cmds)
                {
                    case "cmd=up":
                        // volume control later
                        break;

                    case "cmd=dn":
                        // volume control later
                        break;

                    case "cmd=pause":
                        // play/pause
                        log.Append("\npause '" + cmds + "'");
                        PlayPause();
                        return IsPaused;

                    case "cmd=thumbsup":
                        // Thumbs UP
                        Like();
                        break;

                    case "cmd=thumbsdn":
                        // Thumbs Down
                        Dislike();
                        break;

                    case "cmd=tired":
                        // Next track
                        Skip();
                        break;
                    default:
                        // Select Station
                        log.Append("\ndefault '" + cmds + "'");
                        if (cmds.Contains("station"))
                        {
                            log.Append("\ncall selectStation");
                            SelectStation(cmds, ref log);
                        }
                        break;
                }
            }
            catch (Exception e) { log.Append("\ncmd catch: " + e.Message); }

            return false;
        }
      
        private void PressButton(Buttons action)
        {
            try
            {
                if (Doc != null)
                    Doc.GetElementById("playbackControl").FirstChild.Children[(int)action].FirstChild.InvokeMember("click");
            }
            catch { }

        }

        private HtmlDocument Doc
        {
            get
            {
                HtmlDocument doc = null;
                try
                {

                    if (_webBrowser.InvokeRequired)
                    {
                        _webBrowser.Invoke((MethodInvoker)delegate
                        {
                            doc = _webBrowser.Document;
                        });
                    }
                    else
                    {

                        doc = _webBrowser.Document;
                    }
                }
                catch { }

                return doc;
            }
        }

    }
}
