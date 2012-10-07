/*
 * Copyright (C) 2012 David W. Bullington, 
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
using System.Windows.Forms;

namespace PandoraKeys
{
    public class DynamicItems
    {
        public Station[] StationList { get; set; }

        public string Skin { get; set; }

        public Song Song { get; set; }

        public bool ThumbUp { get; set; }

        public bool Paused { get; set; }

        //Must be kept or XmlSerializer will throw an exception
        public DynamicItems()
        {
        }

        //This is called by the web server to get the current information and status of what is playing in the browser
        public DynamicItems(Player player)
        {

            StationList = player.Stations;
            Skin = player.Skin;
            Song = player.Song;
            ThumbUp = player.IsThumbsUp;
            Paused = player.IsPaused;
            
        }
    }
}
