using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    // needs getter & setter
    bool isDecidingFloorLayout;

    // uniform, because the underlying grid is a rectangle
    static GridTiles[,] gridContainer;
    // default max size
    Vector2Int gridContainerSize = new Vector2Int(16, 16);


    [SerializeField] GameObject gridTile2D, gridTile2DParent, gridTile3D, gridTile3DParent;

    void Start()
    {
        createCustomArray(gridContainerSize.x, gridContainerSize.y);
        createGrid3D();

    }

    //// get x dimension from user (input field, slider whatever)
    //int getXDimensions()
    //{
    //    return -1;
    //}

    //// get y dimension from user (input field, slider whatever)
    //int getYDimensions()
    //{
    //    return -1;
    //}

    GridTiles[,] getGridContainer()
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

        print(getGridContainer().GetLength(0));
        print(getGridContainer().GetLength(1));

        for(int i = 0; i < gridContainer.GetLength(0); i++)
        {
            for(int j = 0; j < gridContainer.GetLength(1); j++)
            {
                if (i % 2 == 0)
                {
                    print(getGridContainer()[i, j].getIsFloor());
                    getGridContainer()[i, j].setIsFloor(true);
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

    // generate 3D grid to the right
    void createGrid3D()
    {
        for(int i = 0, nr = 0; i < gridContainerSize.y; i++)
        {
            for(int j = 0; j < gridContainerSize.x; j++, nr++)
            {
                if(getGridContainer()[i, j].getIsFloor() == true)
                {
                    int x = i / 2;      // get them closer together
                    int y = j / 2;  // why would it reduce their number?? overlapping
                    GameObject tile = Instantiate(gridTile3D, new Vector3(x, 0, y), Quaternion.identity, gridTile3DParent.transform);
                    tile.transform.localPosition = new Vector3Int(i, 0, j);

                    tile.name = nr + "_" + i + "_" + j;
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
