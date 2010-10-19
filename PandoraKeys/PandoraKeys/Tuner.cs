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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PandoraKeys.Utilities;
using PandoraKeys.Properties;

namespace PandoraKeys
{
    public partial class Tuner : Form
    {
        Player player;
        UserActivityHook actHook;

        public Tuner()
        {
            InitializeComponent();
            player = new Player(PandoraBrowser.Handle);
            locator.Enabled = true;

            //Setup
            //Start Keyboard Hook
            try
            {
                actHook = new UserActivityHook();
                actHook.KeyDown += new KeyEventHandler(MyKeyDown);
                actHook.Start();
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
                player.PlayPause();
            }
            //Next Track
            else if (e.KeyCode.Equals(Keys.MediaNextTrack) || e.KeyData.Equals(Settings.Default.KeyboardNextTrack))
            {
                player.NextTrack();
            }
            //Like
            else if (e.KeyData.Equals(Settings.Default.KeyboardLike))
            {
                player.Like();
            }
            //Dislike;
            else if (e.KeyData.Equals(Settings.Default.KeyboardDislike))
            {
                player.Dislike();

            }
        
        }
        #endregion

        #region ContextMenu
        //Context Menu
        private void playPauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            player.PlayPause();
        }
        
        private void nextTrackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            player.NextTrack();
        }

        private void likeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            player.Like();
        }

        private void dislikeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            player.Dislike();
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
        
        private void locator_Tick(object sender, EventArgs e)
        {
            //Timer Hack will keep checking until flash element is loaded into browser control.           
            if (player.Located)
            {
                locator.Enabled = false;
            }
            else
            {
                player.LocatePlayer();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Pandora Keys is currently a Proof of Concept \nBased on Open Pandora By Eitan Pogrebizsky. \nCoded by Samuel Haddad");
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
      
    }
}
