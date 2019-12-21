using InterfaceLayerBD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.DAL.MYSQL.Result
{
    // Might rename to PocketDTO, since this is used in the business logic
    public class PocketDTO : IPocketDTO
    {
        public int Id { get; set; }
        public int RoundId { get; set; }
        public int ToNumber { get; set; }
        public int ToColorNumber { get; set; }

    }
}
