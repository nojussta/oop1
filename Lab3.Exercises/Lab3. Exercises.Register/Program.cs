using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Exercises.Register
{
    class Program
    {
        static void Main(string[] args)
        {
            DogsContainer allDogs = InOutUtils.ReadDogs(@"Dogs.csv");
            allDogs.Sort();
            InOutUtils.PrintDogs("Konteinerio informacija: ", allDogs);
            Console.WriteLine("Iš viso šunų: {0}", allDogs.Count);
            Console.WriteLine("Patinų: {0}", allDogs.CountByGender(Gender.Male));
            Console.WriteLine("Patelių: {0}", allDogs.CountByGender(Gender.Female));
            Console.WriteLine();

            Dog oldest = allDogs.FindOldestDog();
            Console.WriteLine("Seniausias šuo: ");
            Console.WriteLine("Vardas: {0}, Veislė: {1}, Amžius: {2}", oldest.Name, oldest.Breed, oldest.Age);
            Console.WriteLine();

            List<string> Breeds = allDogs.FindBreeds();
            Console.WriteLine("Šunų veislės:");
            InOutUtils.PrintBreeds(Breeds);
            Console.WriteLine();

            Console.WriteLine("Kokios veislės šunis atrinkti?");
            string selectedBreed = "Taksas";
            Console.WriteLine(selectedBreed);
            DogsContainer filteredByBreed = allDogs.FilterByBreed(selectedBreed);
            InOutUtils.PrintDogs("Atrinkti šunys:", filteredByBreed);
            Console.WriteLine();

            Dog SelectOldest = allDogs.FindOldestDog(selectedBreed);
            Console.WriteLine("Seniausias pasirinktos veislės šuo");
            Console.WriteLine("Vardas: {0}, Veislė: {1}, Amžius: {2}", SelectOldest.Name, SelectOldest.Breed, SelectOldest.Age);
            Console.WriteLine();

            string PopularBreed = allDogs.FindPopularBreed(Breeds, Breeds.Count);
            Console.WriteLine("Populiariausia šuns veislė: {0}", PopularBreed);
            Console.WriteLine();

            List<Vaccination> VaccinationsData = InOutUtils.ReadVaccinations(@"Vaccinations.csv");
            allDogs.UpdateVaccinationsInfo(VaccinationsData);

            DogsContainer requiresVaccination = allDogs.FilterByVaccinationExpired();
            Console.WriteLine("Šie šunys yra nevakcinuoti arba jų vakcinacija yra pasibaigusi: ");
            InOutUtils.PrintDogs("Reikalingos vakcinacijos informacija: ", requiresVaccination);
            Console.WriteLine();

            InOutUtils.PrintDogs("Reikia skiepyti: " + selectedBreed , requiresVaccination.Intersect(filteredByBreed));

            allDogs.Put(allDogs.Get(1), 13);
            InOutUtils.PrintDogs("Put patikrinimas:", allDogs);
            allDogs.Add(allDogs.Get(3));
            allDogs.Insert(allDogs.Get(1), 14);
            InOutUtils.PrintDogs("Insert/Add patikrinimas:", allDogs);

            allDogs.Remove(allDogs.Get(2)); 
            allDogs.RemoveAt(14);
            InOutUtils.PrintDogs("Remove/RemoveAt patikrinimas:", allDogs);

            DogsContainer allDogsCopy = new DogsContainer(allDogs);
            InOutUtils.PrintDogs("Kopijuoto konteinerio informacija: ", allDogsCopy);
        }
    }
}
