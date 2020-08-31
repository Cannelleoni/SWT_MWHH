﻿using UnityEngine;

public class GridViewGenerator : MonoBehaviour
{
    static GridViewGenerator GVG;

    [SerializeField] GameObject tile2D, tile2DParent, tile3D, tile3DParent;

    private void Awake()
    {
        GVG = this;
    }

    // join 2D & 3D grid/view generation with extra parameters (prefab, startPos, offsetOuter, offsetInner, parent)??
    // since it's only squares only use 1 offset?
    // instantiates 2D button prefab tile grid
    public static void generate2DView(int xDim, int yDim)
    {
        Vector3Int position = new Vector3Int((int) GVG.tile2DParent.transform.position.x, (int) GVG.tile2DParent.transform.position.y, 0);

        float startPosX = -270f;
        float startPosY = 270f;
        int offset = 36;

        for (int i = 0, nr = 0; i < yDim; i++)
        {
            for (int j = 0; j < xDim; j++, nr++)
            {
                // instance gets name + dillimeter + i + dillimeter + j
                // so index can be known via name
                // example: get indexFromName -> call gridContainerElement & its tile methods

                // instance position is startPos + turns
                // remember to use localPosition


                /// <summary>
                /// gitve gridcontroller in hierarchy public fields mit den tiles & ihren parents
                /// </summary>

                GameObject tile = Instantiate(GVG.tile2D, position, Quaternion.identity, GVG.tile2DParent.transform);
                tile.transform.localPosition = new Vector3(startPosX + i * offset, startPosY - j * offset, 0);

                tile.name = nr + "_" + i + "_" + j;

            }
        }
    }

    // generate 3D grid to the right
    public static void createGrid3D(int xDim, int yDim)
    {
        for (int i = 0; i < yDim; i++)
        // for (int i = gridContainerSize.y - 1; i >= 0; i--)
        {
            for (int j = 0; j < xDim; j++)
            //for (int j = gridContainerSize.x - 1; j >= 0; j--)
            {
                if (GridManager.getGridContainer()[i, j].getIsFloor() == true)
                {
                    GameObject tile = Instantiate(GVG.tile3D, new Vector3(i, 0, j), Quaternion.identity, GVG.tile3DParent.transform);
                    tile.transform.localPosition = new Vector3Int(i, 0, -j);

                    tile.name = i + "_" + j;
                }
            }
        }
    }
}
