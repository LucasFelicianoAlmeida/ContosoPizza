namespace ContosoPizza.Models
{


    public class Pizza
    {
        public Pizza()
        {
            //Id = nextId++;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsGlutenFree { get; set; }
    }
}