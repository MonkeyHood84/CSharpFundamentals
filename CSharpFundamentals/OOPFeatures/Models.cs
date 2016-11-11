using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamentals.OOPFeatures
{

    public interface IIdentity
    {
        int Id { get; set; }
    }

    public abstract class AbstractedIdentity: IIdentity
    {
        public int Id { get; set; }
    }

    public interface IDish
    {
        string Name { get; set; }
        double Price { get; set; }

        double GetPrice();
        double GetPrice(bool terraceSuplement);
        double GetPrice(bool terraceSuplement, double discount);
        double GetPrice(double discount);
        double GetPrice(bool terraceSuplement, int discount);
        double GetPrice(int discount);
    }

    public abstract class AbstractDish : AbstractedIdentity, IDish
    {
        /* Data Abstraction: Abstract Class with relevant properties */
        public string Name { get; set; }
        public double Price { get; set; }

        public abstract double GetPrice();

        /* Static Polymorphism: Function Overloading */
        public double GetPrice(bool terraceSuplement)
        {
            //Add 20% supplement for Terrace Service
            return terraceSuplement ? this.GetPrice() * 1.2 : this.GetPrice();
        }
        public virtual double GetPrice(double discount) { return this.GetPrice(false, discount); }
        public virtual double GetPrice(bool terraceSuplement, double discount)
        {
            //MoneyOff: Discount in value which never can be negative
            return Math.Max(0, this.GetPrice(terraceSuplement) - discount);
        }
        public double GetPrice(int discount) { return this.GetPrice(false, discount); }
        public double GetPrice(bool terraceSuplement, int discount)
        {
            //Discount in percentage of the price.
            return this.GetPrice(terraceSuplement) * (1 - discount / 100f);
        }
    }

    /* Dynamic Polymorphism: Derived classes override base method  */
    public class ConcreteDishFull : AbstractDish, IDish
    {
        public override double GetPrice()
        {
            return this.Price;
        }
    }

    public class ConcreteDishHalf : AbstractDish, IDish
    {
        public override double GetPrice()
        {
            //half portion is 60% of the price
            return this.Price * 0.6;
        }
    }

    public class ConcreteDishTapa : AbstractDish, IDish
    {
        public bool WithDrink { get; set; }

        public override double GetPrice(bool terraceSuplement, double discount)
        {
            //money off discount is not applied to tapas
            return base.GetPrice(terraceSuplement);
        }
        public override double GetPrice() { return this.GetTapaPrice(); }
        private double GetTapaPrice()
        {
            //tapa cost 4 times less than the full dish
            double tapaPrice = this.Price * 0.25;
            //if it has come with a drink there is a 20% extra.
            tapaPrice = this.WithDrink ? tapaPrice * 1.2 : tapaPrice;
            return tapaPrice;
        }
    }

    public class NonAbstractedTapa
    {
        private bool _withDrink;

        public string Name { get; set; }
        public double Price { get; set; }
        public bool WithDrink
        {
            get { return this._withDrink; }
            set { this._withDrink = value; }
        }

        public double GetPrice() { return this.GetTapaPrice(); }

        private double GetTapaPrice()
        {
            //tapa cost 4 times less than the full dish
            double tapaPrice = this.Price * 0.25;
            //if it has come with a drink there is a 20% extra.
            tapaPrice = this.WithDrink ? tapaPrice * 1.2 : tapaPrice;
            return tapaPrice;
        }        
    }

    public class FunctionalDish
    {
        public double CalculateDishPrice(string dishName, double dishPrice, bool isHalfdish, bool isTapa,
            bool withDrink, bool hasTerraceSupl, double moneyoff, int percentageDiscount)
        {
            double price = dishPrice;
            if (isTapa)
            {
                //tapa cost 4 times less than the full dish
                price = price * 0.25;
                //if it has come with a drink there is a 20% extra.
                price = withDrink ? price * 1.2 : price;
                //apply discounts and charges
                if (hasTerraceSupl) { price = price * 1.2; }
                //tapas does not apply moneyoff discount
                if (percentageDiscount > 0) price = price * (1 - percentageDiscount / 100f);
            }
            else
            {
                if (isHalfdish)
                {
                    //half portion is 60% of the price
                    price = price * 0.6;
                }
                //apply discounts and charges
                if (hasTerraceSupl) { price = price * 1.2; }
                if (moneyoff > 0) { price = Math.Max(0, price - moneyoff); }
                else { if (percentageDiscount > 0) price = price * (1 - percentageDiscount / 100f); }
            }
            return price;
        }
    }
}
