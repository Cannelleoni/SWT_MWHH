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
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            GetComponent<Renderer>().material.color = Color.white;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform != null)
                {
                    Vector2Int name = getGridIndexFromName(hit.transform.gameObject);
                    print(name.x + " - " + name.y);

                    

                    Material mat = hit.transform.gameObject.GetComponent<Renderer>().material;
                    mat.color = Color.red;

                }
            }
        }
    }

    Vector2Int getGridIndexFromName(GameObject parent)
    {
        string s = parent.name;
        string[] nameParts = s.Split('_');
        Vector2Int index = new Vector2Int(System.Int32.Parse(nameParts[1]), System.Int32.Parse(nameParts[2]));

        return index;
    }



}
