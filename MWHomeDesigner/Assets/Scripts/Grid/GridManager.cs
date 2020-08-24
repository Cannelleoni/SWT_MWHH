using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    static GridManager GM;

    // needs getter & setter
    public static bool isDecidingFloorLayout = true;
    // replace with counter
    public static int tileCounter = 0;

    // uniform, because the underlying grid is a rectangle
    static GridTiles[,] gridContainer;
    // default max size
    static Vector2Int gridContainerSize = new Vector2Int(16, 16);


    [SerializeField] GameObject gridTile2D, gridTile2DParent, gridTile3D, gridTile3DParent;

    private void Awake()
    {
        GM = this;
    }

    void Start()
    {

        createCustomArray(gridContainerSize.x, gridContainerSize.y);
        generate2DView(0, 0);
        //createGrid3D();

    }

    public static void setTileCounter(int i)
    {
        tileCounter = i;
    }

    public static int getTileCounter()
    {
        return tileCounter;
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
        
    }

    // join 2D & 3D grid/view generation with extra parameters (prefab, startPos, offsetOuter, offsetInner, parent)??
    // since it's only squares only use 1 offset?
    // instantiates 2D button prefab tile grid
    void generate2DView(int xDim, int yDim)
    {
        Vector3Int position = new Vector3Int((int)gridTile2DParent.transform.position.x, (int)gridTile2DParent.transform.position.y, 0);

        float startPosX = -270f;
        float startPosY = 270f;
        int offset = 36;

        for (int i = 0, nr = 0; i < gridContainerSize.y; i++)
        {
            for (int j = 0; j < gridContainerSize.x; j++, nr++)
            {
                // instance gets name + dillimeter + i + dillimeter + j
                // so index can be known via name
                // example: get indexFromName -> call gridContainerElement & its tile methods

                // instance position is startPos + turns
                // remember to use localPosition

                GameObject tile = Instantiate(gridTile2D, position, Quaternion.identity, gridTile2DParent.transform);
                tile.transform.localPosition = new Vector3(startPosX + i * offset, startPosY - j * offset, 0);

                tile.name = nr + "_" + i + "_" + j;

            }
        }
    }

    public static Vector2Int getGridIndexFromName(GameObject parent)
    {
        string s = parent.name;
        string[] nameParts = s.Split('_');
        Vector2Int index = new Vector2Int(System.Int32.Parse(nameParts[1]), System.Int32.Parse(nameParts[2]));

        return index;
    }

    // generate 3D grid to the right
    public static void createGrid3D()
    {
        for(int i = 0; i < gridContainerSize.y; i++)
        // for (int i = gridContainerSize.y - 1; i >= 0; i--)
        {
            for (int j = 0; j < gridContainerSize.x; j++)
            //for (int j = gridContainerSize.x - 1; j >= 0; j--)
            {
                if(getGridContainer()[i, j].getIsFloor() == true)
                {
                    GameObject tile = Instantiate(GM.gridTile3D, new Vector3(i, 0, j), Quaternion.identity, GM.gridTile3DParent.transform);
                    tile.transform.localPosition = new Vector3Int(i, 0, -j);

                    tile.name = i + "_" + j;
                }
            }
        }
        // instantiate 3d tile grid prefabs 
        // but only isFloor tiles?
    }


    public static int checkAdjacentTiles(int xDim, int yDim)
    {
        int neighbours = 0;

        for (int i = (xDim - 1) >= 0 ? (xDim - 1) : 0, turnX = (xDim - 1) >= 0 ? 1 : 2; i < (xDim + 2) && i < 16; i++, turnX++)
        {
            for (int j = (yDim - 1) >= 0 ? (yDim - 1) : 0, turnY = (yDim - 1) >= 0 ? 1 : 2; j < (yDim + 2) && j < 16; j++, turnY++)
            {
                // ignore self & diagonal tiles
                if (!((turnX % 2) == (turnY % 2)))
                {
                    if (getGridContainer()[i, j].getIsFloor())
                    {
                        neighbours++; 
                    }
                }

            }
        }
        print(neighbours);
        return neighbours;
    }

    public static bool checkIfConnectingPiece(int xDim, int yDim)
    {
        bool isConnecting = false;
        Vector2Int[] pairs = new Vector2Int[8];
        int index = 0;

        for (int i = (xDim - 1) >= 0 ? (xDim - 1) : 0, turnX = (xDim - 1) >= 0 ? 1 : 2; i < (xDim + 2) && i < 16; i++, turnX++)
        {
            for (int j = (yDim - 1) >= 0 ? (yDim - 1) : 0, turnY = (yDim - 1) >= 0 ? 1 : 2; j < (yDim + 2) && j < 16; j++, turnY++)
            {
                if(!(turnX == 2 && turnY == 2))
                {
                    if (getGridContainer()[i, j].getIsFloor())
                    {
                        pairs[index] = new Vector2Int(turnX, turnY);
                        print("update " + index);
                        index++;
                        
                    }
                }

                

            }
        }

        print("neighbours: " + index);

        List<int> countX = new List<int> { 2 };
        List<int> countY = new List<int> { 2 };

        

        if (index == 2)
        {
            for (int k = 0; k < index; k++)
            {
                print(pairs[k].x + ":" + pairs[k].y);

                countX.Add(pairs[k].x);
                countY.Add(pairs[k].y);
            }

            bool matchX = countX.All(x => x == countX[0]);
            bool matchY = countY.All(y => y == countY[0]);

            print("match x: " + matchX + ", match y: " + matchY);

            if(matchX || matchY)
            {
                return true;
            }

            /*
                for each direct neighbour check their constellation and 
                   then if they have another piece connecting them    
                   -> if yes allowed to delete

                put in loop to cycle through pairs
             
            */

            //if (x1 == y2)
            //{
            //    if (y1 == x2)
            //    {
            //        if (x1 == 1 || y1 == 1)
            //        {
            //            use 1,1
            //        }
            //        else
            //        {
            //            use 3,3
            //        }
            //    }
            //    else
            //    {
            //        use 3,1
            //    }
            //}
            //else
            //{
            //    use 1,3
            //}


        } else
        {
            return false;
        }
        

        return isConnecting;
    }
}
