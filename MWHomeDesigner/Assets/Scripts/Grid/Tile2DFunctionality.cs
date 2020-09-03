using UnityEngine;

public class Tile2DFunctionality : MonoBehaviour
{
    // happens when a 2D button tile is clicked on the floor layout mode
    public void onClick2DTile()
    {
        // get name -> get index
        Vector2Int name = GridLogic.getGridIndexFromName(gameObject);
        
        // if a tile has already been placed
        if (GridManager.getTileCounter() > 0)
        {
            // if the tile the player clicked on is already a afloor tile
            if (GridManager.getGridContainer()[name.x, name.y].getIsFloor() ) 
            {
                // check whether the current tile is a vital piece
                if(!GridLogic.checkIfConnectingPiece(name.x, name.y))
                {
                    // set the tile counter down
                    GridManager.setTileCounter(GridManager.getTileCounter() - 1);
                    // mark the current tile as 'not floor'
                    GridManager.getGridContainer()[name.x, name.y].setIsFloor(false);
                    // change appearance of sprite
                    ButtonSpriteSwap.buttonNotFilled(gameObject);
                } else
                {
                    // show tip that all tiles should be connected
                    GameUIFunctionality.showTileTip();
                }
            }
            // make new floor tile
            else 
            {
                // check adjacent tiles for a direct neighbour
                if (GridLogic.checkAdjacentTiles(name.x, name.y) > 0) 
                {
                    // if there's a neighbour the tile is connected and may be placed down
                    GridManager.setTileCounter(GridManager.getTileCounter() + 1);
                    // communicate the change to the grid structure
                    GridManager.getGridContainer()[name.x, name.y].setIsFloor(true);

                   // change the appearance of the button
                    ButtonSpriteSwap.buttonFilled(gameObject);
                } else
                {
                    // show tip that the tiles should be connected
                    GameUIFunctionality.showTileTip();
                }
            }
        }
        // no tile has been placed yet
        else 
        {
            // just place it since there's no need to check for neighbours
            GridManager.setTileCounter(1);
            // communicate the change to the grid structure
            GridManager.getGridContainer()[name.x, name.y].setIsFloor(true);
            // change the apperance of the button
            ButtonSpriteSwap.buttonFilled(gameObject);
        }  
    }
}
