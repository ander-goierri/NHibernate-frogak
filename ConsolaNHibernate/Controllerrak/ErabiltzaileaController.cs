using ConsolaNHibernate.Modeloak;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolaNHibernate.Controllerrak
{
    public class ErabiltzaileaController
    {
        public void ErabiltzaileaSortu(Erabiltzailea erabiltzaileBerria)
        {
            using (var session = NHibernateHelper.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.Save(erabiltzaileBerria);
                transaction.Commit();
            }
        }

        public void ErabiltzaileaEguneratu(Erabiltzailea eguneratutakoErabiltzailea)
        {
            using (var session = NHibernateHelper.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.Update(eguneratutakoErabiltzailea);
                transaction.Commit();
            }
        }

        public void ErabiltzaileaEzabatu(int idErabiltzailea)
        {
            using (var session = NHibernateHelper.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                var erabiltzailea = session.Get<Erabiltzailea>(idErabiltzailea);
                if (erabiltzailea != null)
                {
                    session.Delete(erabiltzailea);
                    transaction.Commit();
                }
            }
        }

        public IList<Erabiltzailea> ErabiltzaileakLortu()
        {
            using (var session = NHibernateHelper.OpenSession())
            {

                return session.Query<Erabiltzailea>().ToList();
            }
        }

        public Erabiltzailea ErabiltzaileaLortu(int idErabiltzailea)
        {
            return ErabiltzaileaLortu(idErabiltzailea, false);
        }

        public Erabiltzailea ErabiltzaileaLortu(int idErabiltzailea, bool withEskariak)
        {
            return ErabiltzaileaLortu(idErabiltzailea, withEskariak, false);
        }

        public Erabiltzailea ErabiltzaileaLortu(int idErabiltzailea, bool withEskariak, bool withRolak)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var erabiltzailea = session.Get<Erabiltzailea>(idErabiltzailea);
                // Lazily load eskariak ez emateko (defektuz erabiltzaileak bere eskariak ez ditu kargatzen)
                //Honekin beti kargatuko ditu (beste modu bat dago mapeoan)
                if (withEskariak) { 
                    NHibernateUtil.Initialize(erabiltzailea.Eskariak);
                }

                if (withRolak)
                {
                    NHibernateUtil.Initialize(erabiltzailea.Rolak);
                }

                return erabiltzailea;
            }
        }

        public IList<Erabiltzailea> ErabiltzaileaLortuMailaEtaAktiboagatik(Byte maila, bool aktibo)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Query<Erabiltzailea>()
                              .Where(u => u.Maila == maila && u.Aktibo == aktibo)
                              .ToList();
            }
        }


    }
}
