using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBaseFunctionality : MonoBehaviour
{
    [SerializeField] Renderer allMat;

    // check raycast collision

    // depending on mode assign isFloor 

    // or if isOccupied small popup menu appears

    int tileCounter = 0;

    Vector2Int lastTile;
    Material currentMat, lastMat;

    RaycastHit hit;

    private void Update()
    {
        // if(Input.GetKeyDown(KeyCode.Mouse0))
        //{
        



        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 100.0f))
        {
            if (hit.transform != null)
            {
                

                //Material mat = hit.transform.gameObject.GetComponent<Renderer>().material;
                //mat.color = Color.red;
                // 

                if (GridManager.isDecidingFloorLayout)
                {
                    allMat.material.color = Color.white;

                    Vector2Int name = getGridIndexFromName(hit.transform.gameObject);
                    currentMat = transform.parent.transform.Find(name.x + "_" + name.y).gameObject.GetComponent<Renderer>().material;
                    currentMat.color = Color.red;

                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        //Material allMat = GetComponent<Renderer>().material;
                        //allMat.color = Color.white;

                        

                        
                        if (lastTile == null)
                        {
                            lastTile = new Vector2Int(0, 0);
                            
                        }

                        if(lastMat == null)
                        {
                            lastMat = currentMat;
                        }

                        //if (GridManager.getGridContainer()[lastTile.x, lastTile.y].getIsFloor())
                        //{
                        //    lastMat.color = Color.white;
                        //}

                        

                        // is it the first tile being placed?
                        if (tileCounter > 0)
                        {
                            //check neighbouring tiles
                            // is at least one floor?
                            // -> allowed to mark hit as floor
                            if(GridManager.getGridContainer()[name.x, name.y].getIsFloor())
                            {
                                //if(checkAdjacentTiles(name.x, name.y) < 2)
                                //{
                                //    print("delete");
                                //    tileCounter--;
                                //    GridManager.getGridContainer()[name.x, name.y].setIsFloor(false);
                                //    //transform.parent.transform.Find(name.x + "_" + name.y).gameObject.GetComponent<Renderer>().material.color = Color.white;
                                //}

                            } else
                            {
                                if (checkAdjacentTiles(name.x, name.y) > 0)
                                {
                                    tileCounter++;
                                    GridManager.getGridContainer()[name.x, name.y].setIsFloor(true);
                                    currentMat.color = Color.green;

                                }
                            }
                        }
                        else
                        {
                            tileCounter = 1;
                            // any tile is okay

                            //Vector2Int name = getGridIndexFromName(hit.transform.gameObject);
                            GridManager.getGridContainer()[name.x, name.y].setIsFloor(true);
                            print(name.x + " - " + name.y);
                            currentMat.color = Color.green;

                            print("first");
                        }

                        for (int i = 0; i < GridManager.getGridContainer().GetLength(0); i++)
                        {
                            for (int j = 0; j < GridManager.getGridContainer().GetLength(1); j++)
                            {
                                if (GridManager.getGridContainer()[j, i].getIsFloor())
                                {
                                    currentMat.color = Color.green;
                                } // maybe not 16x16 big updates sondern eine mother class die nope
                            }
                        }

                        lastTile.x = name.x;
                        lastTile.y = name.y;
                        lastMat = currentMat;


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

    Vector2Int getGridIndexFromName(GameObject parent)
    {
        string s = parent.name;
        string[] nameParts = s.Split('_');
        Vector2Int index = new Vector2Int(System.Int32.Parse(nameParts[0]), System.Int32.Parse(nameParts[1]));

        return index;
    }

    int checkAdjacentTiles(int xDim, int yDim)
    {
        int neighbours = 0;

        for(int i = (xDim - 1) >= 0 ? (xDim - 1) : 0, turnX = (xDim - 1) >= 0 ? 2 : 1; i < (xDim + 2) && i < 16; i++, turnX++)
        {
            for(int j = (yDim -1) >= 0 ? (yDim - 1) : 0, turnY = (yDim - 1) >= 0 ? 2 : 1; j < (yDim + 2) && j < 16; j++, turnY++)
            {
                // ignore self & diagonal tiles
                if(!((turnX % 2) ==  (turnY % 2)))
                {
                    if (GridManager.getGridContainer()[i, j].getIsFloor())
                    {
                        neighbours++; ;
                    }
                }
                
            }
        }
        return neighbours;
    }

}
