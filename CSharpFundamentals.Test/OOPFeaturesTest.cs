using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharpFundamentals.OOPFeatures;

namespace CSharpFundamentals.Test
{
    [TestClass]
    public class OOPFeaturesTest
    {
        [TestMethod]
        public void TestDataAbstraction()
        {
            /*** NOTE: Code commented is to avoid Compilation Errors ***/
            ConcreteDishTapa tapa = new ConcreteDishTapa();
            IDish dish = tapa;
            //Property Name and Price are accessible for both
            dish.Name = "Croquetas";
            dish.Price = 8;
            Assert.AreEqual(tapa.Name, "Croquetas");
            Assert.AreEqual(tapa.Price, 8);
            //Method GetPrice is accessible for both
            Console.WriteLine("dish price without drink" + dish.GetPrice());
            Console.WriteLine("tapa price without drink" + tapa.GetPrice());
            Assert.AreEqual(dish.GetPrice(), tapa.GetPrice());
            //Property WithDrink is NOT accessible as dish
            //dish.WithDrink = true;
            tapa.WithDrink = true;
            Console.WriteLine("dish price with drink" + dish.GetPrice());
            Console.WriteLine("tapa price with drink" + tapa.GetPrice());
            Assert.AreEqual(dish.GetPrice(), tapa.GetPrice());
        }

        [TestMethod]
        public void TestDataEncapsulation()
        {
            /*** NOTE: Code commented is to avoid Compilation Errors ***/
            NonAbstractedTapa tapa = new NonAbstractedTapa();
            //Property Name and Price are accessible
            tapa.Name = "Croquetas";
            tapa.Price = 8;
            //Method GetPrice is accessible
            Console.WriteLine("tapa price without drink" + tapa.GetPrice());
            Assert.AreEqual(tapa.GetPrice(), 2f);
            //Property _withDrink is NOT accessible
            //tapa._withDrink = true;
            //Need to get accessed by WithDrink getter
            tapa.WithDrink = true;
            //Method GetTapaPrice is NOT accessible
            //Console.WriteLine("tapa price with drink" + tapa.GetTapaPrice());
            //Only GetPrice function can be accessed to get the price
            Console.WriteLine("tapa price with drink" + tapa.GetPrice());
            Assert.AreEqual(tapa.GetPrice(), 2,4f);
  
        }

        [TestMethod]
        public void TestPolimorphismFuncOverloading()
        {
            ConcreteDishTapa tapa = new ConcreteDishTapa();
            tapa.Name = "Croquetas";
            tapa.Price = 8;
            //Call the same fucntion with diff behaviour
            double terracePrice = tapa.GetPrice(true);
            double halfPrice = tapa.GetPrice(50);
            double poundDiscount = tapa.GetPrice(1.25f);
            Console.WriteLine("Terrace price: " + terracePrice);
            Console.WriteLine("Half price: " + halfPrice);
            Console.WriteLine("Pound discound: " + poundDiscount);
            Assert.AreEqual(terracePrice, 2,4f);
            Assert.AreEqual(halfPrice, 1f);
            Assert.AreEqual(poundDiscount, 0,75f);
        }

        [TestMethod]
        public void TestPolimorphismOperationOverloading()
        {
            // TODO
        }

        [TestMethod]
        public void TestPolimorphismDynamic()
        {
            IDish tapa = new ConcreteDishTapa();
            tapa.Name = "Croquetas";
            tapa.Price = 8;
            IDish dish = new ConcreteDishFull();
            dish.Name = "Croquetas";
            dish.Price = 8;            
            double normalDishPrice = dish.GetPrice();
            double normalTapaPrice = tapa.GetPrice();
            Assert.AreEqual(normalDishPrice, 8f);
            Assert.AreEqual(normalTapaPrice, 2f);
            //Call the same fucntion with same parameters 
            //on diff derived classes with diff behaviour
            double moneyoffDishPrice = dish.GetPrice(1f);
            double moneyoffTapaPrice = tapa.GetPrice(1f);
            Assert.AreEqual(moneyoffDishPrice, 7f);
            Assert.AreEqual(moneyoffTapaPrice, 2f);
            //tapas should not apply moneyoff discounts
            Assert.AreEqual(moneyoffTapaPrice, normalTapaPrice);
        }


        [TestMethod]
        public void TestInheritance()
        {
            /*** SINGLE INHERITANCE ***/ 
            //Tapa inherits attributes and methods from AbstractDish
            ConcreteDishTapa si_tapa = new ConcreteDishTapa();
            si_tapa.Name = "Croquetas";
            si_tapa.Price = 8;
            //Tapa inherits methods from AbstractDish
            //percentage discount is implemented ONLY in Abstract dish
            //and getprice is overriden in derived classes
            Assert.AreEqual(si_tapa.GetPrice(50), 1f);
            //An object of the derived class can be casted to it base class
            Assert.IsTrue(si_tapa is AbstractDish);

            /*** HIERARCHICAL INHERITANCE ***/
            //Tapa, halfdish and dish inherits from AbstractDish
            ConcreteDishTapa hi_tapa = new ConcreteDishTapa();
            ConcreteDishHalf hi_halfdish = new ConcreteDishHalf();
            ConcreteDishFull hi_dish = new ConcreteDishFull();
            Assert.IsTrue(hi_tapa is AbstractDish);
            Assert.IsTrue(hi_halfdish is AbstractDish);
            Assert.IsTrue(hi_dish is AbstractDish);

            /*** MULTILEVEL INHERITANCE ***/
            //Tapa inherits from AbstractDish 
            //which inherits from AbstractIdentity
            ConcreteDishTapa mi_tapa = new ConcreteDishTapa();
            mi_tapa.Id = 1;
            Assert.IsTrue(mi_tapa is AbstractDish);
            AbstractDish mi_dish = mi_tapa;
            Assert.IsTrue(mi_dish is AbstractedIdentity);
            Assert.IsTrue(mi_tapa is AbstractedIdentity);

            /*** MULTIPLE INHERITANCE ***/
            //AbstractDish inherits from AbstractIdentity and IDish
            ConcreteDishTapa mmi_tapa = new ConcreteDishTapa();
            Assert.IsTrue(mmi_tapa is IDish);
            Assert.IsTrue(mmi_tapa is AbstractedIdentity);
        }

    }
}
