using DataAccesFactory.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDataAccesFactory
{
    public class RepositoryFactory
    {
        public RepositoryFactory(string database)
        {

        }


        public static IRepository create(IServiceProvider serviceProvider)
        {
            return new InMemRepository();
        }

        public static InMemRepository CreateInMem()
        {
            return new InMemRepository();
        }

        //public static IRepository Create(string database)
        //{
        //    IRepository output = null;
        //    switch (database)
        //    {
        //        case "inmem":
        //            output = new InMemRepository();
        //            break;
        //        case "mysql":
        //            output = new MySqlRepository();
        //            break;
        //    }
        //    return output;
        //}
    }
}
