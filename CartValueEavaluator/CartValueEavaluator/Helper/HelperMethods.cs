using System.Runtime.CompilerServices;
using CartValueEavaluator.Models;

namespace CartValueEavaluator.Helper
{
  using System;
  using System.Collections;
  using System.Collections.Generic;

  /// <summary>
  /// Defines the <see cref="HelperMethods" />.
  /// </summary>
  public static class HelperMethods
  {
    /// <summary>
    /// The SelectUnitItems.
    /// </summary>
    /// <param name="allowedSelections">The allowedSelections<see cref="Hashtable"/>.</param>
    /// <returns>The <see cref="List{UnitItem}"/>.</returns>
    public static List<UnitItem> SelectUnitItems(Hashtable allowedSelections)
    {
      List<UnitItem> skuItemList = new List<UnitItem>();
      Dictionary<char, int> unitItems = new Dictionary<char, int>();
      string addmore = "y";

      Console.WriteLine("Enter Units from the aforementioned Sku item list and add their respective quantities(more than 0):");
      while (addmore.ToLower().Equals("y"))
      {
        char skuId = 'x'; int quantity = 0;
        int skuReadAttempt = 0;
        int quantityReadAttempt = 0;
      readSkuAgain:
        if (skuReadAttempt < 3)
        {
          Console.WriteLine("----------------------------------");
          Console.Write("UnitId: ");
          try
          {
            skuId = Convert.ToChar(Console.ReadLine().ToUpper());
            if (!allowedSelections.ContainsKey(skuId))
            {
              InvalidInput();
              skuReadAttempt++;
              goto readSkuAgain;
            }
          }
          catch (Exception e)
          {
            InvalidInput();
            skuReadAttempt++;
            goto readSkuAgain;
          }
        }
        else
        {
          Console.WriteLine("Entry not found!");
          break;
        }
      readQuantityAgain:
        if (quantityReadAttempt < 3)
        {
          Console.Write("Quantity: ");
          try
          {
            quantity = Convert.ToInt32(Console.ReadLine());
            if (quantity < 1)
            {
              throw new InvalidOperationException();
            }
          }
          catch (Exception e)
          {
            InvalidInput();
            quantityReadAttempt++;
            goto readQuantityAgain;
          }
        }
        else
        {
          Console.WriteLine("Invalid quantity!");
          break;
        }
        if (quantity > 0)
        {
          unitItems.Add(skuId, quantity);
        }
        Console.WriteLine("Add more units(n/y)?:");
        addmore = Console.ReadLine();
      }
      foreach (var unit in unitItems)
      {
        for (int i = 0; i < unit.Value; i++)
        {
          skuItemList.Add(new UnitItem { SkuId = unit.Key, SkuPrice = Convert.ToInt32(Program.SkuItemsTable[unit.Key]) });
        }
      }
      return skuItemList;
    }

    /// <summary>
    /// The InvalidInput.
    /// </summary>
    private static void InvalidInput()
    {
      Console.WriteLine("Invalid Input. Please try again!");
    }

    /// <summary>
    /// The PopulateSelectUnitItems.
    /// </summary>
    public static void DisplayAvailableUnitItems()
    {
      List<UnitItem> skuUnitList = new List<UnitItem>
      {
        new UnitItem
        {
          SkuId = 'A',
          SkuPrice = 50
        },
        new UnitItem
        {
          SkuId = 'B',
          SkuPrice = 30
        },
        new UnitItem
        {
          SkuId = 'C',
          SkuPrice = 20
        },
        new UnitItem
        {
          SkuId = 'D',
          SkuPrice = 15
        }
      };

      foreach (var skuUnit in skuUnitList)
      {
        Program.SkuItemsTable.Add(skuUnit.SkuId, skuUnit.SkuPrice);
      }
      Console.WriteLine("Available Sku Items:");
      Console.WriteLine("==============================================");
      foreach (var unit in skuUnitList)
      {
        Console.WriteLine($"SkuId: {unit.SkuId}  Price: {unit.SkuPrice}");
      }
      Console.WriteLine("==============================================");
    }

    /// <summary>
    /// The ReadChoiceFromActivePromos.
    /// </summary>
    /// <returns>The <see cref="int"/>.</returns>
    public static int ReadChoiceFromActivePromos()
    {
      int choice = 0;
      Console.WriteLine("Active Promotions:");
      Console.WriteLine("===================================");
      Console.WriteLine("1) 3A's for 130");
      Console.WriteLine("2) 2B's for 45");
      Console.WriteLine("3) C + D =30");
      Console.WriteLine("====================================");
      Console.WriteLine("Please select an offer to apply (1or 2 or 3):");
      try
      {
        choice = Convert.ToInt32(Console.ReadLine());
      }
      catch (Exception e)
      {
        Console.WriteLine("Invalid Choice: Promo won't be applicable");
        Console.WriteLine("============================================");
      }
      return choice;
    }
  }
}
