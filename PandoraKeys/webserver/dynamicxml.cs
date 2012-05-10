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

using System.IO;
using System.Collections;
using System.Text;
using System.Xml;
using System.Xml.Serialization;


namespace PandoraKeys
{
    public class dynamicxml
    {
        private StringBuilder _xml;
        private static dynamicitems _pi;

        public string XML
        {
            get
            {
                return _xml.ToString();
            }

        }
  
        public dynamicxml(dynamicitems pi)
        {
            _pi = pi;
            _xml = new StringBuilder();
            AListWrapper wrapper = new AListWrapper();

            XmlSerializer mySerializer = new XmlSerializer(typeof(AListWrapper));
            StringWriter outStream = new StringWriter();
            mySerializer.Serialize(outStream, wrapper); 
            _xml.Append(outStream.ToString());
        }


        [XmlRoot("ControlData")]
        public class AListWrapper
        {
            [XmlElement(Type = typeof(song)),
            XmlElement(Type = typeof(dynamicitems)),
            XmlElement(Type = typeof(station))
            ]
            public ArrayList list = new ArrayList();

            public AListWrapper()
            {
                list.Add(_pi);
                
            }
        }


    }
}
