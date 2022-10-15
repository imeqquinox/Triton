using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private Dictionary<ItemData, Item> itemDictionary;
    public List<Item> items { get; private set; }

    public Inventory()
    {
        items = new List<Item>();
        itemDictionary = new Dictionary<ItemData, Item>(); 
    }

    public Item Get(ItemData referenceData)
    {
        if (itemDictionary.TryGetValue(referenceData, out Item value))
        {
            return value; 
        }

        return null; 
    }

    public void Add(ItemData referenceData)
    {
        // Check if item already exists
        if (itemDictionary.TryGetValue(referenceData, out Item value))
        {
            value.AddToStack(); 
        } 
        else
        {
            // New item to inventory
            Item newItem = new Item(referenceData);
            items.Add(newItem);
            itemDictionary.Add(referenceData, newItem); 
        }
    }

    public void Remove(ItemData referenceData)
    {
        if (itemDictionary.TryGetValue(referenceData, out Item value))
        {
            value.RemoveFromStack(); 

            if (value.stackSize == 0)
            {
                items.Remove(value);
                itemDictionary.Remove(referenceData); 
            }
        }
    }
}
