using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// View
public class FurnitureMenuSelector : MonoBehaviour
{

    public void selectFurniture()
    {
        FurniturePlacementManager.setActiveFurniture(gameObject.name);
        Debug.Log("Set" + gameObject.name);
    }
}
