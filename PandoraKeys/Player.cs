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

using System.Windows.Forms;

namespace PandoraKeys
{
    class Player
    {
        private readonly WebBrowser _webBrowser;
        
        //Constants Button Actions
        private enum Buttons {Dislike, Like, Play, Pause, Skip};

        public Player(WebBrowser webBrowser)
        {
            _webBrowser = webBrowser;
        }

        public void Dislike()
        {
            PressButton(Buttons.Dislike);
        }

        public void Like()
        {
            PressButton(Buttons.Like);
        }

        private void Play()
        {
            PressButton(Buttons.Play); //Called by PlayPause
        }

        private void Pause()
        {
            PressButton(Buttons.Pause); //Called by PlayPause
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
                    return _webBrowser.Document.GetElementById("playbackControl").FirstChild.Children[(int) Buttons.Pause].Style.ToLower().Contains("none");
                }
                catch
                {
                    return false;
                }
            }
        }

        private void PressButton(Buttons action)
        {
            try
            {
                if (_webBrowser.Document != null)
                    _webBrowser.Document.GetElementById("playbackControl").FirstChild.Children[(int)action].FirstChild.InvokeMember("click");
            }
            catch { }

        }
    }   
}
