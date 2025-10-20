using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolaNHibernate.Mapeoak
{
    using ConsolaNHibernate.Modeloak;
    using FluentNHibernate.Mapping;

    public class ErabiltzaileaMap : ClassMap<Erabiltzailea>
    {
        public ErabiltzaileaMap()
        {
            Table("erabiltzaileak"); // ← Taularen izen erreala jarri
            Id(x => x.Id).Column("id").GeneratedBy.Identity();

            Map(x => x.ErabiltzaileIzena).Column("erabiltzailea").Length(20).Not.Nullable();
            Map(x => x.Izena).Column("izena").Length(20);
            Map(x => x.Sexua).Column("sexua").Length(1);
            Map(x => x.Maila).Column("maila");
            Map(x => x.Emaila).Column("emaila").Length(50);
            Map(x => x.Telefonoa).Column("telefonoa").Length(20);
            Map(x => x.Marka).Column("marka").Length(20);
            Map(x => x.Konpania).Column("konpania").Length(20);
            Map(x => x.Saldoa).Column("saldoa");
            Map(x => x.Aktibo).Column("actibo");

            HasOne(x => x.Helbidea)
                .Cascade.All()
                .PropertyRef("Erabiltzailea"); // Helbidea klaseko Erabiltzailea propietatearekin egiten da erlazioa

            /*
            | Aukera                       | Azalpena                                                                         |
            | ---------------------------- | -------------------------------------------------------------------------------- |
            | `.Cascade.None()`            | Ez du ezer egiten erlazionatutako objektuarekin.                                 |
            | `.Cascade.SaveUpdate()`      | `Save()` edo `Update()` ekintzak pasatzen ditu, baina ez `Delete()`.             |
            | `.Cascade.Delete()`          | Ezabatzeak bakarrik pasatzen dira.                                               |
            | `.Cascade.DeleteOrphans()`   | Gurasoa kenduta, umea ere ezabatzen da.                                          |                                   |
            | `.Cascade.AllDeleteOrphan()` | Ohikoena, guztia kudeatzen du eta orphan-ak ezabatzen ditu.                      |                                   |
            | `.Cascade.All()`             | Eragiketa guztiak egiteko balio du: save,update,delete,evict,lock,refresh.       |
            

            HasMany(x => x.Eskariak)
                .KeyColumn("erabiltzailea_id") // Zein zutabetan dagoen erlazioa adierazi
                .Inverse() // Alde batetik kudeatzen da harremana
                .Cascade.AllDeleteOrphan(); // Seme alabak sinkronizatzen ditu

            HasManyToMany(x => x.Rolak)
            .Table("erabiltzailea_rola")
            .ParentKeyColumn("erabiltzailea_id")
            .ChildKeyColumn("rola_id")
            .Cascade.All();

             */

            //.LazyLoad(false); // 🔹 carga inmediata BETI. Erabiltzaile bat kargatzen denean bere eskariak ere kargatuko dira


        }
    }

}
