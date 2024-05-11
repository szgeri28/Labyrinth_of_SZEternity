using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//V�letlenszer� labirintus gener�tor 
public class MazeGenerator : MonoBehaviour
{
    [SerializeField]
    //Egy cella s�m�ja
    public MazeCell _mazeCellPrefab;

    [SerializeField]
    //H�ny cella sz�les legyen a gener�lt Grid
    public int _mazeWidth = 20;

    [SerializeField]
    //H�ny cella "magass�g�" legyen a gener�lt Grid
    public int _mazeDepth = 20;

    //A Grid l�nyeg�ben egy, a cell�kb�l fel�p�tett hal�t alkot 
    public MazeCell[,] _mazeGrid;

    //Felt�lti a Gridet a cell�kkal k�t for ciklus seg�ts�g�vel 
    public void Start()
    {
        _mazeGrid = new MazeCell[_mazeWidth, _mazeDepth];

        for (int x = 0; x < _mazeWidth; x++)
        {
            for (int y = 0; y < _mazeDepth; y++)
            {
                _mazeGrid[x, y] = Instantiate(_mazeCellPrefab, new Vector2(x, y), Quaternion.identity, transform);
                _mazeGrid[x, y].transform.localPosition = new Vector2(x, y);
            }
        }

        //Elind�tja a labirintus t�nyleges gener�l�s�t 
        GenerateMaze(null, _mazeGrid[0, 0]);
    }

    public void GenerateMaze(MazeCell previousCell, MazeCell currentCell)
    {
        //A jelenlegi cell�t "megl�togatja" ezzel jelezve hogy ezt legener�lta
        currentCell.Visit();
        //Deaktiv�lja a falakat az el�z� �s a jelenlegi cella k�z�tt 
        ClearWalls(previousCell, currentCell);
        //Bizonyos %-al v�letlenszer�en deaktiv�l egy szint�n v�letlenszer� falat az aktu�lis cell�ban
        LoopGeneration(previousCell, currentCell);

        MazeCell nextCell;

        do
        {
            //Kiv�lasztja melyik k�rnyez� cella legyen a k�vetkez� amit legener�l
            nextCell = GetNextUnvisitedCell(currentCell);

            //Am�g van k�vetkez� cella addig folytatja
            if (nextCell != null)
            {
                GenerateMaze(currentCell, nextCell);
            }
        } while (nextCell != null);
    }

    //Megkeresi a k�rnyez�, m�g meg nem l�togatott cell�kat �s v�letlenszer�en kiv�laszt egyet
    public MazeCell GetNextUnvisitedCell(MazeCell currentCell)
    {
        var unvisitedCells = GetUnvisitedCells(currentCell);

        return unvisitedCells.OrderBy(_ => Random.Range(1, 10)).FirstOrDefault();
    }

    //Megkeresi a lehets�ges k�vetkez� cell�kat
    public IEnumerable<MazeCell> GetUnvisitedCells(MazeCell currentCell)
    {
        //Az aktu�lis cella poz�ci�j�t egy x �s y v�ltoz�ban tarolja el
        int x = (int)currentCell.transform.localPosition.x;
        int y = (int)currentCell.transform.localPosition.y;

        //Megn�zi, hogy a cell�t�l x szerint "jobbra" van-e lehets�ges k�vetkez� cella
        if (x + 1 < _mazeWidth)
        {
            var cellToRight = _mazeGrid[x + 1, y];

            if (cellToRight.IsVisited == false)
            {
                yield return cellToRight;
            }
        }

        ///Megn�zi, hogy a cell�t�l x szerint "balra" van-e lehets�ges k�vetkez� cella
        if (x - 1 >= 0)
        {
            var cellToLeft = _mazeGrid[x - 1, y];

            if (cellToLeft.IsVisited == false)
            {
                yield return cellToLeft;
            }
        }

        //Megn�zi, hogy a cell�t�l y szerint "felfel�" van-e lehets�ges k�vetkez� cella
        if (y + 1 < _mazeDepth)
        {
            var cellToFront = _mazeGrid[x, y + 1];

            if (cellToFront.IsVisited == false)
            {
                yield return cellToFront;
            }
        }

        //Megn�zi, hogy a cell�t�l y szerint "alatta" van-e lehets�ges k�vetkez� cella

        if (y - 1 >= 0)
        {
            var cellToBack = _mazeGrid[x, y - 1];

            if (cellToBack.IsVisited == false)
            {
                yield return cellToBack;
            }
        }
    }

    //V�letlenszer�en elt�vol�t egy falat bizonyos % es�llyel
    public void LoopGeneration(MazeCell previousCell, MazeCell currentCell)
    {
        //1 �s 10 k�z�tti sz�mot gener�l
        var loop = Random.Range(1, 6);
        //Ha ez a sz�m 1 �s 4 k�z�tt van �s el�z� cella nem null akkor deaktiv�l egy falat
        if ((loop >= 1 && loop <= 4) && previousCell != null)
        {
            //Ha a gener�lt sz�m 1, akkor a jelenlegi cella jobb oldal�t �s az el�z� cella bal oldal�t deaktiv�lja 
            if (loop == 1)
            {
                currentCell.ClearRightWall();
                previousCell.ClearLeftWall();
                return;
            }

            //Ha ez 2 l, akkor a jelenlegi bal oldal�t �s az el�z� jobb oldal�t
            if (loop == 2)
            {
                currentCell.ClearLeftWall();
                previousCell.ClearRightWall();
                return;
            }

            //Ha ez 3 akkor a jelenlegi h�ts� oldal�t �s az el�z� el�ls� oldal�t 
            if (loop == 3)
            {
                currentCell.ClearBackWall();
                previousCell.ClearFrontWall();
                return;
            }

            //Ha ez 4 akkor a jelenlegi el�ls� oldal�t �s az el�z� h�ts� oldal�t 
            if (loop == 4)
            {
                currentCell.ClearFrontWall();
                previousCell.ClearBackWall();
                return;
            }
        }
    }

    //Amelyik ir�nyba halad tov�bb a gener�l�s, a k�vetkez� cella fel� vezet� oldalakat deaktiv�lja
    public void ClearWalls(MazeCell previousCell, MazeCell currentCell)
    {
        //Kiv�ve ha az el�z� cella nem l�tezik 
        if (previousCell == null)
        {
            return;
        }

        //Teh�t ha a jelenlegi cella x szerint "jobbra" van az el�z�h�z k�pest,
        //akkor az el�z� cella jobb oldal�t t�rli �s a jelenlegi bal oldal�t 
        if (previousCell.transform.localPosition.x < currentCell.transform.localPosition.x)
        {
            previousCell.ClearRightWall();
            currentCell.ClearLeftWall();

            return;
        }

        //Ha x szerint balra van, akkor pontosan ford�tva mint az el�bb 
        if (previousCell.transform.localPosition.x > currentCell.transform.localPosition.x)
        {
            previousCell.ClearLeftWall();
            currentCell.ClearRightWall();

            return;
        }

        //Ha a jelenlegi cella y szerint "felfel�" van akkor a jelenlegi eset�ben az el�ls�, el�z� cella eset�ben a h�ts� falakat deaktiv�lja
        if (previousCell.transform.localPosition.y < currentCell.transform.localPosition.y)
        {
            previousCell.ClearBackWall();
            currentCell.ClearFrontWall();

            return;
        }

        //Ha y szerint "lefel�" van, akkor szint�n, pontosan ford�tva deaktiv�lja a falakat
        if (previousCell.transform.localPosition.y > currentCell.transform.localPosition.y)
        {
            previousCell.ClearFrontWall();
            currentCell.ClearBackWall();

            return;
        }
    }

}