using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayerBD
{
    public interface IPocketDTO
    {
        int Id { get; set; }
        int RoundId { get; set; }
        int ToNumber { get; set; }
        int ToColorNumber { get; set; }
    }
}
