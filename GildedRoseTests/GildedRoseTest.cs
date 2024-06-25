using System.Collections.Generic;
using GildedRoseKata;
using NUnit.Framework;

namespace GildedRoseTests;

public class GildedRoseTest
{
    [Test]
    public void UpdateQuality_NormalItem_ValueDecreases()
    {
        var NormalItem = new Item { Name = "normalItem", SellIn = 10, Quality = 10 };
        GildedRose.Items = new List<Item> {  NormalItem };
        GildedRose.UpdateQuality();
        Assert.That(NormalItem.Name, Is.EqualTo("normalItem"));
        Assert.That(NormalItem.Quality, Is.EqualTo(9));
        Assert.That(NormalItem.SellIn, Is.EqualTo(9));
    }

    [Test]
    public void UpdateQuality_NormalItem_ValueDecreases_ValueDoesNotGoNegative()
    {
        var NormalItem = new Item { Name = "normalItem", SellIn = 10, Quality = 10 };
        GildedRose.Items = new List<Item> { NormalItem };
        GildedRose.UpdateQuality();
        Assert.That(NormalItem.Name, Is.EqualTo("normalItem"));
        Assert.That(NormalItem.Quality, Is.EqualTo(9));
        Assert.That(NormalItem.SellIn, Is.EqualTo(9));
        UpdateQualityMultipleTimes(20);


        Assert.That(NormalItem.Quality, Is.EqualTo(0));
        Assert.That(NormalItem.SellIn, Is.EqualTo(-11));
    }

    [Test]
    public void UpdateQuality_NormalItem_ValueDecreases_ValueDecreasesAtDouble()
    {
        var NormalItem = new Item { Name = "normalItem", SellIn = 0, Quality = 10 };
        GildedRose.Items = new List<Item> { NormalItem };
        GildedRose.UpdateQuality();
        Assert.That(NormalItem.Name, Is.EqualTo("normalItem"));
        Assert.That(NormalItem.Quality, Is.EqualTo(8));
        Assert.That(NormalItem.SellIn, Is.EqualTo(-1));

        GildedRose.UpdateQuality();
        GildedRose.UpdateQuality();
        Assert.That(NormalItem.Quality, Is.EqualTo(4));
        Assert.That(NormalItem.SellIn, Is.EqualTo(-3));

    }

    [Test]
    public void UpdateQuality_BackStagePass_MoreThan10DaysLeft_QualityIncreasesNormally()
    {
        var testItem = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20 };
        GildedRose.Items = new List<Item>
            {
                testItem
            };

        GildedRose.UpdateQuality();

        Assert.That(testItem.Quality, Is.EqualTo(21));
        Assert.That(testItem.SellIn, Is.EqualTo(14));

        UpdateQualityMultipleTimes(3);

        Assert.That(testItem.Quality, Is.EqualTo(24));
        Assert.That(testItem.SellIn, Is.EqualTo(11));
    }

    [Test]
    public void UpdateQuality_BackStagePass_LessThan10DaysLeft_QualityIncreasesByTwo()
    {
        var testItem = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 9, Quality = 20 };
        GildedRose.Items = new List<Item>
            {
                testItem
            };


        GildedRose.UpdateQuality();

        Assert.That(testItem.Quality, Is.EqualTo(22));
        Assert.That(testItem.SellIn, Is.EqualTo(8));

        UpdateQualityMultipleTimes(3);

        Assert.That(testItem.Quality, Is.EqualTo(28));
        Assert.That(testItem.SellIn, Is.EqualTo(5));
    }

    [Test]
    public void UpdateQuality_BackStagePass_LessThan5DaysLeft_QualityIncreasesByThree()
    {
        var testItem = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 4, Quality = 20 };
        GildedRose.Items = new List<Item>
            {
                testItem
            };

        GildedRose.UpdateQuality();

        Assert.That(testItem.Quality, Is.EqualTo(23));
        Assert.That(testItem.SellIn, Is.EqualTo(3));

        UpdateQualityMultipleTimes(3);

        Assert.That(testItem.Quality, Is.EqualTo(32));
        Assert.That(testItem.SellIn, Is.EqualTo(0));
    }

    [Test]
    public void UpdateQuality_BackStagePass_NoDaysLeft_QualityIsZero()
    {
        var testItem = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 20 };
        GildedRose.Items = new List<Item>
            {
                testItem
            };

        GildedRose.UpdateQuality();

        Assert.That(testItem.Quality, Is.EqualTo(0));
        Assert.That(testItem.SellIn, Is.EqualTo(-1));

        UpdateQualityMultipleTimes(3);

        Assert.That(testItem.Quality, Is.EqualTo(0));
        Assert.That(testItem.SellIn, Is.EqualTo(-4));
    }

    [Test]
    public void UpdateQuality_BackStagePass_QualityIncreases_CannotExceed50()
    {
        var testItem = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 30, Quality = 49 };
        GildedRose.Items = new List<Item>
            {
                testItem
            };

        GildedRose.UpdateQuality();

        Assert.That(testItem.Quality, Is.EqualTo(50));
        Assert.That(testItem.SellIn, Is.EqualTo(29));

        UpdateQualityMultipleTimes(3);

        Assert.That(testItem.Quality, Is.EqualTo(50));
        Assert.That(testItem.SellIn, Is.EqualTo(26));
    }


    [Test]
    public void UpdateQuality_AgedBrie_QualityIncreases_SellInDecreases()
    {
        var testItem = new Item { Name = "Aged Brie", SellIn = 500, Quality = 20 };
        GildedRose.Items = new List<Item>
            {
                testItem
            };

        GildedRose.UpdateQuality();

        Assert.That(testItem.Quality, Is.EqualTo(21));
        Assert.That(testItem.SellIn, Is.EqualTo(499));

        UpdateQualityMultipleTimes(3);

        Assert.That(testItem.Quality, Is.EqualTo(24));
        Assert.That(testItem.SellIn, Is.EqualTo(496));
    }

    [Test]
    public void UpdateQuality_AgedBrie_ExpiryBelowZero_QualityIncreases()
    {
        var testItem = new Item { Name = "Aged Brie", SellIn = 0, Quality = 20 };
        GildedRose.Items = new List<Item>
            {
                testItem
            };

        GildedRose.UpdateQuality();

        Assert.That(testItem.Quality, Is.EqualTo(22));
        Assert.That(testItem.SellIn, Is.EqualTo(-1));

        UpdateQualityMultipleTimes(3);

        Assert.That(testItem.Quality, Is.EqualTo(28));
        Assert.That(testItem.SellIn, Is.EqualTo(-4));
    }

    [Test]
    public void UpdateQuality_AgedBrie_QualityIncreases_CannotExceedFifty()
    {
        var testItem = new Item { Name = "Aged Brie", SellIn = 0, Quality = 50 };
        GildedRose.Items = new List<Item>
            {
                testItem
            };

        GildedRose.UpdateQuality();

        Assert.That(testItem.Quality, Is.EqualTo(50));
        Assert.That(testItem.SellIn, Is.EqualTo(-1));

        UpdateQualityMultipleTimes(3);

        Assert.That(testItem.Quality, Is.EqualTo(50));
        Assert.That(testItem.SellIn, Is.EqualTo(-4));
    }

    [Test]
    public void UpdateQuality_Sulfuras_ExpiryDoesNotChange_QualityDoesNotIncrease()
    {
        var testItem = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 30, Quality = 20 };
        GildedRose.Items = new List<Item>
            {
                testItem
            };

        GildedRose.UpdateQuality();

        Assert.That(testItem.Quality, Is.EqualTo(20));
        Assert.That(testItem.SellIn, Is.EqualTo(30));

        UpdateQualityMultipleTimes(3);

        Assert.That(testItem.Quality, Is.EqualTo(20));
        Assert.That(testItem.SellIn, Is.EqualTo(30));
    }

    [Test]
    public void UpdateQuality_Sulfuras_ExpiryBelowZero_QualityDoesNotChange()
    {
        var testItem = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 20 };
        GildedRose.Items = new List<Item>
            {
                testItem
            };

        GildedRose.UpdateQuality();

        Assert.That(testItem.Quality, Is.EqualTo(20));
        Assert.That(testItem.SellIn, Is.EqualTo(0));

        UpdateQualityMultipleTimes(3);

        Assert.That(testItem.Quality, Is.EqualTo(20));
        Assert.That(testItem.SellIn, Is.EqualTo(0));
    }

    // doesn't work yet not implemented
    [Test]
    public void UpdateQuality_Conjured_ExpiryBelowZero_DecreasesByFour()
    {
        var testItem = new Item { Name = "conjured mana cake", SellIn = 0, Quality = 20 };
        GildedRose.Items = new List<Item>
            {
                testItem
            };

        GildedRose.UpdateQuality();

        Assert.That(testItem.Quality, Is.EqualTo(16));
        Assert.That(testItem.SellIn, Is.EqualTo(-1));

        UpdateQualityMultipleTimes(3);

        Assert.That(testItem.Quality, Is.EqualTo(4));
        Assert.That(testItem.SellIn, Is.EqualTo(-4));
    }

    // doesn't work yet not implemented
    [Test]
    public void UpdateQuality_Conjured_DecreasesByTwo()
    {
        var testItem = new Item { Name = "conjured mana cake", SellIn = 20, Quality = 20 };
        GildedRose.Items = new List<Item>
            {
                testItem
            };

        GildedRose.UpdateQuality();

        Assert.That(testItem.Quality, Is.EqualTo(18));
        Assert.That(testItem.SellIn, Is.EqualTo(19));

        UpdateQualityMultipleTimes(3);

        Assert.That(testItem.Quality, Is.EqualTo(12));
        Assert.That(testItem.SellIn, Is.EqualTo(16));
    }

    private void UpdateQualityMultipleTimes(int NumberOfTimes)
    {
        for (int i = 0; i < NumberOfTimes; i++) GildedRose.UpdateQuality();
    }
}