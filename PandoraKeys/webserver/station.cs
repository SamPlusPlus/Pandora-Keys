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
using System;

namespace PandoraKeys
{
    public class station
    {
        private string _title;
        private Boolean _isselected;
        private Boolean _iscurrent;

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        public Boolean IsSelected
        {
            get { return _isselected; }
            set { _isselected = value; }
        }
        public Boolean IsCurrent
        {
            get { return _iscurrent; }
            set { _iscurrent = value; }
        }

    }
}
