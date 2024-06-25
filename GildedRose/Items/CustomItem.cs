namespace GildedRoseKata.Items
{
    public abstract class CustomItem
    {
        public Item item;
        public CustomItem(Item baseItem)
        {
            item = baseItem;
        }

        public abstract void UpdateQuality();

        internal static int MinQuality = 0;
        internal static int MaxQuality = 50;

        internal bool IsExpired() => item.SellIn < 0;
    }
}
