using InterfaceLayerBD;
using InterfaceLayerBD.Round;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDatabase.TestDatabase;

namespace TestDataAccesFactory.TestDAL
{
    public class TestRoundDAL : IRoundDAL, IRoundContainerDAL
    {
        private List<IRoundDTO> rounds;
        private List<IPocketDTO> pockets;

        public TestRoundDAL()
        {
            rounds = TestDB.GetRoundsTable();
            pockets = TestDB.GetPocketTable();
        }

        public IPocketDTO GetPocket(int id)
        {
            return pockets.Find(i => i.RoundId == id);
        }

        public bool Save(IRoundDTO dto)
        {
            rounds.Add(dto);
            return true;
        }

        public bool SavePocket(IPocketDTO dto)
        {
            pockets.Add(dto);
            return true;
        }

        public bool Update(IRoundDTO dto)
        {
            int index = rounds.FindIndex(i => i.Id == dto.Id);
            rounds[index] = dto;
            return true;
        }
    }
}
