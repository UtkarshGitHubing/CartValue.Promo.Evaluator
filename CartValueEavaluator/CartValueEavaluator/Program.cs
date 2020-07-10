using System.Threading;
using CartValueEavaluator.Promotions;

namespace CartValueEavaluator
{
  using Helper;
  using Models;
  using System;
  using System.Collections;
  using System.Collections.Generic;

  /// <summary>
  /// Defines the <see cref="Program" />.
  /// </summary>
  internal static class Program
  {
    /// <summary>
    /// The Promotion.
    /// </summary>
    /// <param name="skuItems">The skuItems<see cref="List{UnitItem}"/>.</param>
    /// <returns>The <see cref="int"/>.</returns>
    public delegate int Promotion(List<UnitItem> skuItems);

    /// <summary>
    /// Defines the SkuItemsTable.
    /// </summary>
    internal static readonly Hashtable SkuItemsTable = new Hashtable();

    /// <summary>
    /// The Main.
    /// </summary>
    /// <param name="args">The args<see cref="string[]"/>.</param>
    internal static void Main(string[] args)
    {
      try
      {
        string tryAgain = "Y";
        HelperMethods.DisplayAvailableUnitItems();
        while (tryAgain.Trim().ToUpper().Equals("Y"))
        {
          start:
          List<UnitItem> skuItemsList = HelperMethods.SelectUnitItems(SkuItemsTable);
          if (skuItemsList.Count > 0)
          {
            int selection = HelperMethods.ReadChoiceFromActivePromos();
            Offers offers = new Offers();
            Promotion applyPromotion = offers.DefaultCartTotal;
            Promotion defaultPromotion = offers.DefaultCartTotal;
            Promotion newPromotion;
            // Apply Selected promotion : One Promotion applicable at one time
            switch (selection)
            {
              case 1:
                {
                  newPromotion = offers.Promo3AsFor130;
                  break;
                }
              case 2:
                {
                  newPromotion = offers.Promo2BsFor45;
                  break;
                }
              case 3:
                {
                  newPromotion = offers.PromoCplusDfor30;
                  break;
                }
              default:
                newPromotion = offers.DefaultCartTotal;
                break;
            }
            applyPromotion += newPromotion;

            // Or Add New Custom Promotion in future;
            // valid newPromo signature: int promoName(List<UnitItem> itemList);

            applyPromotion -= defaultPromotion;

            // Display Cart Final Value
            if (applyPromotion.GetInvocationList().Length > 0)
            {
              if (applyPromotion.GetInvocationList()[0].Equals(defaultPromotion.GetInvocationList()[0]))
              {
                Console.WriteLine($"Promo couldn't be applied your default cart value is: is: {applyPromotion(skuItemsList)}");
              }
              else
              {
                Console.WriteLine($"Final cart value after applying Promotion {applyPromotion.GetInvocationList()[0].Method.Name} is: {applyPromotion(skuItemsList)}");
              }
            }
            else
            {
              Console.WriteLine($"No such promotion could be applied your default cart value is: {defaultPromotion(skuItemsList)}");
            }
            Console.ReadKey();

          }
          else
          {
            Console.WriteLine("Please Select item in valid quantity");
            goto start;
          }
          Console.WriteLine("Try Again (y/n)?");
          tryAgain = Console.ReadLine();
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Oops!! encountered error:- {ex.Message}./n Please try again..exiting....");
      }
    }
  }
}
