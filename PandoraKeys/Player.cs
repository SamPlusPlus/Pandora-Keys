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
using System.Linq;
using System.Text;
using PandoraKeys.Win32;
using System.Windows.Forms;


namespace PandoraKeys
{
    class Player
    {

        int hwndPandorPlayer;
        int browserHandle;
        Boolean located = false;
        public Player(IntPtr controlHandle)
        {
            browserHandle = (int)controlHandle;
        }


        public void LocatePlayer()
        {
            //Locates the Flash Element located inside the browser control
            if (located)
            {
                return;
            }
            else
            {
                int hShellEmbedding = User32.FindWindowEx(browserHandle, 0, "Shell Embedding", null);
                int hShellDocObjectView = User32.FindWindowEx(hShellEmbedding, 0, "Shell DocObject View", null);
                int hInternetExplorerServer = User32.FindWindowEx(hShellDocObjectView, 0, "Internet Explorer_Server", null);
                hwndPandorPlayer = User32.FindWindowEx(hInternetExplorerServer, hwndPandorPlayer, "MacromediaFlashPlayerActiveX", null);
                if (hwndPandorPlayer != 0)
                {
                    located = true;
                }
            }
        }

        public Boolean Located{
            get { return located; }
        }

        //Player Contorls
        /* Sends the following key strokes to the flash element inside the browser contorl
         * These shortcut keys are found on Pandora's site
         * http://blog.pandora.com/faq/contents/224.html
         * spacebar: Toggle Play / Pause
         * right-arrow: Skip to the Next Song
         * plus: I Like this Song
         * minus: I Don't Like this Song
         * up-arrow: Raise Volume
         * down-arrow: Lower Volume
         * shift + up-arrow: Full Volume
         * shift + down-arrow: Mute
         */


        public void PlayPause()
        {
            if (located)
            {
                User32.SendMessage(hwndPandorPlayer, WindowsMessageCode.WM_KEYDOWN, (int)Keys.Space, 0);
                User32.SendMessage(hwndPandorPlayer, WindowsMessageCode.WM_KEYUP, (int)Keys.Space, 0);
            }
        }

        public void NextTrack()
        {
            if (located)
            {
                User32.SendMessage(hwndPandorPlayer, WindowsMessageCode.WM_KEYDOWN, (int)Keys.Right, 0);
                User32.SendMessage(hwndPandorPlayer, WindowsMessageCode.WM_KEYUP, (int)Keys.Right, 0);
            }
        }

        public void Like()
        {
            if (located)
            {
                User32.SendMessage(hwndPandorPlayer, WindowsMessageCode.WM_KEYDOWN, (int)Keys.Add, 0);
                User32.SendMessage(hwndPandorPlayer, WindowsMessageCode.WM_KEYUP, (int)Keys.Add, 0);
            }
        }

        public void Dislike()
        {
            if (located)
            {
                User32.SendMessage(hwndPandorPlayer, WindowsMessageCode.WM_KEYDOWN, (int)Keys.Subtract, 0);
                User32.SendMessage(hwndPandorPlayer, WindowsMessageCode.WM_KEYUP, (int)Keys.Subtract, 0);
            }
        }

        public void VolumeUp()
        {
            if (located)
            {
                User32.SendMessage(hwndPandorPlayer, WindowsMessageCode.WM_KEYDOWN, (int)Keys.Up, 0);
                User32.SendMessage(hwndPandorPlayer, WindowsMessageCode.WM_KEYUP, (int)Keys.Up, 0);
            }
        }

        public void VolumeDown()
        {
            if (located)
            {
                User32.SendMessage(hwndPandorPlayer, WindowsMessageCode.WM_KEYDOWN, (int)Keys.Down, 0);
                User32.SendMessage(hwndPandorPlayer, WindowsMessageCode.WM_KEYUP, (int)Keys.Down, 0);
            }
        }

        public void FullVolume()
        {
            if (located)
            {
                User32.SendMessage(hwndPandorPlayer, WindowsMessageCode.WM_KEYDOWN, (int)(Keys.Shift), 0);
                User32.SendMessage(hwndPandorPlayer, WindowsMessageCode.WM_KEYDOWN, (int)(Keys.Up), 0);
                User32.SendMessage(hwndPandorPlayer, WindowsMessageCode.WM_KEYUP, (int)(Keys.Up), 0);
                User32.SendMessage(hwndPandorPlayer, WindowsMessageCode.WM_KEYUP, (int)(Keys.Shift), 0);
            }
        }

        public void Mute()
        {
            User32.SendMessage(hwndPandorPlayer, WindowsMessageCode.WM_KEYDOWN, (int)(Keys.Shift), 0);
            User32.SendMessage(hwndPandorPlayer, WindowsMessageCode.WM_KEYDOWN, (int)(Keys.Down), 0);
            User32.SendMessage(hwndPandorPlayer, WindowsMessageCode.WM_KEYUP, (int)(Keys.Down), 0);
            User32.SendMessage(hwndPandorPlayer, WindowsMessageCode.WM_KEYUP, (int)(Keys.Shift), 0);
        }
   
    }   
}
