using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsolaNHibernate.Modeloak;

namespace ConsolaNHibernate.Controllerrak
{
    public class HelbideaController
    {
      
        public IList<Helbidea> HelbdieakLortu()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Query<Helbidea>().ToList();
            }
        }

        public Helbidea HelbideaLortu(int idHelbidea)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Get<Helbidea>(idHelbidea);
            }
        }



    }
}
