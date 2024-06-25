using System;

namespace GildedRoseKata
{
    public class Conjured : NormalItem
    {
        
        public Conjured(Item item) : base(item)
        {
            decrease = 2;
        }
    }
}
