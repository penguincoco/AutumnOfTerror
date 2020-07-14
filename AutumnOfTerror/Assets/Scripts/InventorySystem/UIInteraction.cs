using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class UIInteraction : EventTrigger
{
    private bool dragging;
    private string name;

    void Start()
    {
    }

    public void Update()
    {
        //if (dragging)
        //{
        //    transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -10f);
        //}
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        dragging = true;
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        dragging = false;
    }

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
