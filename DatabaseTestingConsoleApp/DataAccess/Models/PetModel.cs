using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    /// <summary>
    /// Represents information needed to know about pets
    /// </summary>
    public class PetModel
    {
        /// <summary>
        /// Each pet in Ukraine should have own unique id.
        /// </summary>
        public int UniqueID { get; set; }

        /// <summary>
        /// Pet's date of birth.
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Type of pet (dog, cat, etc.).
        /// </summary>
        public string AnimalType { get; set; }

        /// <summary>
        /// Animal subtype like shepherd, bulldog, poodle etc.
        /// </summary>
        public string BreedType { get; set; }

        /// <summary>
        /// Male or female.
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// Path to image in server that represents pet.
        /// </summary>
        public string ImagePath { get; set; }

    }
}
