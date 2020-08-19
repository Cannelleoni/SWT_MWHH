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
        generate2DView(0, 0);
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
    }

    // join 2D & 3D grid/view generation with extra parameters (prefab, startPos, offsetOuter, offsetInner, parent)??
    // since it's only squares only use 1 offset?
    // instantiates 2D button prefab tile grid
    void generate2DView(int xDim, int yDim)
    {
        Vector3Int position = new Vector3Int((int) gridTile2DParent.transform.position.x, (int) gridTile2DParent.transform.position.y, 0);

        float startPosX = -187.5f;
        float startPosY = 187.5f;
        int offset = 25;

        for(int i = 0, nr = 0; i < gridContainerSize.x; i++ /*, startPos.x += offsetOuter*/)
        {
            for(int j = 0; j < gridContainerSize.y; j++, nr++ /*, startPos.y += offsetInner*/)
            {
                // instance gets name + dillimeter + i + dillimeter + j
                // so index can be known via name
                // example: get indexFromName -> call gridContainerElement & its tile methods

                // instance position is startPos + turns
                // remember to use localPosition

                GameObject tile = Instantiate(gridTile2D, position, Quaternion.identity, gridTile2DParent.transform);
                tile.transform.localPosition = new Vector3(startPosX + i*offset, startPosY-j*offset, 0);

                tile.name = nr + "_" + i + "_" + j;

            }
        }
    }

    Vector2Int getGridIndexFromName(GameObject parent)
    {
        // figure out prefab tree or highest parent I guess
        // string[] nameParts;
        // Vector2Int index = new Vector2Int(nameParts[1], nameParts[2]);

        //return index;
        return Vector2Int.zero;
    }

    // generate 3D grid to the right
    void createGrid3D()
    {
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
