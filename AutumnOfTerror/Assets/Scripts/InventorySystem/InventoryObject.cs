using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject
{
    public List<InventorySlot> container = new List<InventorySlot>();

    public void AddItem(ItemObject _item)
    {
        container.Add(new InventorySlot(_item));    //this assumes you can never pick up the same object. No "hat x3" or whatever
        DisplayInventory.Instance.UpdateDisplay();
    }
}

[System.Serializable]
public class InventorySlot
{
    public ItemObject item;

    public InventorySlot(ItemObject _item)
    {
        item = _item;
    }
}