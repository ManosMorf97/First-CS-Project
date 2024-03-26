using System;
using sub_products;
namespace device_products
{
    public class Mobile_Phone(string name, float price, int year, float ram, string constructor_type, string graphics_card) :
        DeviceProduct(name, price, year, ram, constructor_type, graphics_card)
    {
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj is not Mobile_Phone mb) return false;
            return Name == mb.Name;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    public class Gaming_Console(string name, float price, int year, float ram, string constructor_type, string graphics_card) :
        DeviceProduct(name, price, year, ram, constructor_type, graphics_card)
    {
        public override bool Equals(object? obj) {
            if (obj == null) return false;
            if (obj is not Mobile_Phone mb) return false;
            return Name == mb.Name;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }


}