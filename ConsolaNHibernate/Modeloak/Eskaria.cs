using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolaNHibernate.Modeloak
{
    public class Eskaria
    {
        public virtual int Id { get; set; }
        public virtual DateTime Data { get; set; }
        public virtual decimal Zenbatekoa { get; set; }

        public virtual Erabiltzailea Erabiltzailea { get; set; }
    }

}
