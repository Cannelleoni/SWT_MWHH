using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    // needs getter & setter
    public static bool isDecidingFloorLayout = true;
   // replace with counter
    // public static bool firstTilePlaced = false;

    // uniform, because the underlying grid is a rectangle
    static GridTiles[,] gridContainer;
    // default max size
    Vector2Int gridContainerSize = new Vector2Int(16, 16);


    [SerializeField] GameObject gridTile3D, gridTile3DParent;

    void Start()
    {
        createCustomArray(gridContainerSize.x, gridContainerSize.y);
        createGrid3D();

    }

    public static GridTiles[,] getGridContainer()
    {
        return gridContainer;
    }

    // first preset room & floor layout
    void createPresetArray01(int xDim, int yDim)
    {

    }

    // second preset room & floor layout
    void createPresetArray02(int xDim, int yDim)
    {

    }

    // gets called when game scene is entered for custom floor setup
    // when called use gridContainerSize
    void createCustomArray(int xDim, int yDim)
    {
        gridContainer = new GridTiles[xDim, yDim];

        for(int g = 0; g < xDim; g++)
        {
            for(int h = 0; h < yDim; h++)
            {
                getGridContainer()[g, h] = new GridTiles();
            }
        }

        //for(int i = 0; i < gridContainer.GetLength(0); i++)
        //{
        //    for(int j = 0; j < gridContainer.GetLength(1); j++)
        //    {
               
        //        getGridContainer()[i, j].setIsFloor(true);
                
                
        //    }
            
        //}
    }

    

   

    // generate 3D grid to the right
    void createGrid3D()
    {
        for(int i = 0, nr = 0; i < gridContainerSize.y; i++)
        {
            for(int j = 0; j < gridContainerSize.x; j++, nr++)
            {
                //if(getGridContainer()[i, j].getIsFloor() == true)
                {
                    GameObject tile = Instantiate(gridTile3D, new Vector3(i, 0, j), Quaternion.identity, gridTile3DParent.transform);
                    tile.transform.localPosition = new Vector3Int(i, 0, j);

                    tile.name = i + "_" + j;
                }
            }
        }
        // instantiate 3d tile grid prefabs 
        // but only isFloor tiles?
    }

    // where should 2d tile prefab functionality go?
    // extra script probably
    // -> these only work while the player is deciding the floor layout
    // -> setting isFloor and such
    // getGridIndexFromName should probably move as well?
    // -> have to set up connection to tiles -> make grid static?
    // intermediate getter & setter
}
