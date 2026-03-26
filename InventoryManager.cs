using System.Collections.Generic;
using UnityEngine;
using System;

public class InventoryManager : MonoBehaviour
{
    public static event Action OnInventoryChanged;
    public List<InventoryItem> inventory = new List<InventoryItem>();
    private Dictionary<ItemData, InventoryItem> itemLookup = new Dictionary<ItemData, InventoryItem>();

    public void AddItem(ItemData referenceData)
    {
        if (itemLookup.TryGetValue(referenceData, out InventoryItem item) && referenceData.isStackable)
        {
            if (item.stackSize < referenceData.maxStackSize)
            {
                item.AddToStack();
            }
            else
            {
                AddNewItem(referenceData);
            }
        }
        else
        {
            AddNewItem(referenceData);
        }

        OnInventoryChanged?.Invoke();
    }

    private void AddNewItem(ItemData referenceData)
    {
        InventoryItem newItem = new InventoryItem(referenceData);
        inventory.Add(newItem);
        if (!itemLookup.ContainsKey(referenceData))
        {
            itemLookup.Add(referenceData, newItem);
        }
    }

    public void RemoveItem(ItemData referenceData)
    {
        if (itemLookup.TryGetValue(referenceData, out InventoryItem item))
        {
            item.RemoveFromStack();
            if (item.stackSize <= 0)
            {
                inventory.Remove(item);
                itemLookup.Remove(referenceData);
            }
            OnInventoryChanged?.Invoke();
        }
    }
}
