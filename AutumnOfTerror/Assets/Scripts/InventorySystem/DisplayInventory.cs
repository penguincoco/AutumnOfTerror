using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Specialized;

public class DisplayInventory : MonoBehaviour
{
    private static DisplayInventory _instance;
    public static DisplayInventory Instance { get { return _instance; } }

    public InventoryObject inventory;

    public int x_start;
    public int y_start;

    public int xSpaceBuffer;
    public int ySpaceBuffer;
    public int columns;

    Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();

    public GameObject objSquareSprite; 

    void Awake()
    {
        //singleton pattern
        if (_instance != null && _instance != this)
            Destroy(this.gameObject);
        else
            _instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        CreateDisplay();
    }

    public void UpdateDisplay()
    {
        int itemIndex = inventory.container.Count - 1;
        var obj = Instantiate(inventory.container[itemIndex].item.prefab, Vector3.zero, Quaternion.identity, transform);
        obj.GetComponent<RectTransform>().localPosition = GetPosition(itemIndex);
    }

    public void CreateDisplay()
    {
        for (int i = 0; i < 16; i++)
        {
            GameObject objSquare = Instantiate(objSquareSprite, Vector3.zero, Quaternion.identity, transform);
            objSquare.GetComponent<RectTransform>().localPosition = GetPosition(i);
        }
    }

    public Vector3 GetPosition(int pos)
    {
        return new Vector3(x_start + (xSpaceBuffer * (pos % columns)), y_start + (-ySpaceBuffer * (pos / columns)), 0f);
    }
}
