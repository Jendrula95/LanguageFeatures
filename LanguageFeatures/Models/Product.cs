namespace LanguageFeatures.Models
{
    public class Product
    {
        private string name;
       
        public int ProductID { get; set; }
        public string Name { get { return  name; } set { name = value; } }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
    }
               
        
    }

