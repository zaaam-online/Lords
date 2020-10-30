using System;
namespace Lords.City
{
    public class Seller
    {
        private SellerCategory _wool;
        private SellerCategory _meat;
        private SellerCategory _milk;
        private SellerCategory _grain;

        public Seller()
        {
        }

        public SellerCategory Wool { get => _wool; set => _wool = value; }
        public SellerCategory Meat { get => _meat; set => _meat = value; }
        public SellerCategory Milk { get => _milk; set => _milk = value; }
        public SellerCategory Grain { get => _grain; set => _grain = value; }
    }

    public class SellerCategory
    {
        private string _name = string.Empty;
        private int _numberOfProduct = 0;
        private Date _dateOfPurchase;

        public string Name { get => _name; set => _name = value; }
        public int Product { get => _numberOfProduct; set => _numberOfProduct = value; }
        public Date DateOfPerchase { get => _dateOfPurchase; set => _dateOfPurchase = value; }
    }

    public enum Season { Spring, Sommer, Autumn, Winter };

    public class Date
    {
        private int _year = 0;
        private Season _season;

        public Season season
        {
            get { return _season; }
            set { _season = value; }
        }

        public int Year { get => _year; set => _year = value; }
        
    }
}
