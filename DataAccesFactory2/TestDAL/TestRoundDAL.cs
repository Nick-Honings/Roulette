using InterfaceLayerBD;
using InterfaceLayerBD.Round;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesFactory2.TestDAL
{
    public class TestRoundDAL
    {
        private List<IRoundDTO> rounds;

        public TestRoundDAL()
        {
            //rounds = TestDB.ReturnRoundTable();
        }

        public bool Save(IRoundDTO dto)
        {
            rounds.Add(dto);
            return true;
        }

        public bool SavePocket(IPocketDTO dto)
        {
            throw new NotImplementedException();
        }

        public bool Update(IRoundDTO dto)
        {
            int index = rounds.FindIndex(i => i.Id == dto.Id);
            rounds[index] = dto;
            return true;
        }
    }
}
