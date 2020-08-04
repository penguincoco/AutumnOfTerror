using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(UIInteraction_Helper))]
public class UIInteraction : EventTrigger
{
    private bool dragging;
    private string name;

    public UIInteraction_Helper helper;

    public ItemObject item;

    public Sprite objImage;
    public string description;

    public void Awake()
    {
        helper = this.gameObject.GetComponent<UIInteraction_Helper>();
    }

    public void ClickObj()
    {
        Debug.Log("Clicking on object: " + gameObject.name);
        Inventory.Instance.SetEquippedObject(gameObject.name);      //Set the EquippedObject for player
        //SetObservingItem();
        helper.SetObservingItem();
            //on the gameobject itself is the scriptable object. the scriptable object has a prefab field on it called Prefab which is the image in question (holy moly) 
    }


    //when an object 
    public void SetName(string name)
    {
        this.name = name;
    }
}
