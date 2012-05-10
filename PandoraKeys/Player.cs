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

using System.Web;
using System.Windows.Forms;

namespace PandoraKeys
{
    public static class Player
    {
        public static WebBrowser _webBrowser;

        //Constants Button Actions
        private enum Buttons { Dislike, Like, Play, Pause, Skip };

        public static void Dislike()
        {
            PressButton(Buttons.Dislike);
        }

        public static void Like()
        {
            PressButton(Buttons.Like);
        }

        public static void PlayPause()
        {

            PressButton(IsPaused ? Buttons.Play : Buttons.Pause);
        }

        public static void Skip()
        {
            PressButton(Buttons.Skip);
        }

        public static bool IsPaused
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

        public static bool IsThumbsUp
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

        private static void SelectStation(string cmds)
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

        public static bool Command(string cmds)
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

        private static HtmlDocument Doc
        {
            get
            {
                HtmlDocument doc = null;
                try
                {

                    if (_webBrowser.InvokeRequired)
                    {
                        _webBrowser.Invoke((MethodInvoker) delegate
                                                               {
                                                                   doc = _webBrowser.Document;
                                                               });
                    }
                    else
                    {

                        doc = _webBrowser.Document;
                    }
                }
                catch{}

                return doc;
            }
        }

        private static void PressButton(Buttons action)
        {
            try
            {
                HtmlDocument doc = Doc;
                if (doc != null)
                    doc.GetElementById("playbackControl").FirstChild.Children[(int)action].FirstChild.InvokeMember("click");
            }
            catch { }

        }
    }
}
