using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Exercises.Register
{
    class DogsContainer
    {
        private Dog[] dogs;
        public int Count { get; private set; }

        private int Capacity;

        public DogsContainer(int capacity = 16)
        {
            this.Capacity = capacity;
            this.dogs = new Dog[capacity];
        }
        private void EnsureCapacity(int minimumCapacity)
        {
            if (minimumCapacity > this.Capacity)
            {
                Dog[] temp = new Dog[minimumCapacity];
                for (int i = 0; i < this.Count; i++)
                {
                    temp[i] = this.dogs[i];
                }
                this.Capacity = minimumCapacity;
                this.dogs = temp;
            }
        }
        public void Add(Dog dog)
        {
            if (this.Count == this.Capacity)
            {
                EnsureCapacity(this.Capacity * 10);
            }
            this.dogs[this.Count++] = dog;
        }
        public Dog Get(int index)
        {
            return this.dogs[index];
        }
        public bool Contains(Dog dog)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.dogs[i].Equals(dog))
                {
                    return true;
                }
            }
            return false;
        }
        public void Put(Dog dog, int i)
        {
            dogs[i] = dog;
        }
        public void Insert(Dog dog, int index)
        {
            Add(dogs[Count - 1]);
            for (int i = Count - 1; i > index; i--)
            {
                dogs[i] = dogs[i - 1];
            }
            Put(dog, index);
        }
        public void RemoveAt(int index)
        {
            for (int i = index; i < Count - 1; i++)
            {
                dogs[i] = dogs[i + 1];
            }
            Count--;
        }
        public void Remove(Dog dog)
        {
            for (int i = 0; i < Count; i++)
            {
                if (dogs[i].ID == dog.ID)
                {
                    for (int j = i; j < Count - 1; j++)
                    {
                        dogs[j] = dogs[j + 1];
                    }
                    Count--;
                    break;
                }
            }
        }
        public int CountByGender(Gender gender)
        {
            int count = 0;
            for (int i = 0; i < this.Count; i++)
            {
                if (this.dogs[i].Gender.Equals(gender))
                {
                    count++;
                }
            }

            return count;
        }
        public void Sort()
        {
            bool flag = true;
            while (flag)
            {
                flag = false;
                for (int i = 0; i < this.Count - 1; i++)
                {
                    Dog a = this.dogs[i];
                    Dog b = this.dogs[i + 1];
                    if (a.Gender > b.Gender || a.Gender == b.Gender && a.CompareTo(b) > 0)
                    {
                        this.dogs[i] = b;
                        this.dogs[i + 1] = a;
                        flag = true;
                    }
                }
            }
        }
        public Dog FindOldestDog()
        {
            Dog oldest = this.dogs[0];
            for (int i = 1; i < this.Count; i++)
            {
                if (DateTime.Compare(oldest.BirthDate, this.dogs[i].BirthDate) > 0)
                {
                    oldest = this.dogs[i];
                }
            }
            return oldest;
        }
        public Dog FindOldestDog(string breed)
        {
            DogsContainer Filtered = this.FilterByBreed(breed);
            Dog oldest = Filtered.Get(0);
            for (int i = 1; i < Filtered.Count; i++)
            {
                if (DateTime.Compare(oldest.BirthDate, Filtered.Get(i).BirthDate) > 0)
                {
                    oldest = Filtered.Get(i);
                }
            }
            return oldest;
        }

        public List<string> FindBreeds()
        {
            List<string> Breeds = new List<string>();
            for (int i = 0; i < this.Count; i++)
            {
                string breed = this.dogs[i].Breed;
                if (!Breeds.Contains(breed))
                {
                    Breeds.Add(breed);
                }
            }
            return Breeds;
        }

        public DogsContainer FilterByBreed(string breed)
        {
            DogsContainer Filtered = new DogsContainer();
            for (int i = 0; i < this.Count; i++)
            {
                if (this.dogs[i].Breed.Equals(breed))
                {
                    Filtered.Add(this.dogs[i]);
                }
            }
            return Filtered;
        }

        public int BreedCountMax(int[] BreedCount)
        {
            int max = BreedCount[0];
            int index = 0;
            for (int i = 1; i < BreedCount.Length; i++)
            {
                if (BreedCount[i] > max)
                {
                    max = BreedCount[i];
                    index = i;
                }
            }
            return index;
        }

        public string FindPopularBreed(List<string> Breeds, int BreedNumber)
        {
            int[] BreedCount = new int[BreedNumber];
            for (int i = 0; i < this.Count; i++)
            {
                for (int j = 0; j < BreedNumber; j++)
                {
                    if (this.dogs[i].Breed == Breeds[j])
                    {
                        BreedCount[j]++;
                    }
                }
            }
            return Breeds[BreedCountMax(BreedCount)];
        }
        private Dog FindDogByID(int ID)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.dogs[i].ID == ID)
                {
                    return this.dogs[i];
                }
            }
            return null;
        }
        public void UpdateVaccinationsInfo(List<Vaccination> Vaccinations)
        {
            foreach (Vaccination vaccination in Vaccinations)
            {
                for (int i = 0; i < this.Count; i++)
                    if (this.dogs[i].ID == vaccination.DogID)
                    {
                        Dog dog1 = this.FindDogByID(vaccination.DogID);
                        if (vaccination > this.dogs[i].LastVaccinationDate)
                        {
                            dog1.LastVaccinationDate = vaccination.Date;
                        }
                    }
            }
        }

        public DogsContainer FilterByVaccinationExpired()
        {
            DogsContainer updatedContainer = new DogsContainer();

            for (int i = 0; i < this.Count; i++)
            {
                if (this.dogs[i].RequiresVaccination)
                {
                    updatedContainer.Add(this.dogs[i]);
                }
            }
            return updatedContainer;
        }

        public DogsContainer(DogsContainer container) : this()
        {

            for (int i = 0; i < container.Count; i++)
            {
                this.Add(container.Get(i));
            }

        }

        public DogsContainer Intersect(DogsContainer other)
        {
            DogsContainer result = new DogsContainer();
            for (int i = 0; i < this.Count; i++)
            {
                Dog current = this.dogs[i];
                if (other.Contains(current))
                {
                    result.Add(current);
                }
            }
            return result;
        }
    }
}
