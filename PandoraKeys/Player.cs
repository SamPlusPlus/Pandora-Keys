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

        public station[] Stations
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
                        station st = new station();
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
                station[] s = (station[])stationlist.ToArray(typeof(station));
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

        public song Song
        {
            get
            {
                // scan the document for Song Title, Artist, Album Title, Album image URL, Time Remaining
                song s = new song();
                try
                {
                    // get the Title
                    HtmlDocument document = _webBrowser.Document;
                    HtmlElementCollection col = document.GetElementById("trackInfo").FirstChild.Children;
                    HtmlElementCollection col2 = col[1].Children;
                    HtmlElement a = col2[3].FirstChild;
                    s.Title = a.InnerText;
                    if (s.Title == null) s.Title = "No Title";

                    // now for the AlbumArt
                    mshtml.IHTMLDocument2 domDoc = (mshtml.IHTMLDocument2)document.DomDocument;
                    string doc = domDoc.body.innerHTML;
                    int position = doc.IndexOf("class=playerBarArt ");
                    int st = 0;
                    int end = 0;
                    if (position != -1)
                    {
                        st = doc.IndexOf("src=\"", position) + 5;
                        end = doc.IndexOf("\"", st + 1);
                        s.AlbumArtURL = doc.Substring(st, end - st);
                    }
                    else s.AlbumArtURL = "/images/no_album_art.jpg";

                    // and the Artist
                    col = document.GetElementById("trackInfo").FirstChild.Children;
                    col2 = col[1].Children;
                    HtmlElementCollection col3 = col2[4].Children;
                    s.Artist = col3[1].InnerText;
                    if (s.Artist == null) s.Artist = "No Artist";

                    // Album Title
                    col = document.GetElementById("trackInfo").FirstChild.Children;
                    col2 = col[1].Children;
                    col3 = col2[5].Children;
                    s.AlbumTitle = col3[1].InnerText;
                    if (s.AlbumTitle == null) s.AlbumTitle = "No Title";

                    // Time remaining
                    st = doc.IndexOf("class=remainingTime");
                    st = doc.IndexOf(">", st) + 2;
                    end = doc.IndexOf("<", st);

                    string[] temp = doc.Substring(st, end - st).Split(':');
                    for (int i = 0; i < temp.Length; i++) s.TimeRemaining = (60 * s.TimeRemaining) + int.Parse(temp[i]);

                    // Elapsed Time
                    st = doc.IndexOf("class=elapsedTime");
                    st = doc.IndexOf(">", st) + 1;
                    end = doc.IndexOf("<", st);

                    temp = doc.Substring(st, end - st).Split(':');
                    for (int i = 0; i < temp.Length; i++) s.ElapsedTime = (60 * s.ElapsedTime) + int.Parse(temp[i]);

                }
                catch
                {
                    s.TimeRemaining = 0;
                }
                return s;
            }

        }

        private void SelectStation(string cmds)
        {
            try
            {
                string[] cmd = cmds.Split('=');

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
                    if (tel.InnerText.CompareTo(HttpUtility.UrlDecode(cmd[1])) == 0) tel.InvokeMember("click");


                }
            }
            catch
            {

            }

        }

        public bool Command(string cmds)
        {
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
                        if (cmds.Contains("station")) SelectStation(cmds);
                        break;
                }
            }
            catch { }

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
