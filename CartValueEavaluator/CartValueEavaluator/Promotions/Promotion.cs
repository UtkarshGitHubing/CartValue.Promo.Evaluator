namespace CartValueEavaluator.Promotions
{
  using Models;
  using System.Collections.Generic;
  using System.Linq;

  /// <summary>
  /// Defines the <see cref="Offers" />.
  /// </summary>
  public class Offers
  {
    /// <summary>
    /// The Promo3AsFor130.
    /// </summary>
    /// <param name="skuItems">The skuItems<see cref="List{UnitItem}"/>.</param>
    /// <returns>The <see cref="int"/>.</returns>
    public int Promo3AsFor130(List<UnitItem> skuItems)
    {
      int unitComboValue = 3;
      int promoUnitPrice = default;
      int unApplicablePrormoUnitsPrice = default;
      List<UnitItem> totalMatchingUnits = skuItems.FindAll(u => u.SkuId.Equals('A'));
      List<UnitItem> totalUnMatchingUnits = skuItems.FindAll(u => !u.SkuId.Equals('A'));
      if (totalMatchingUnits.Count >= unitComboValue)
      {
        promoUnitPrice = (totalMatchingUnits.Count / unitComboValue) * 130;
      }
      if (totalMatchingUnits.Count > unitComboValue)
      {
        unApplicablePrormoUnitsPrice = (totalMatchingUnits.Count % unitComboValue) * totalMatchingUnits[0].SkuPrice;
      }

      int totalCartValue = promoUnitPrice + unApplicablePrormoUnitsPrice + totalUnMatchingUnits.Sum(u => u.SkuPrice);

      return totalCartValue;
    }

    /// <summary>
    /// The Promo2BsFor45.
    /// </summary>
    /// <param name="skuItems">The skuItems<see cref="List{UnitItem}"/>.</param>
    /// <returns>The <see cref="int"/>.</returns>
    public int Promo2BsFor45(List<UnitItem> skuItems)
    {
      int unitComboValue = 2;
      int promoUnitPrice = default;
      int unapplicablePrormoUnitsPrice = default;
      List<UnitItem> totalMatchingUnits = skuItems.FindAll(u => u.SkuId.Equals('B'));
      List<UnitItem> totalUnMatchingUnits = skuItems.FindAll(u => !u.SkuId.Equals('B'));
      if (totalMatchingUnits.Count >= unitComboValue)
      {
        promoUnitPrice = (totalMatchingUnits.Count / unitComboValue) * 45;
      }
      if (totalMatchingUnits.Count > unitComboValue)
      {
        unapplicablePrormoUnitsPrice = (totalMatchingUnits.Count % unitComboValue) * totalMatchingUnits[0].SkuPrice;
      }

      int totalCartValue = promoUnitPrice + unapplicablePrormoUnitsPrice + totalUnMatchingUnits.Sum(u => u.SkuPrice);

      return totalCartValue;
    }

    /// <summary>
    /// The PromoCplusDfor30.
    /// </summary>
    /// <param name="skuItems">The skuItems<see cref="List{UnitItem}"/>.</param>
    /// <returns>The <see cref="int"/>.</returns>
    public int PromoCplusDfor30(List<UnitItem> skuItems)
    {
      int promoUnitPrice = default;
      int remainingCOrDUnitsPrice = default;
      List<UnitItem> totalMatchingCUnits = skuItems.FindAll(u => u.SkuId.Equals('C'));
      List<UnitItem> totalMatchingDUnits = skuItems.FindAll(u => u.SkuId.Equals('D'));
      List<UnitItem> totalUnMatchingUnits = skuItems.FindAll(u => !u.SkuId.Equals('D') && !u.SkuId.Equals('C'));

      int quantityOfC = totalMatchingCUnits.Count;
      int quantityOfD = totalMatchingDUnits.Count;

      promoUnitPrice = (quantityOfC < quantityOfD)
        ? quantityOfC * 30
        : quantityOfD * 30;

      remainingCOrDUnitsPrice = (quantityOfC < quantityOfD) ?
        (quantityOfD - quantityOfC) * totalMatchingDUnits[0].SkuPrice :
        (quantityOfC - quantityOfD) * totalMatchingCUnits[0].SkuPrice;

      int totalCartValue = promoUnitPrice + remainingCOrDUnitsPrice + totalUnMatchingUnits.Sum(u => u.SkuPrice);
      return totalCartValue;
    }

    /// <summary>
    /// The DefaultCartTotal.
    /// </summary>
    /// <param name="skuIdItems">The skuIdItems<see cref="List{UnitItem}"/>.</param>
    /// <returns>The <see cref="int"/>.</returns>
    public int DefaultCartTotal(List<UnitItem> skuIdItems)
    {
      return skuIdItems.Sum(sku => sku.SkuPrice);
    }
  }
}
