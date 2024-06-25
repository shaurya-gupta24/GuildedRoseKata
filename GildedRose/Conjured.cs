using System;

namespace GildedRoseKata
{
    public class Conjured : CustomItem
    {
        public Conjured(Item item) : base(item)
        {
        }

        public override void UpdateQuality()
        {
            item.SellIn -= 1;
            // when 'SellIn' date is less than 0, quality decreases at twice the rate.
            if (IsExpired())
            {
                item.Quality = Math.Max(item.Quality - 4, MinQuality);
            }
            // quality decreases as 'SellIn' decreases.
            else
            {
                item.Quality = Math.Max(item.Quality - 2, MinQuality);
            }
        }
    }
}
