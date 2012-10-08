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

using System;
using System.Windows.Forms;
using PandoraKeys.Utilities;
using PandoraKeys.Properties;

namespace PandoraKeys
{
    public sealed partial class Tuner : Form
    {
        UserActivityHook _actHook;
        WebServer _webserver;
        private static Log _log = null;
        private Player _player;

        public void StopLogging()
        {
           if (WebServerEnabled)
           {
              _webserver.LogEnabled = false;
           }
        }

        public DynamicItems Pitems
        {
            get
            {
                return new DynamicItems(_player);
            }
        }

        public Tuner()
        {
            InitializeComponent();

            //Create the player wrapper around the WebBrowser
            _player = new Player(PandoraBrowser);
            
            StartWebServer();

           //Setup
            //Start Keyboard Hook
            try
            {
                _actHook = new UserActivityHook();
                _actHook.KeyDown += new KeyEventHandler(MyKeyDown);
                _actHook.Start();
            }
            catch (Exception)
            {
                MessageBox.Show("Error setting up media keys. They will not work. Try to restart PandoraKeys");
            }
           
        }

        private void StartWebServer()
        {
           //Do not start the webserver if the user does not want us to.
           if (!Settings.Default.WebserverEnabled)
              return;

           //Startup the Web Server
           try
           {
              _webserver = new WebServer();
              _webserver.LogEnabled = false;
              _webserver.Port = Settings.Default.WebserverPort;
              _webserver.Start(this);
              Text = string.Format("{0} - {1}:{2}", Text, _webserver.localAddr, Settings.Default.WebserverPort.ToString());
           }
           catch (Exception e)
           {
              MessageBox.Show("Error starting web server exception: " + e.Message);
           }
        }

       #region Keyboard Hooks
        //Keyboard Hooks
        public void MyKeyDown(object sender, KeyEventArgs e)
        {
            //Play Pause
            if (e.KeyCode.Equals(Keys.MediaStop) || e.KeyCode.Equals(Keys.MediaPlayPause) || e.KeyData.Equals(Settings.Default.KeyboardPlayPause))
            {
                _player.PlayPause();
            }
            //Next Track
            else if (e.KeyCode.Equals(Keys.MediaNextTrack) || e.KeyData.Equals(Settings.Default.KeyboardNextTrack))
            {
                _player.Skip();
            }
            //Like
            else if (e.KeyData.Equals(Settings.Default.KeyboardLike))
            {
                _player.Like();
            }
            //Dislike;
            else if (e.KeyData.Equals(Settings.Default.KeyboardDislike))
            {
                _player.Dislike();
            }
        }
        #endregion

        #region ContextMenu
        //Context Menu
        private void playPauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _player.PlayPause();
        }
        
        private void nextTrackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _player.Skip();
        }

        private void likeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _player.Like();
        }

        private void dislikeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _player.Dislike();
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ToggleWindow();
        }
        #endregion

        private void ToggleWindow()
        {
            if (this.Visible)
            {
                this.Visible = false;
            }
            else
            {
                this.TopMost = true;
                this.BringToFront();
                this.Visible = true;
                this.WindowState = FormWindowState.Normal;
                this.BringToFront();
                this.TopMost = false;
            }
        }
        
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
           AboutForm about = new AboutForm();
           about.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsDialog settingsDialog = new SettingsDialog();
            settingsDialog.ShowDialog();
        }

        private void hideShowPlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToggleWindow();
        }

        private void Tuner_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                ToggleWindow();
            }
        }

        private void Tuner_FormClosed(object sender, FormClosedEventArgs e)
        {
           if (WebServerEnabled)
           {
              _webserver.shutdown();
           }
        }

        // start logging
        private void log_Click(object sender, EventArgs e)
        {
            _log = new Log();
            _log.Show();
            _log.setTuner(this);

            if (WebServerEnabled)
            {
               _webserver.Logger = _log;
               _webserver.LogEnabled = true;
            }
        }

        public Player Player
        {
            get { return _player; }
        }

       private bool WebServerEnabled
       {
          get { return Settings.Default.WebserverEnabled; }
       }

    }
}
