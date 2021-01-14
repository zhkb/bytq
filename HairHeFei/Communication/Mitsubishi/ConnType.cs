using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace IPOS.Equips.Connection
{
    public class ConnType
    {
        public ConnType()
        {
            this.Name = this.GetType().Namespace.Substring(this.GetType().Namespace.LastIndexOf(".") + 1);
            this.Connection = null;
        }
        public string Name { get; set; }
        public object Connection { get; set; }
    }

    public interface ConnConfig
    {
        ConnType SetConfig(ConnType connType);
        ConnType GetConfig(XmlNode node);
    }
}
