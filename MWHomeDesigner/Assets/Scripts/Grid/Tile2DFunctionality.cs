using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tile2DFunctionality : MonoBehaviour
{
    public void onClick2DTile()
    {
        // get name
        // -> get index
        Vector2Int name = GridManager.getGridIndexFromName(gameObject);

        // get underlying grid structure

        if (GridManager.getTileCounter() > 0)
        {
            if (GridManager.getGridContainer()[name.x, name.y].getIsFloor() && GridManager.checkAdjacentTiles(name.x, name.y) < 2) 
            {
                GridManager.setTileCounter(GridManager.getTileCounter() - 1);
                GridManager.getGridContainer()[name.x, name.y].setIsFloor(false);
                gameObject.GetComponent<Image>().color = Color.white;
            } else 
            {
                // check adjacent tiles
                if (GridManager.checkAdjacentTiles(name.x, name.y) > 0) 
                {
                    // should probably use getter & setter
                    GridManager.setTileCounter(GridManager.getTileCounter() + 1);
                    GridManager.getGridContainer()[name.x, name.y].setIsFloor(true);
                    gameObject.GetComponent<Image>().color = Color.yellow;
                }
            }
         
        } else 
        {
            // just place it
            GridManager.setTileCounter(1);
            GridManager.getGridContainer()[name.x, name.y].setIsFloor(true);
            gameObject.GetComponent<Image>().color = Color.yellow;

        }
         
         
         
    }
}
