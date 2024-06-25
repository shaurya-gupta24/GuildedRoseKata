using GildedRoseKata.Items;

namespace GildedRoseKata
{
    internal static class CustomItemFactory
    {
        public static CustomItem CreateCustomItem(Item item)
        {
            var name = item.Name;

            switch (name)
            {
                case string a when a.Contains("Sulfuras"): return new Sulfuras(item);

                case string a when a.Contains("Aged Brie"): return new AgedBrie(item);

                case string a when a.Contains("Backstage pass"): return new BackstagePass(item);

                case string a when a.Contains("Conjured"): return new Conjured(item);

                default: return new NormalItem(item);

            };
        }
    }
}
