using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureMenuSelector : MonoBehaviour
{
    // communicates which furniture icon has been selected
    public void selectFurniture()
    {
        FurniturePlacementManager.setActiveFurniture(gameObject.name);
    }
}
