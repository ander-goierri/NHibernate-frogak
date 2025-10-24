using ConsolaNHibernate.Modeloak;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolaNHibernate.Mapeoak
{
    public class EskariaMap : ClassMap<Eskaria>
    {
        public EskariaMap()
        {
            Table("Eskariak");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Data);
            Map(x => x.Zenbatekoa);

            References(x => x.Erabiltzailea)
                .Column("erabiltzailea_id");
        }
    }
}
