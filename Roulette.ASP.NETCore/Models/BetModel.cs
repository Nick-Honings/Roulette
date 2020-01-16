using Roulette.Bets;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Roulette.ASP.NETCore.Models
{
    public class BetModel
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public int Odd { get; set; }
        public decimal Stake { get; set; }
        public BetType Type { get; set; }
        
        [Range(0, 36, ErrorMessage ="Please enter a valid number")]
        public int Number { get; set; }

        public Color Color { get; set; }

        [Display(Name = "Even/ uneven")]
        public bool IsEven { get; set; }

        [Range(0, 36, ErrorMessage = "Please enter a valid number")]
        public int? FirstNumber  { get; set; }

        
        [Range(0, 36, ErrorMessage = "Please enter a valid number")]
        public int? SecondNumber { get; set; }

        
    }
}
