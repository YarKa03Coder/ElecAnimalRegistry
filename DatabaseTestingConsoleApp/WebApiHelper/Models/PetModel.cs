using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiHelper.Models
{
    /// <summary>
    /// Represents pet's personal information.
    /// </summary>
    public class PetModel
    {
        /// <summary>
        /// Id is used for identification each pet in Ukraine.
        /// </summary>
        public int UniqueID { get; set; }

        /// <summary>
        /// Pet's date of birth.
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Type of animal (like dog, cat, etc.).
        /// </summary>
        public string AnimalType { get; set; }

        /// <summary>
        /// Type of breed (like shepherd, bulldog, etc.).
        /// </summary>
        public string BreedType { get; set; }

        /// <summary>
        /// Male or Female.
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// Image path of pet in server machine to be displayed on screen.
        /// </summary>
        public string ImagePath { get; set; }

        /// <summary>
        /// Converts birthdate to short date string.
        /// </summary>
        public string ToShortStringBirthDate
        {
            get
            {
                return BirthDate.ToShortDateString();
            }
        }

        /// <summary>
        /// Represents age of pet in format y-m-d.
        /// </summary>
        public string AgeInStringFormat 
        { 
            get
            {
                // getting current date
                DateTime now = DateTime.Today;

                // difference in months and years between today's date and birthdate
                int months = now.Month - BirthDate.Month;
                int years = now.Year - BirthDate.Year;

                // decrease months difference if current day is less than birth day
                if (now.Day < BirthDate.Day)
                {
                    months--;
                }

                // decrease year difference if current month is negative
                // increase month difference by twelve
                if (months < 0)
                {
                    years--;
                    months += 12;
                }

                // adding months to birthdate, so current date and birthdate are 
                // on the same year and month, so we can find difference in days
                int days = (now - BirthDate.AddMonths(years * 12 + months)).Days;

                return toAgeInString(years, months, days);
            }
        }


        private string toAgeInString(int years, int months, int days)
        {
            string yearsInString = formatAnimalDataFields(years, "year");
            string monthInString = formatAnimalDataFields(months, "month");
            string dayInString   = formatAnimalDataFields(days, "day");

            List<string> dateFieldsList = new List<string>();

            if (yearsInString != "") dateFieldsList.Add(yearsInString);
            if (monthInString != "") dateFieldsList.Add(monthInString);
            if (dayInString   != "")   dateFieldsList.Add(dayInString);

            return string.Join(", ", dateFieldsList);
        }

        private string formatAnimalDataFields(int dataField, string dataFieldName)
        {
            string formattedDataField = "";

            if (dataField != 0)
            {
                if (dataField == 1)
                {
                    formattedDataField = $"{dataField} {dataFieldName}";
                }
                else
                {
                    formattedDataField = $"{dataField} {dataFieldName}s";
                }
            }

            return formattedDataField;
        }

    }
}
