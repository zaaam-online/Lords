using System;
namespace Lords.City
{
    public class Seller
    {
        private ProductCategory _wool;
        private ProductCategory _meat;
        private ProductCategory _milk;
        private ProductCategory _grain;

        public Seller()
        {
        }

        public ProductCategory Wool { get => _wool; set => _wool = value; }
        public ProductCategory Meat { get => _meat; set => _meat = value; }
        public ProductCategory Milk { get => _milk; set => _milk = value; }
        public ProductCategory Grain { get => _grain; set => _grain = value; }
    }

}
