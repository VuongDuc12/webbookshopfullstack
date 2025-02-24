public class Category 
{
    public int ID {get;set;}
    public string Name {get;set;}
    public ICollection<Product> Products {get;set;}
    

}