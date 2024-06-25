namespace GildedRoseKata
{
    public class Sulfuras : CustomItem
    {
        public Sulfuras(Item item) : base(item)
        {
        }

        // no changes happen to Sulfuras items.
        public override void UpdateQuality()
        {
            return;
        }
    }
}
