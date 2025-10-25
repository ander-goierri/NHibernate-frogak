using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolaNHibernate.Modeloak
{
    public class Rola
    {
        public virtual int Id { get; set; }
        public virtual string Izena { get; set; }

        public virtual IList<Erabiltzailea> Erabiltzaileak { get; set; } = new List<Erabiltzailea>();
    }
}
