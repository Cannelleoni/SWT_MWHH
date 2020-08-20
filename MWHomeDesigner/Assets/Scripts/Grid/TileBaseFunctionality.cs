using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBaseFunctionality : MonoBehaviour
{
    // check raycast collision

    // depending on mode assign isFloor 

    // or if isOccupied small popup menu appears

    RaycastHit hit;

    private void Update()
    {
        if(Input.GetKey(KeyCode.Mouse0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform != null)
                {
                    print("check");
                }
            }
        }

        
    }





}
