using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class UIInteraction : EventTrigger
{
    private bool dragging;
    private string name;

    public void ClickObj()
    {
        Debug.Log("Clicking on object: " + gameObject.name);
        Inventory.Instance.SetEquippedObject(gameObject.name);
    }

    public void SetName(string name)
    {
        this.name = name;
    }
}
