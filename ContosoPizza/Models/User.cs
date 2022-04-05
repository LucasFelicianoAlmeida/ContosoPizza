namespace ContosoPizza.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public TypeUser Role { get; set; }
    }

    public enum TypeUser
    {
        Employee,
        Client
    }
}
