﻿/*
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

using System;

namespace PandoraKeys
{
    public class Song
    {
        private string _title = "no Title";
        private string _albumarturl = "/images/no_album_art.jpg";
        private string _artist = "no Artist";
        private string _albumtitle = "no Title";


        public string Title
        {
            get { return _title; }
            set { _title = value.Trim(); }
        }

        public string AlbumArtURL
        {
            get { return _albumarturl; }
            set { _albumarturl = value.Trim(); }
        }

        public string Artist
        {
            get { return _artist; }
            set { _artist = value.Trim(); }
        }

        public string AlbumTitle
        {
            get { return _albumtitle; }
            set { _albumtitle = value.Trim(); }
        }

        public int TimeRemaining { get; set; }

        public string TimeRemainingFmt
        {
            get
            {
                var time = TimeSpan.FromSeconds(TimeRemaining);
                return time.ToString("mm':'ss");
            }
        }

        public int ElapsedTime { get; set; }


        public override string ToString()
        {
            return String.Format("{0}:{1} {2}", Title, Artist, TimeRemainingFmt);
        }
    }
}
