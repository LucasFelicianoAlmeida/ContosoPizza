namespace ContosoPizza.Features.Pizzas.List
{
    public class ListPizzaResponse
    {
       
        public int Id {get;set;}
        public string Name {get; set;}
        public decimal Price { get; set; }
        public bool IsGlutenFree {get;set;}
    }
}