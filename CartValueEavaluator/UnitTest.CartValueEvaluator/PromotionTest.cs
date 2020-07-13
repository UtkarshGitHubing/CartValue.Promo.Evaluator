using System.Collections.Generic;
using CartValueEavaluator.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CartValueEavaluator.Promotions;
using UnitTest.CartValueEvaluator.MockData;

namespace UnitTest.CartValueEvaluator
{
  [TestClass]
  public class PromotionTest
  {
    private static Offers _offers = new Offers();

    [TestMethod]
    public void Validate_Default_Cart_Value()
    {
      //arrange
      List<UnitItem> mockInputItems = MockTestData.skuUnitItems;
      const int EXPECTED_CART_VALUE = MockTestData.OUTPUT_DEFAULT_CART;
      
      //Act
      int actualCartValue = _offers.DefaultCartTotal(mockInputItems);

      //Assert
      Assert.AreEqual(EXPECTED_CART_VALUE, actualCartValue);

    }

    [TestMethod]
    public void Validate_Promo_3As_For130()
    {
      //arrange
      List<UnitItem> mockInputItems = MockTestData.skuUnitItems;
      const int EXPECTED_CART_VALUE = MockTestData.OUTPUT_3A_PROMO;

      //Act
      int actualCartValue = _offers.Promo3AsFor130(mockInputItems);

      //Assert
      Assert.AreEqual(EXPECTED_CART_VALUE, actualCartValue);

    }

    [TestMethod]
    public void Validate_Promo2BsFor45()
    {
      //arrange
      List<UnitItem> mockInputItems = MockTestData.skuUnitItems;
      const int EXPECTED_CART_VALUE = MockTestData.OUTPUT_2B_PROMO;

      //Act
      int actualCartValue = _offers.Promo2BsFor45(mockInputItems);

      //Assert
      Assert.AreEqual(EXPECTED_CART_VALUE, actualCartValue);

    }

    [TestMethod]
    public void Validate_Promo_Cpuls_D_For30()
    {
      //arrange
      List<UnitItem> mockInputItems = MockTestData.skuUnitItems;
      const int EXPECTED_CART_VALUE = MockTestData.OUTPUT_C_PLUS_D_PROMO;

      //Act
      int actualCartValue = _offers.PromoCplusDfor30(mockInputItems);

      //Assert
      Assert.AreEqual(EXPECTED_CART_VALUE, actualCartValue);

    }
  }
}
