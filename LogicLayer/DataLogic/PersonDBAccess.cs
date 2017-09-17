using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.DataLogic
{
    using System.Data;
    using System.Data.SqlClient;

    using LogicLayer.BusinessObject;

    public class PersonDBAccess
    {
        public bool Insert(Person personInfo)
        {
            SqlParameter[] parameters = new SqlParameter[]
                                            {
                                                new SqlParameter("@Id", personInfo.Id),
                                                new SqlParameter("@Name", personInfo.Name),
                                                new SqlParameter("@Email", personInfo.Email),
                                                new SqlParameter("@Mobile", personInfo.Mobile),
                                                new SqlParameter("@Address", personInfo.Address)
                                            };

            return SqlDBHelper.ExecuteNonQuery("personinfoinsert", CommandType.StoredProcedure, parameters);
        }

        public List<Person> GetAll()
        {
            List<Person> personalInfoList = null;

           
            using (DataTable table = SqlDBHelper.ExecuteSelectCommand("personinfoview", CommandType.StoredProcedure))
            {
                
                if (table.Rows.Count > 0)
                {
                   
                    personalInfoList = new List<Person>();

                   
                    foreach (DataRow row in table.Rows)
                    {
                        Person personalInfo = new Person();
                        personalInfo.Id = Convert.ToInt32(row["Id"]);
                        personalInfo.Name = row["Name"].ToString();
                        personalInfo.Email = row["Email"].ToString();
                        personalInfo.Mobile = row["Mobile"].ToString();
                        personalInfo.Address = row["Address"].ToString();

                        personalInfoList.Add(personalInfo);
                    }
                }
            }

            return personalInfoList;
        }
    }
}
