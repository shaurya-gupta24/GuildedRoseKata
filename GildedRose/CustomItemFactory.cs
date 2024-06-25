using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GildedRoseKata
{
    internal static class CustomItemFactory
    {
        public static CustomItem CreateCustomItem(Item item)
        {
            var name = item.Name;

            switch (name)
            {
                case string a when a.Contains("Sulfuras"): return new Sulfuras(item);

                default: return new NormalItem(item);

            };
        }
    }
}
