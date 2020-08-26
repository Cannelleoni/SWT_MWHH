using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tile2DFunctionality : MonoBehaviour
{
    [SerializeField] Sprite isFloor, noFloor;

    public void onClick2DTile()
    {
        // get name
        // -> get index
        Vector2Int name = GridManager.getGridIndexFromName(gameObject);

        // get underlying grid structure

        if (GridManager.getTileCounter() > 0)
        {
            if (GridManager.getGridContainer()[name.x, name.y].getIsFloor() && GridManager.checkAdjacentTiles(name.x, name.y) < 4) 
            {
                // if tile is a corner piece allowed to delete
                if(!GridManager.checkIfConnectingPiece(name.x, name.y))
                {
                    GridManager.setTileCounter(GridManager.getTileCounter() - 1);
                    GridManager.getGridContainer()[name.x, name.y].setIsFloor(false);

                    gameObject.GetComponent<Button>().image.overrideSprite = noFloor;
                }
                
            } else 
            {
                // check adjacent tiles
                if (GridManager.checkAdjacentTiles(name.x, name.y) > 0) 
                {
                    // should probably use getter & setter
                    GridManager.setTileCounter(GridManager.getTileCounter() + 1);
                    GridManager.getGridContainer()[name.x, name.y].setIsFloor(true);

                    gameObject.GetComponent<Button>().image.overrideSprite = isFloor;
                    //gameObject.GetComponent<Image>().color = Color.yellow;
                }
            }
         
        } else 
        {
            // just place it
            GridManager.setTileCounter(1);
            GridManager.getGridContainer()[name.x, name.y].setIsFloor(true);

            gameObject.GetComponent<Button>().image.overrideSprite = isFloor;
            //gameObject.GetComponent<Image>().color = Color.yellow;

        }
         
         
         
    }
}
