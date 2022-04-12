namespace ContosoPizza.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int UserTypeId { get; set; }
        public DateTime BirthDate { get; set; }
        public virtual UserType Role { get; set; }
    }

   
}
