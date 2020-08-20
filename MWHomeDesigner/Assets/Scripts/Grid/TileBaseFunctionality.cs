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
        //Material allMat = GetComponent<Renderer>().material;
        //allMat.color = Color.white;

        

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 100.0f))
        {
            if (hit.transform != null)
            {
                //Material mat = hit.transform.gameObject.GetComponent<Renderer>().material;
                //mat.color = Color.red;
                // 

                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    if (GridManager.isDecidingFloorLayout)
                    {
                        for (int i = 0; i < GridManager.getGridContainer().GetLength(0); i++)
                        {
                            for (int j = 0; j < GridManager.getGridContainer().GetLength(1); j++)
                            {
                                if (GridManager.getGridContainer()[j, i].getIsFloor())
                                {
                                    transform.parent.transform.Find(j + "_" + i).gameObject.GetComponent<Renderer>().material.color = Color.green;
                                    print("green");
                                }
                            }
                        }

                        // is it the first tile being placed?
                        if (GridManager.firstTilePlaced)
                        {
                            //check neighbouring tiles
                            // is at least one floor?
                            // -> allowed to mark hit as floor
                            Vector2Int name = getGridIndexFromName(hit.transform.gameObject);

                            if (checkAdjacentTiles(name.x, name.y))
                            {
                                GridManager.getGridContainer()[name.x, name.y].setIsFloor(true);
                                print("neighbour");
                            }
                        }
                        else
                        {
                            GridManager.firstTilePlaced = true;
                            // any tile is okay

                            Vector2Int name = getGridIndexFromName(hit.transform.gameObject);
                            GridManager.getGridContainer()[name.x, name.y].setIsFloor(true);
                            print(name.x + " - " + name.y);

                            print("first");
                        }

                        

                    }
                    else
                    {
                        // furniture placing is going on
                        // -> mini pop menu appears
                    }
                }

                

                

            }
        }
        
    }

    Vector2Int getGridIndexFromName(GameObject parent)
    {
        string s = parent.name;
        string[] nameParts = s.Split('_');
        Vector2Int index = new Vector2Int(System.Int32.Parse(nameParts[0]), System.Int32.Parse(nameParts[1]));

        return index;
    }

    bool checkAdjacentTiles(int xDim, int yDim)
    {
        for(int i = (xDim - 1) >= 0 ? (xDim - 1) : 0; i < (xDim + 2) && i < 16; i++)
        {
            for(int j = (yDim -1) >= 0 ? (yDim - 1) : 0; j < (yDim + 2) && j < 16; j++)
            {
                if(GridManager.getGridContainer()[i, j].getIsFloor())
                {
                    return true;
                }
            }
        }
        return false;
    }

}
