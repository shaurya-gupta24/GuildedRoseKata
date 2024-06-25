using System;

namespace GildedRoseKata
{
    public class AgedBrie : CustomItem
    {
        public AgedBrie(Item item) : base(item)
        {
        }

        // method to update quality.
        public override void UpdateQuality()
        {
            item.SellIn -= 1;
            var increase = 0;
            // when past 'SellIn' date value increases by 2
            if (IsExpired())
            {
                increase = 2;
            }

            // value increases as cheese becomes older
            else
            {
                increase = 1;
            }

            // This caps quality at 50.
            item.Quality = Math.Min(item.Quality + increase, MaxQuality);
        }
    }
}
