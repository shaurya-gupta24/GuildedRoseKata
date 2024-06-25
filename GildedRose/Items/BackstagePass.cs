using System;

namespace GildedRoseKata.Items
{
    public class BackstagePass : CustomItem
    {
        public BackstagePass(Item item) : base(item)
        {
        }

        // method to update quality
        public override void UpdateQuality()
        {
            item.SellIn -= 1;
            var increase = 0;

            // after 'SellIn' date quality becomes 0.
            if (IsExpired())
            {
                item.Quality = MinQuality;
                return;
            }
            // when 'SellIn' date is less than 5 quality increases by 3.
            else if (item.SellIn < 5)
            {
                increase = 3;
            }
            // when 'SellIn' date is less than 10 but greater than 5, quality increases by 2.
            else if (item.SellIn < 10)
            {
                increase = 2;
            }
            // quality increases as 'SellIn' decreases.
            else
            {
                increase = 1;
            }

            // This caps quality at 50.
            item.Quality = Math.Min(item.Quality + increase, MaxQuality);
        }
    }
}
