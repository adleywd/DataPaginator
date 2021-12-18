namespace DataPaginator.Example.WebApi.Models
{
    /// <summary>
    /// The dog class
    /// </summary>
    public class Dog
    {
        /// <summary>
        /// Create a new Dog object
        /// </summary>
        public Dog()
        {

        }

        /// <summary>
        /// Create a new Dog object and initialize their fields
        /// </summary>
        /// <param name="id"></param>
        /// <param name="breed"></param>
        /// <param name="name"></param>
        public Dog(int id, string breed, string name)
        {
            Id = id;
            Breed = breed;
            Name = name;
        }

        /// <summary>
        /// The Id of dog entity
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The dog's breed
        /// </summary>
        public string Breed { get; set; }

        /// <summary>
        /// The dog's name
        /// </summary>
        public string Name { get; set; }

    }
}
