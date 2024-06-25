using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseKata
{
    public class NormalItem : CustomItem
    {
        public NormalItem(Item item) : base(item)
        {
        }

        public override void UpdateQuality()
        {
            item.SellIn -= 1;
            // when 'SellIn' date is less than 0, quality decreases at twice the rate.
            if (IsExpired())
            {
                item.Quality = Math.Max(item.Quality - 2, MinQuality);
            }
            // quality decreases as 'SellIn' decreases.
            else
            {
                item.Quality = Math.Max(item.Quality - 1, MinQuality);
            }
        }

    }
}
