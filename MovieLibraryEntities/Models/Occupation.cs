namespace MovieLibraryEntities.Models
{
    public class Occupation
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
