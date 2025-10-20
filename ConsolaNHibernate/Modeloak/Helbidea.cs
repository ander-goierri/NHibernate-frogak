using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolaNHibernate.Modeloak
{
    public class Helbidea
    {
        public virtual int Id { get; set; }
        public virtual string Kalea { get; set; }
        public virtual string Hiria { get; set; }
        public virtual string Herrialdea { get; set; }

        public virtual Erabiltzailea Erabiltzailea { get; set; } //ONE TO ONE harremana

    }
}
