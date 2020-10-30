using System;
namespace Lords.City
{
    public class Product
    {
        public Product()
        {
        }
    }

    public class ProductCategory
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
