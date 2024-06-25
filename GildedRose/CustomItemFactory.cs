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
                case string Sulfuras when Sulfuras.Contains("Sulfuras"): return new Sulfuras(item);

                case string Brie when Brie.Contains("Aged Brie"): return new AgedBrie(item);

                case string Backstage when Backstage.Contains("Backstage pass"): return new BackstagePass(item);

                case string Conjured when Conjured.Contains("Conjured"): return new Conjured(item);

                default: return new NormalItem(item);

            };
        }
    }
}
