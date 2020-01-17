using InterfaceLayerBD.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDatabase.TestDatabase;

namespace TestDataAccesFactory.TestDAL
{
    public class TestAdminContainerDAL: IAdminContainerDAL
    {
        private List<IAdminDTO> admins;

        public TestAdminContainerDAL()
        {
            admins = TestDB.GetAdminTable();
        }
        public List<IAdminDTO> GetAllAdmins()
        {            
            return admins;
        }
    }
}
