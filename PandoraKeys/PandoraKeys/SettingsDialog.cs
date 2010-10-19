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
using System.Text;
using System.Windows.Forms;
using PandoraKeys.Properties;
using PandoraKeys.Utilities;


namespace PandoraKeys
{
    public partial class SettingsDialog : Form
    {

        public SettingsDialog()
        {
            InitializeComponent();
        }

        private void SettingsDialog_Load(object sender, EventArgs e)
        {        
            //Load the Keyboard Shortcuts Tab
            PlayPauseLabel.Text = Settings.Default.KeyboardPlayPause.ToString();
            NextTrackLabel.Text = Settings.Default.KeyboardNextTrack.ToString();
            LikeLabel.Text = Settings.Default.KeyboardLike.ToString();
            DislikeLabel.Text = Settings.Default.KeyboardDislike.ToString();
        
        }

        private void settingsSaveBtn_Click(object sender, EventArgs e)
        {             
            Settings.Default.Save();
            this.Close();
        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            Settings.Default.Reload();
            this.Close();

        }

    
        #region SetShortcutKeys
        private void PlayPauseSet_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Settings.Default.KeyboardPlayPause = SetShortCut(PlayPauseLabel);
        }

        private void NextTrackSet_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Settings.Default.KeyboardNextTrack = SetShortCut(NextTrackLabel);
        }

        private void LikeSet_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Settings.Default.KeyboardLike = SetShortCut(LikeLabel);
        }

        private void DislikeSet_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Settings.Default.KeyboardDislike = SetShortCut(DislikeLabel);
        }

     
        private Keys SetShortCut(Label l)
        {

            KeyCatcher kc = new KeyCatcher();
            if (kc.ShowDialog() == DialogResult.OK)
            {
                l.Text = kc.getShortCut().ToString();
            }

            return kc.getShortCut();

        } 
        #endregion
    }
}
