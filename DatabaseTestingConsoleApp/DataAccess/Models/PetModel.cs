using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class PetModel
    {
        public int UniqueID { get; set; }
        public DateTime BirthDate { get; set; }
        public string AnimalType { get; set; }
        public string BreedType { get; set; }
        public string Gender { get; set; }
        public string ImagePath { get; set; }

    }
}
