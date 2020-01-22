using InterfaceLayerBD;
using InterfaceLayerBD.Bet;
using InterfaceLayerBD.Room;
using InterfaceLayerBD.Round;
using Roulette.DAL.MYSQL;
using Roulette.DAL.MYSQL.Bet;
using Roulette.DAL.MYSQL.Room;
using Roulette.DAL.MYSQL.Round;
using Roulette.GameStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDataAccesFactory
{
    public class RoomDependencies : IRoomDependencies
    {
        public IRoundDAL RoundDAL { get; private set; }
        public IUserDAL UserDAL { get; private set; }
        public IBetDAL BetDAL { get; private set; }
        public IRoomContainerDAL RoomContainerDAL { get; private set; }
        public IRoomDAL RoomDAL { get; private set; }

        public RoomDependencies(string connection)
        {
            this.RoomContainerDAL = new RoomDAL(connection);
            this.RoomDAL = new RoomDAL(connection);
            this.RoundDAL = new RoundDAL(connection);
            this.UserDAL = new UserDAL(connection);
            this.BetDAL = new BetDAL(connection);            
        }


    }
}
