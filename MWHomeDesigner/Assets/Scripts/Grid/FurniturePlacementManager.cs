using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controller

public class FurniturePlacementManager : MonoBehaviour
{
    public static string activeFurniture;

    RaycastHit hit;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0) && !string.IsNullOrEmpty(activeFurniture))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform != null)
                {
                    Debug.Log("tile hit" + hit.transform.position);
                    GameObject furniture = GameObject.Instantiate((GameObject)Resources.Load(activeFurniture), hit.transform.position + new Vector3(0,0.5f,0),Quaternion.identity, hit.transform);
              
                    Debug.Log("Bed spawned");
                    activeFurniture = "";
                }
            }
            
        }
    }

    public static void setActiveFurniture(string furniture)
    {
        activeFurniture = furniture;
    }
}
