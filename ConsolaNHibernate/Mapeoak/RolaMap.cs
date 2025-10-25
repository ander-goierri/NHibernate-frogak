using ConsolaNHibernate.Modeloak;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolaNHibernate.Mapeoak
{
    public class RolaMap : ClassMap<Rola>
    {
        public RolaMap()
        {
            Table("Rolak");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Izena);

            HasManyToMany(x => x.Erabiltzaileak)
                .Table("erabiltzailea_rola")
                .ParentKeyColumn("rola_id")
                .ChildKeyColumn("erabiltzailea_id")
                .Inverse(); // duplizidadeak ez izateko. Hau EZ daukana izango da harremanaren jabea (horregatik dago Cascadea Erabiltzailean)
        }
    }
}
