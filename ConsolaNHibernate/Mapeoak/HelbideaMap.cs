using ConsolaNHibernate.Modeloak;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolaNHibernate.Mapeoak
{

    public class HelbideaMap : ClassMap<Helbidea>
    {
        public HelbideaMap()
        {
            Table("Helbideak");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Kalea);
            Map(x => x.Hiria);
            Map(x => x.Herrialdea);

            References(x => x.Erabiltzailea) //FK-a sortzen du atzetik
                .Column("erabiltzailea_id") // Erabiltzailea propietatea DBko erabiltzaileaId zutabearekin lotzen da
                .Unique(); // One-to-one harremana bermatzeko
        }
    }
}
