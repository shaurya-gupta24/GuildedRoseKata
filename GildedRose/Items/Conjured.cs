using System;

namespace GildedRoseKata.Items
{
    public class Conjured : NormalItem
    {

        public Conjured(Item item) : base(item)
        {
            decrease = 2;
        }
    }
}
