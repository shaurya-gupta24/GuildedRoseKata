using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose
{
    public static IList<Item> Items;

    public GildedRose(IList<Item> Items)
    {
        GildedRose.Items = Items;
    }


    public static void UpdateQuality()
    {
        foreach(var item in GildedRose.Items)
        {
            var customItem = CustomItemFactory.CreateCustomItem(item);
            customItem.UpdateQuality();
        }
    }
}