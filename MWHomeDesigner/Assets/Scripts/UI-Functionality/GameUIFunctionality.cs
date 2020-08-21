using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIFunctionality : MonoBehaviour
{
    [SerializeField] GameObject parent;

    public void finishFloorLayout()
    {
        GridManager.isDecidingFloorLayout = false;

        // make the button disappear
        for(int i = 0; i < GridManager.getGridContainer().GetLength(0); i++)
        {
            for(int j = 0; j < GridManager.getGridContainer().GetLength(1); j++)
            {
                if(!GridManager.getGridContainer()[j, i].getIsFloor())
                {
                    Destroy(parent.transform.Find(j + "_" + i).gameObject);
                } else
                {
                    parent.transform.Find(j + "_" + i).gameObject.GetComponent<Renderer>().material.color = Color.white;
                }
            }
        }
        

        // enable furniture picking
    }
}
