using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Exercises.Register
{
    class Dog
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Breed { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public Dog(int id, string name, string breed, DateTime birthDate, Gender gender)
        {
            this.ID = id;
            this.Name = name;
            this.Breed = breed;
            this.BirthDate = birthDate;
            this.Gender = gender;
        }
        public int Age
        {
            get
            {
                DateTime today = DateTime.Today;
                int age = today.Year - this.BirthDate.Year;
                if (this.BirthDate.Date > today.AddYears(-age))
                {
                    age--;
                }
                return age;
            }
        }

        private const int VaccinationDuration = 1;
        public DateTime LastVaccinationDate { get; set; }
        public bool RequiresVaccination
        {
            get
            {
                if (LastVaccinationDate.Equals(DateTime.MinValue))
                {
                    return true;
                }
                return LastVaccinationDate.AddYears(VaccinationDuration)
                    .CompareTo(DateTime.Now) < 0;
            }
        }
        public override bool Equals(object other)
        {
            return this.ID == ((Dog)other).ID;
        }
        public override int GetHashCode()
        {
            return this.ID.GetHashCode();
        }
        public int CompareTo(Dog other)
        {
            return this.Breed.CompareTo(other.Breed);
        }
        public override string ToString()
        {
            return string.Format("| {0,8} | {1,-15} | {2,-15} | {3,-12:yyyy-MM-dd} | {4,-8} | ", ID, Name, Breed, BirthDate, Gender);
        }
    }
}
