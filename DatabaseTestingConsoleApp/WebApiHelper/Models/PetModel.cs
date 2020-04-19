using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiHelper.Models
{
    public class PetModel
    {
        public int UniqueID { get; set; }
        public DateTime BirthDate { get; set; }
        public string AnimalType { get; set; }
        public string BreedType { get; set; }
        public string Gender { get; set; }
        public string ImagePath { get; set; }

        public string AgeInStringFormat 
        { 
            get
            {
                DateTime now = DateTime.Today;

                int months = now.Month - BirthDate.Month;
                int years = now.Year - BirthDate.Year;

                if (now.Day < BirthDate.Day)
                {
                    months--;
                }

                if (months < 0)
                {
                    years--;
                    months += 12;
                }

                int days = (now - BirthDate.AddMonths(years * 12 + months)).Days;

                return String.Format("{0} year{1}, {2} month{3}, {4} day{5}",
                                      years,  (years == 1) ? "" : "s",
                                      months, (months == 1) ? "" : "s",
                                      days,   (days == 1) ? "" : "s");
            }
        }
    }
}
