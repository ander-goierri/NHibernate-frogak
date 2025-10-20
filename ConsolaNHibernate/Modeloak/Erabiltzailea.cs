using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolaNHibernate.Modeloak
{
    public class Erabiltzailea
    {
        public virtual int Id { get; set; }
        public virtual string ErabiltzaileIzena { get; set; }
        public virtual string Izena { get; set; }
        public virtual string Sexua { get; set; }
        public virtual byte Maila { get; set; }
        public virtual string Emaila { get; set; }
        public virtual string Telefonoa { get; set; }
        public virtual string Marka { get; set; }
        public virtual string Konpania { get; set; }
        public virtual float Saldoa { get; set; }
        public virtual bool Aktibo { get; set; }

        public virtual Helbidea Helbidea { get; set; }  // ONE TO ONE harremana


    }
}
