using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.BusinessLogic
{
    using LogicLayer.BusinessObject;
    using LogicLayer.DataLogic;

    public class PersonInfoHandler
    {
        PersonDBAccess personalInfoDb = null;

        public PersonInfoHandler()
        {
            personalInfoDb = new PersonDBAccess();
        }

        public bool Insert(Person personinfo)
        {
            return personalInfoDb.Insert(personinfo);
        }

        public List<Person> GetAll()
        {
            return personalInfoDb.GetAll();
        }
    }
}
