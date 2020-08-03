using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInteraction_Helper : MonoBehaviour
{
    public ItemObject item;

    public Sprite objImage;
    public string description;

    public void SetObservingItem()
    {
        SetData();
        DisplayInventory.Instance.SetObservingItem(objImage, description);
    }

    //display the data for this object
    public void SetData()
    {
        objImage = this.gameObject.GetComponent<Image>().sprite;
        this.description = item.description;
    }
}
