using System;
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
        public dynamicxml()
        {

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
