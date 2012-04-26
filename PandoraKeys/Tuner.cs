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
    public partial class Tuner : Form
    {
        UserActivityHook _actHook;
        WebServer _webserver;
        private static Log _log = null;

        public void stopLoging()
        {
            _webserver.logEnabled = false;
        }
        public dynamicitems getPitems()
        {
            dynamicitems pdi = new dynamicitems(PandoraBrowser);

            return pdi;
        }

        public Tuner()
        {
            InitializeComponent();
            Player._webBrowser = PandoraBrowser;
            
            // startup the Web Server
            try
            {
                _webserver = new WebServer();
                _webserver.logEnabled = false;
                _webserver.Port = Settings.Default.WebserverPort;
                _webserver.Start(this);
                this.Text = this.Text + " - " + _webserver.localAddr.ToString() + ":" + Settings.Default.WebserverPort.ToString();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error starting web server exception: " + e.Message);
            }

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


        #region Keyboard Hooks
        //Keyboard Hooks
        public void MyKeyDown(object sender, KeyEventArgs e)
        {

            //Play Pause
            if (e.KeyCode.Equals(Keys.MediaStop) || e.KeyCode.Equals(Keys.MediaPlayPause) || e.KeyData.Equals(Settings.Default.KeyboardPlayPause))
            {
                Player.PlayPause();
            }
            //Next Track
            else if (e.KeyCode.Equals(Keys.MediaNextTrack) || e.KeyData.Equals(Settings.Default.KeyboardNextTrack))
            {
                Player.Skip();
            }
            //Like
            else if (e.KeyData.Equals(Settings.Default.KeyboardLike))
            {
                Player.Like();
            }
            //Dislike;
            else if (e.KeyData.Equals(Settings.Default.KeyboardDislike))
            {
                Player.Dislike();

            }
        
        }
        #endregion

        #region ContextMenu
        //Context Menu
        private void playPauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Player.PlayPause();
        }
        
        private void nextTrackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Player.Skip();
        }

        private void likeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Player.Like();
        }

        private void dislikeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Player.Dislike();
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            toogleWindow();
        }
        #endregion

        private void toogleWindow()
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
            MessageBox.Show("Pandora Keys is a desktop wrapper for Pandora.com. \nCoded by Samuel Haddad\nExtended by David Bullington");
            //_player.message();
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
            toogleWindow();
        }

        private void Tuner_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                toogleWindow();
            }
        }

        private void Tuner_FormClosed(object sender, FormClosedEventArgs e)
        {
            _webserver.shutdown();
        }

        // start logging
        private void log_Click(object sender, EventArgs e)
        {

            _log = new Log();
            _log.Show();
            _log.setTuner(this);
            _webserver.Logger = _log;
            _webserver.logEnabled = true;
        }

    }
}
