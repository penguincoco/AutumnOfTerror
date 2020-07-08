using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public InventoryObject inventory;

    public Canvas inventoryCanvas;

    void Start()
    {
        inventoryCanvas.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ToggleInventoryShow();
        }
    }

    void ToggleInventoryShow()
    {
        if (inventoryCanvas.enabled)
        {
            Debug.Log("Enabling");
            inventoryCanvas.enabled = false;
        }
        else
        {
            Debug.Log("Disabling");
            inventoryCanvas.enabled = true;
        }
    }

    public void OnTriggerEnter(Collider otherObj)
    {
        Item item = otherObj.GetComponent<Item>();
        if (item)
        {
            inventory.AddItem(item.item);
            Destroy(otherObj.gameObject);
        }
    }

    private void OnApplicationQuit()
    {
        inventory.container.Clear();
    }
}
