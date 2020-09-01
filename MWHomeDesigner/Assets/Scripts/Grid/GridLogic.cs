using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GridLogic : MonoBehaviour
{
    public static Vector2Int getGridIndexFromName(GameObject parent)
    {
        string s = parent.name;
        string[] nameParts = s.Split('_');
        Vector2Int index = new Vector2Int(System.Int32.Parse(nameParts[1]), System.Int32.Parse(nameParts[2]));

        return index;
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
                    if (GridManager.getGridContainer()[i, j].getIsFloor())
                    {
                        neighbours++;
                    }
                }

            }
        }
        return neighbours;
    }

    public static bool checkIfConnectingPiece(int xDim, int yDim)
    {
        bool isConnecting = true;
        Vector2Int[] pairs = new Vector2Int[4];
        int index = 0;

        int directNeighbour = 0;
        int diagonalNeighbour = 0;

        for (int i = (xDim - 1) >= 0 ? (xDim - 1) : 0, turnX = (xDim - 1) >= 0 ? 1 : 2; i < (xDim + 2) && i < 16; i++, turnX++)
        {
            for (int j = (yDim - 1) >= 0 ? (yDim - 1) : 0, turnY = (yDim - 1) >= 0 ? 1 : 2; j < (yDim + 2) && j < 16; j++, turnY++)
            {
                if (!((turnX % 2) == (turnY % 2)))  //if (!(turnX == 2 && turnY == 2))
                {
                    if (GridManager.getGridContainer()[i, j].getIsFloor())
                    {
                        pairs[index] = new Vector2Int(turnX, turnY);
                        index++;
                        directNeighbour++;

                    }
                }
                else if (!(turnX == 2 && turnY == 2))
                {
                    if (GridManager.getGridContainer()[i, j].getIsFloor())
                    {
                        diagonalNeighbour++;
                    }
                }
            }
        }

        List<int> countX = new List<int> { 2 };
        List<int> countY = new List<int> { 2 };

        if (directNeighbour < 2)
        {
            return false;
        }
        else if (directNeighbour == 2)
        {
            // is it an H-Construction piece?

            if (diagonalNeighbour == 4)
            {
                return false;
            }

            // is it a bridge piece?

            for (int k = 0; k < index; k++)
            {

                countX.Add(pairs[k].x);
                countY.Add(pairs[k].y);
            }

            bool matchX = countX.All(x => x == countX[0]);
            bool matchY = countY.All(y => y == countY[0]);


            if (matchX || matchY)
            {
                return true;
            }

            // otherwise should be corner piece
            // check for other piece holding them together

            for (int k = 1; k < pairs.Length; k++)
            {
                if (pairs[k - 1].x == pairs[k].y)
                {
                    if (pairs[k - 1].y == pairs[k].x)
                    {
                        if (pairs[k - 1].x == 1 || pairs[k - 1].y == 1)
                        {
                            // use 1,1
                            if (xDim > 0 && yDim > 0)
                            {
                                return !(GridManager.getGridContainer()[xDim - 1, yDim - 1].getIsFloor());
                            }
                        }
                        else
                        {
                            // use 3,3
                            if (xDim < GridManager.gridContainerSize.x - 1 && yDim < GridManager.gridContainerSize.y - 1)
                            {
                                return !(GridManager.getGridContainer()[xDim + 1, yDim + 1].getIsFloor());
                            }
                        }
                    }
                    else
                    {
                        // use 3,1
                        if (xDim < GridManager.gridContainerSize.x - 1 && yDim > 0)
                        {
                            return !(GridManager.getGridContainer()[xDim + 1, yDim - 1].getIsFloor());
                        }
                    }
                }
                else
                {
                    // use 1,3
                    if (xDim > 0 && yDim < GridManager.gridContainerSize.y - 1)
                    {
                        return !(GridManager.getGridContainer()[xDim - 1, yDim + 1].getIsFloor());
                    }
                }
            }
        }
        else if (directNeighbour == 3)
        {
            if (diagonalNeighbour == 4)
            {
                return false;
            }
        }
        else
        {
            return true;
        }
        return isConnecting;
    }

}
