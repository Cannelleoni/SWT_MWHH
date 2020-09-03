using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GridLogic : MonoBehaviour
{
    // the tiles get instantiated with their index and a delimiter as their name
    public static Vector2Int getGridIndexFromName(GameObject parent)
    {
        // get the name from the GameObject
        string s = parent.name;
        // split the name
        string[] nameParts = s.Split('_');
        // convert the name parts into integers
        Vector2Int index = new Vector2Int(System.Int32.Parse(nameParts[0]), System.Int32.Parse(nameParts[1]));

        return index;
    }

    // how many tiles surround the argument tile
    // the parameters xDim & yDim are the indeces of the clicked tile
    public static int checkAdjacentTiles(int xDim, int yDim)
    {
        // at first no neighbours
        int neighbours = 0;

        // go through each surrounding element and make sure it doesn't exceed the grid boundaries
        // since integers i & j are real indeces they're not ideal for checking the relative position
        // -> turnX & turnY start at (1, 1) and end with (3, 3)
        for (int i = (xDim - 1) >= 0 ? (xDim - 1) : 0, turnX = (xDim - 1) >= 0 ? 1 : 2; i < (xDim + 2) && i < 16; i++, turnX++)
        {
            for (int j = (yDim - 1) >= 0 ? (yDim - 1) : 0, turnY = (yDim - 1) >= 0 ? 1 : 2; j < (yDim + 2) && j < 16; j++, turnY++)
            {
                // ignore self & diagonal tiles since they don't factor into being allowed to place a tile
                // only 'real' neighbours do that
                if (!((turnX % 2) == (turnY % 2)))
                {
                    // if a directly adjcent tile is a floor tile the player may place a floor tile on the argument tile
                    if (GridManager.getGridContainer()[i, j].getIsFloor())
                    {
                        // the neighbour count goes up
                        neighbours++;
                    }
                }

            }
        }
        // the amount of direct neighbours gets returned
        return neighbours;
    }

    // check if the argument tile is vital for keeping the floor layout connected
    // the parameters xDim & yDim are the indeces of the clicked tile
    public static bool checkIfConnectingPiece(int xDim, int yDim)
    {
        // at first assume it is vital
        bool isConnecting = true;
        // there's a maximum of 4 direct neighbours
        Vector2Int[] pairs = new Vector2Int[4];
        // the index of pairs
        int index = 0;

        // the direct neighbour count
        int directNeighbour = 0;
        // the diagonal neighbour count
        int diagonalNeighbour = 0;

        // go through each surrounding element and make sure it doesn't exceed the grid boundaries
        // since integers i & j are real indeces they're not ideal for checking the relative position
        // -> turnX & turnY start at (1, 1) and end with (3, 3)
        for (int i = (xDim - 1) >= 0 ? (xDim - 1) : 0, turnX = (xDim - 1) >= 0 ? 1 : 2; i < (xDim + 2) && i < 16; i++, turnX++)
        {
            for (int j = (yDim - 1) >= 0 ? (yDim - 1) : 0, turnY = (yDim - 1) >= 0 ? 1 : 2; j < (yDim + 2) && j < 16; j++, turnY++)
            {
                /* turns X & Y  ([2, 2] == self)
                 * [1, 1]   [2, 1]  [3, 1]
                 * [1, 2]   [2, 2]  [3, 2]
                 * [1, 3]   [2, 3]  [3, 3]
                 * 
                 */
                // only go for directly adjacent tiles
                if (!((turnX % 2) == (turnY % 2)))  
                {
                    // if a direct neighbour is a floor tile
                    if (GridManager.getGridContainer()[i, j].getIsFloor())
                    {
                        // save the turn values
                        pairs[index] = new Vector2Int(turnX, turnY);
                        // prepare for the next entry
                        index++;
                        // up the direct neighbour count
                        directNeighbour++;

                    }
                }
                // ignore self
                else if (!(turnX == 2 && turnY == 2))
                {
                    // if a diagonal neighbour is a floor tile
                    if (GridManager.getGridContainer()[i, j].getIsFloor())
                    {
                        // make the diagonal neighbour count go up
                        diagonalNeighbour++;
                    }
                }
            }
        }

        // lists for the x & y coordinates
        // since the center (2,2) is definitely a floor tile it can be added
        List<int> countX = new List<int> { 2 };
        List<int> countY = new List<int> { 2 };

        // if there's 1 or less direct neighbours the center piece cannot connect 2 tiles and is not vital 
        if (directNeighbour < 2)
        {
            return false;
        }
        // if it has excactly 2 neighbours it could be a vital tile
        else if (directNeighbour == 2)
        {
            // is it an H-Construction piece?
            // which is not ideal as it can be a vital piece but the check for vital pieces is extensive and would need to cover a lot of cases
            if (diagonalNeighbour == 4)
            {
                // the direct neighbours have at least 2 direct floor pieces so it's okay
                return false;
            }

            // is it a bridge piece?

            // start adding the coordinates to the lists
            for (int k = 0; k < index; k++)
            {
                countX.Add(pairs[k].x);
                countY.Add(pairs[k].y);
            }

            // check if the center piece has to 2 horizontal or 2 vertical neighbours
            bool matchX = countX.All(x => x == countX[0]);
            bool matchY = countY.All(y => y == countY[0]);

            // if a 'bridge' match was found it is vital
            if (matchX || matchY)
            {
                return true;
            }

            // otherwise should be corner piece
            // check for other piece holding them together

            // go through all direct neighbours
            for (int k = 1; k < pairs.Length; k++)
            {
                // since the turns X & Y progress in a set direction 
                // the possible pair order is [1, 2], [2, 1], [2, 3], [3, 2]
                /*          [2, 1]
                 * [1, 2]           [3, 2]
                 *          [2, 3]
                 */
                
                // if upper left corner, upper right corner or lower right corner
                if (pairs[k - 1].x == pairs[k].y)
                {
                    // if upper left or lower right corner
                    if (pairs[k - 1].y == pairs[k].x)
                    {
                        // if upper left corner
                        if (pairs[k - 1].x == 1 || pairs[k - 1].y == 1)
                        {
                            // use 1,1
                            // make sure the potential upper left corner of the argument tile doesn't exceed the indeces
                            if (xDim > 0 && yDim > 0)
                            {
                                return !(GridManager.getGridContainer()[xDim - 1, yDim - 1].getIsFloor());
                            }
                        }
                        // if lower right corner
                        else
                        {
                            // use 3,3
                            // make sure the potential lower right corner of the argument tile doesn't exceed the indeces
                            if (xDim < GridManager.gridContainerSize.x - 1 && yDim < GridManager.gridContainerSize.y - 1)
                            {
                                return !(GridManager.getGridContainer()[xDim + 1, yDim + 1].getIsFloor());
                            }
                        }
                    }
                    // if upper right corner
                    else
                    {
                        // use 3,1
                        // make sure the potential upper right corner of argument tile doesn't exceed the indeces
                        if (xDim < GridManager.gridContainerSize.x - 1 && yDim > 0)
                        {
                            return !(GridManager.getGridContainer()[xDim + 1, yDim - 1].getIsFloor());
                        }
                    }
                } 
                // lower left corner
                else
                {
                    // use 1,3
                    // make sure the potential lower left corner of the argument tile doesn't exceed the indeces
                    if (xDim > 0 && yDim < GridManager.gridContainerSize.y - 1)
                    {
                        return !(GridManager.getGridContainer()[xDim - 1, yDim + 1].getIsFloor());
                    }
                }
            }
        }
        // the situation could be expanding a hole inside the floor 
        else if (directNeighbour == 3)
        {
            // but 4 diagonal neighbours are there for safe keeping
            if (diagonalNeighbour == 4)
            {
                return false;
            }
        }
        else
        {
            return true;
        }
        // return whether or not that floor tile is vital
        return isConnecting;
    }

}
