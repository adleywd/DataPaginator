using DataPaginator.Example.WebApi.Data;
using DataPaginator.Example.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DataPaginator.Example.WebApi.Helpers
{
    public static class DatabaseGenerator
    {
        public static void Initializer(IServiceProvider serviceProvider)
        {
            var dbcontaxt = serviceProvider.GetRequiredService<DbContextOptions<DataContext>>();

            using (var context = new DataContext(dbcontaxt))
            {
                for (int i = 1; i <= 100; i++)
                {
                    context.Add(new Dog(i, GetRandomBreed(), GetRandomDogName()));
                }
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Return a random dog breed
        /// </summary>
        /// <returns></returns>
        private static string GetRandomBreed()
        {
            var breeds = new List<string> { "Labrador Retriever", "German Shepherd", "Golden Retriever", "Beagle", "Bulldog", "Yorkshire Terrier", "Boxer", "Poodle" };

            int index = new Random().Next(breeds.Count);
            var breed = breeds[index];
            return breed;
        }

        /// <summary>
        /// Return a random dog name
        /// </summary>
        /// <returns></returns>
        private static string GetRandomDogName()
        {
            var names = new List<string> { "Toby", "Max", "Cooper", "Adley", "Buddy", "Dog", "Echo", "Axel", "Tog", "Chip", "Caramelinho" };

            int index = new Random().Next(names.Count);
            var name = names[index];
            return name;
        }
    }
}
