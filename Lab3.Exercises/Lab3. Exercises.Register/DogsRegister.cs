using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Exercises.Register
{
    class DogsRegister
    {
        private DogsContainer AllDogs;
        public DogsRegister()
        {
            AllDogs = new DogsContainer();
        }
        public DogsRegister(List<Dog> Dogs)
        {
            AllDogs = new DogsContainer();
            foreach (Dog dog in Dogs)
            {
                AllDogs.Add(dog);
            }
        }
        public void Add(Dog dog)
        {
            AllDogs.Add(dog);
        }
        public int DogCount()
        {
            return this.AllDogs.Count;
        }
        public Dog GetDogByIndex(int i)
        {
            return AllDogs.Get(i);
        }
        public int CountByGender(Gender gender)
        {
            int count = 0;
            for (int i = 0; i < AllDogs.Count; i++)
            {
                if (AllDogs.Get(i).Gender.Equals(gender))
                {
                    count++;
                }
            }
            return count;
        }
        public List<string> FindBreeds()
        {
            List<string> breeds = new List<string>();
            for (int i = 0; i < AllDogs.Count; i++)
            {
                if (!breeds.Contains(AllDogs.Get(i).Breed))
                {
                    breeds.Add(AllDogs.Get(i).Breed);
                }
            }
            return breeds;
        }
        public DogsContainer FilterByBreed(string breed)
        {
            DogsContainer filtered = new DogsContainer();
            for (int i = 0; i < AllDogs.Count; i++)
            {
                if (AllDogs.Get(i).Breed == breed)
                {
                    filtered.Add(AllDogs.Get(i));
                }
            }
            return filtered;
        }
        public Dog FindOldestDog()
        {
            return FindOldestDog(AllDogs);
        }
        public Dog FindOldestDog(string breed)
        {
            DogsContainer Filtered = FilterByBreed(breed);
            return FindOldestDog(Filtered);
        }
        private Dog FindOldestDog(DogsContainer Dogs)
        {
            Dog oldest = Dogs.Get(0);
            for (int i = 0; i < AllDogs.Count; i++)
            {
                if (oldest.BirthDate > AllDogs.Get(i).BirthDate)
                {
                    oldest = AllDogs.Get(i);
                }
            }
            return oldest;
        }
        private Dog FindDogByID(int ID)
        {
            for (int i = 0; i < AllDogs.Count; i++)
            {
                if (AllDogs.Get(i).ID == ID)
                {
                    return AllDogs.Get(i);
                }
            }
            return null;
        }
        public void UpdateVaccinationsInfo(List<Vaccination> Vaccinations)
        {
            foreach (Vaccination vaccination in Vaccinations)
            {
                Dog dog;
                if (FindDogByID(vaccination.DogID) != null)
                {
                    dog = FindDogByID(vaccination.DogID);
                    if (vaccination > dog.LastVaccinationDate)
                    {
                        dog.LastVaccinationDate = vaccination.Date;
                    }
                }
            }
        }
        public DogsContainer FilterByVaccinationExpired()
        {
            DogsContainer expired = new DogsContainer();
            for (int i = 0; i < AllDogs.Count; i++)
            {
                if (AllDogs.Get(i).RequiresVaccination)
                {
                    expired.Add(AllDogs.Get(i));
                }
            }
            return expired;
        }
        public bool Contains(Dog dog)
        {
            return AllDogs.Contains(dog);
        }
    }
}
