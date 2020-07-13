using System;
using System.Collections.Generic;
using System.Text;
using CartValueEavaluator.Models;

namespace UnitTest.CartValueEvaluator.MockData
{
  public static class MockTestData
  {
    public static List<UnitItem> skuUnitItems = new List<UnitItem>
    {
      new UnitItem
      {
        SkuId = 'A',
        SkuPrice = 50
      },
      new UnitItem
      {
        SkuId = 'A',
        SkuPrice = 50
      },
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

    public const int OUTPUT_DEFAULT_CART = 280;
    public const int OUTPUT_3A_PROMO = 260;
    public const int OUTPUT_2B_PROMO = 265;
    public const int OUTPUT_C_PLUS_D_PROMO = 270;

  }
}
