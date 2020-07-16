using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
[CreateAssetMenu(fileName = "New Item Object", menuName = "Inventory System/Item")]

public class ItemObject : ScriptableObject
{
    public GameObject prefab;
    public string name;
}
