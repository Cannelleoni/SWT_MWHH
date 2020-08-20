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
        // if(Input.GetKeyDown(KeyCode.Mouse0))
        //{
        GetComponent<Renderer>().material.color = Color.white;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 100.0f))
        {
            if (hit.transform != null)
            {
                Material mat = hit.transform.gameObject.GetComponent<Renderer>().material;
                mat.color = Color.red;
                // 

                if(Input.GetKeyDown(KeyCode.Mouse0))
                {
                    if (GridManager.isDecidingFloorLayout)
                    {


                        // is it the first tile being placed?
                        if (GridManager.firstTilePlaced)
                        {
                            // check that adjacent tile is floor
                            
                        } else
                        {
                            GridManager.firstTilePlaced = true;
                            // any tile is okay

                            Vector2Int name = getGridIndexFromName(hit.transform.gameObject);
                            GridManager.getGridContainer()[name.x, name.y].setIsFloor(true);
                            print(name.x + " - " + name.y);
                        }

                        //check neighbouring tiles
                        // is at least one floor?
                        // -> allowed to mark hit as floor

                    }
                    else
                    {
                        // furniture placing is going on
                        // -> mini pop menu appears
                    }
                }

                

                

            }
        }
        //}
    }

    Vector2Int getGridIndexFromName(GameObject parent)
    {
        string s = parent.name;
        string[] nameParts = s.Split('_');
        Vector2Int index = new Vector2Int(System.Int32.Parse(nameParts[1]), System.Int32.Parse(nameParts[2]));

        return index;
    }



}
