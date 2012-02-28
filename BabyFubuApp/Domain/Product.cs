namespace BabyFubuApp.Domain
{
    public class Product : DomainEntity
    {
        public Product(string name, int number, decimal price)
        {
            Name = name;
            Number = number;
            Price = price;
        }

        public virtual string Name { get; set; }
        public virtual int Number { get; set; }
        public virtual decimal Price { get; set; }
        public virtual string Description { get; set; }
    }
}