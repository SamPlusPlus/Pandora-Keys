/*
 * Copyright (C) 2010 David W. Bullington, 
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
namespace PandoraKeys
{
    public class song
    {
        private string _title = "no Title";
        private string _albumarturl = "/images/no_album_art.jpg";
        private string _artist = "no Artist";
        private string _albumtitle = "no Title";
        private int _timeremaning;
        private int _elapsedTime;


        public song()
        {
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }

        }

        public string AlbumArtURL
        {
            get { return _albumarturl; }
            set { _albumarturl = value; }

        }
        public string Artist
        {
            get { return _artist; }
            set { _artist = value; }
        }
        public string AlbumTitle
        {
            get { return _albumtitle; }
            set { _albumtitle = value; }
        }
        public int TimeRemaining
        {
            get { return _timeremaning; }
            set { _timeremaning = value; }
        }
        public int ElapsedTime { 
            get { return _elapsedTime; }
            set { _elapsedTime = value; }
        }
    }
}
