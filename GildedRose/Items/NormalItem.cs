using System;

namespace GildedRoseKata.Items
{
    public class NormalItem : CustomItem
    {

        internal int decrease = 1;

        public NormalItem(Item item) : base(item)
        {
        }

        public override void UpdateQuality()
        {
            item.SellIn -= 1;
            // when 'SellIn' date is less than 0, quality decreases at twice the rate.
            if (IsExpired())
            {
                item.Quality = Math.Max(item.Quality - decrease * 2, MinQuality);
            }
            // quality decreases as 'SellIn' decreases.
            else
            {
                item.Quality = Math.Max(item.Quality - decrease, MinQuality);
            }
        }

    }
}
