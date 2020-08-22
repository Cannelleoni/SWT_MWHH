using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// draw: white < isFloor < cursor

public class TileBaseFunctionality : MonoBehaviour
{
    [SerializeField] Renderer allMat;


    int tileCounter = 0;

    Vector2Int lastTile;
    Material currentMat, lastMat;

    RaycastHit hit;

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 100.0f))
        {
            if (hit.transform != null)
            {
                if (GridManager.isDecidingFloorLayout)
                {
                    //allMat.material.color = Color.white;

                    Vector2Int name = getGridIndexFromName(hit.transform.gameObject);

                    currentMat = transform.parent.transform.Find(name.x + "_" + name.y).gameObject.GetComponent<Renderer>().material;

                    

                    
                    

                    if (lastMat == null)
                    {
                        lastMat = currentMat;
                        print("assigned lastMat");
                    }

                    lastMat.color = Color.white;

                    /* get overdrawn by tile cursor anyway */
                    for (int i = 0; i < GridManager.getGridContainer().GetLength(0); i++)
                    {
                        for (int j = 0; j < GridManager.getGridContainer().GetLength(1); j++)
                        {
                            if (GridManager.getGridContainer()[j, i].getIsFloor())
                            {
                                // currentMat.color = Color.green;
                                transform.parent.transform.Find(j + "_" + i).gameObject.GetComponent<Renderer>().material.color = Color.green;
                            }
                        }
                    }

                    currentMat.color = Color.red;

                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {

                        

                        if (lastTile == null)
                        {
                            lastTile = new Vector2Int(0, 0);
                            
                        }

                        

                        // is it the first tile being placed?
                        if (tileCounter > 0)
                        {
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
                                //if (checkAdjacentTiles(name.x, name.y) > 0)
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

                            //Vector2Int name = getGridIndexFromName(hit.transform.gameObject);
                            GridManager.getGridContainer()[name.x, name.y].setIsFloor(true);
                            print(name.x + " - " + name.y);
                            currentMat.color = Color.green;

                            print("first");
                        }

                        

                        


                    }

                    lastTile.x = name.x;
                    lastTile.y = name.y;
                    lastMat = currentMat;

                }
                else
                {
                    // furniture placing is going on
                    // -> mini pop menu appears

                    // destroy this component or come up with something for reacting to furniture
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

    

}
