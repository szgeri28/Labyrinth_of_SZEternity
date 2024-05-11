using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//Véletlenszerû labirintus generátor 
public class MazeGenerator : MonoBehaviour
{
    [SerializeField]
    //Egy cella sémája
    public MazeCell _mazeCellPrefab;

    [SerializeField]
    //Hány cella széles legyen a generált Grid
    public int _mazeWidth = 20;

    [SerializeField]
    //Hány cella "magasságú" legyen a generált Grid
    public int _mazeDepth = 20;

    //A Grid lényegében egy, a cellákból felépített halót alkot 
    public MazeCell[,] _mazeGrid;

    //Feltölti a Gridet a cellákkal két for ciklus segítségével 
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

        //Elindítja a labirintus tényleges generálását 
        GenerateMaze(null, _mazeGrid[0, 0]);
    }

    public void GenerateMaze(MazeCell previousCell, MazeCell currentCell)
    {
        //A jelenlegi cellát "meglátogatja" ezzel jelezve hogy ezt legenerálta
        currentCell.Visit();
        //Deaktiválja a falakat az elõzõ és a jelenlegi cella között 
        ClearWalls(previousCell, currentCell);
        //Bizonyos %-al véletlenszerûen deaktivál egy szintén véletlenszerû falat az aktuális cellában
        LoopGeneration(previousCell, currentCell);

        MazeCell nextCell;

        do
        {
            //Kiválasztja melyik környezõ cella legyen a következõ amit legenerál
            nextCell = GetNextUnvisitedCell(currentCell);

            //Amíg van következõ cella addig folytatja
            if (nextCell != null)
            {
                GenerateMaze(currentCell, nextCell);
            }
        } while (nextCell != null);
    }

    //Megkeresi a környezõ, még meg nem látogatott cellákat és véletlenszerûen kiválaszt egyet
    public MazeCell GetNextUnvisitedCell(MazeCell currentCell)
    {
        var unvisitedCells = GetUnvisitedCells(currentCell);

        return unvisitedCells.OrderBy(_ => Random.Range(1, 10)).FirstOrDefault();
    }

    //Megkeresi a lehetséges következõ cellákat
    public IEnumerable<MazeCell> GetUnvisitedCells(MazeCell currentCell)
    {
        //Az aktuális cella pozícióját egy x és y változóban tarolja el
        int x = (int)currentCell.transform.localPosition.x;
        int y = (int)currentCell.transform.localPosition.y;

        //Megnézi, hogy a cellától x szerint "jobbra" van-e lehetséges következõ cella
        if (x + 1 < _mazeWidth)
        {
            var cellToRight = _mazeGrid[x + 1, y];

            if (cellToRight.IsVisited == false)
            {
                yield return cellToRight;
            }
        }

        ///Megnézi, hogy a cellától x szerint "balra" van-e lehetséges következõ cella
        if (x - 1 >= 0)
        {
            var cellToLeft = _mazeGrid[x - 1, y];

            if (cellToLeft.IsVisited == false)
            {
                yield return cellToLeft;
            }
        }

        //Megnézi, hogy a cellától y szerint "felfelé" van-e lehetséges következõ cella
        if (y + 1 < _mazeDepth)
        {
            var cellToFront = _mazeGrid[x, y + 1];

            if (cellToFront.IsVisited == false)
            {
                yield return cellToFront;
            }
        }

        //Megnézi, hogy a cellától y szerint "alatta" van-e lehetséges következõ cella

        if (y - 1 >= 0)
        {
            var cellToBack = _mazeGrid[x, y - 1];

            if (cellToBack.IsVisited == false)
            {
                yield return cellToBack;
            }
        }
    }

    //Véletlenszerûen eltávolít egy falat bizonyos % eséllyel
    public void LoopGeneration(MazeCell previousCell, MazeCell currentCell)
    {
        //1 és 10 közötti számot generál
        var loop = Random.Range(1, 6);
        //Ha ez a szám 1 és 4 között van és elõzõ cella nem null akkor deaktivál egy falat
        if ((loop >= 1 && loop <= 4) && previousCell != null)
        {
            //Ha a generált szám 1, akkor a jelenlegi cella jobb oldalát és az elõzõ cella bal oldalát deaktiválja 
            if (loop == 1)
            {
                currentCell.ClearRightWall();
                previousCell.ClearLeftWall();
                return;
            }

            //Ha ez 2 l, akkor a jelenlegi bal oldalát és az elõzõ jobb oldalát
            if (loop == 2)
            {
                currentCell.ClearLeftWall();
                previousCell.ClearRightWall();
                return;
            }

            //Ha ez 3 akkor a jelenlegi hátsó oldalát és az elõzõ elülsõ oldalát 
            if (loop == 3)
            {
                currentCell.ClearBackWall();
                previousCell.ClearFrontWall();
                return;
            }

            //Ha ez 4 akkor a jelenlegi elülsõ oldalát és az elõzõ hátsó oldalát 
            if (loop == 4)
            {
                currentCell.ClearFrontWall();
                previousCell.ClearBackWall();
                return;
            }
        }
    }

    //Amelyik irányba halad tovább a generálás, a következõ cella felé vezetõ oldalakat deaktiválja
    public void ClearWalls(MazeCell previousCell, MazeCell currentCell)
    {
        //Kivéve ha az elõzõ cella nem létezik 
        if (previousCell == null)
        {
            return;
        }

        //Tehát ha a jelenlegi cella x szerint "jobbra" van az elõzõhöz képest,
        //akkor az elõzõ cella jobb oldalát törli és a jelenlegi bal oldalát 
        if (previousCell.transform.localPosition.x < currentCell.transform.localPosition.x)
        {
            previousCell.ClearRightWall();
            currentCell.ClearLeftWall();

            return;
        }

        //Ha x szerint balra van, akkor pontosan fordítva mint az elõbb 
        if (previousCell.transform.localPosition.x > currentCell.transform.localPosition.x)
        {
            previousCell.ClearLeftWall();
            currentCell.ClearRightWall();

            return;
        }

        //Ha a jelenlegi cella y szerint "felfelé" van akkor a jelenlegi esetében az elülsõ, elõzõ cella esetében a hátsó falakat deaktiválja
        if (previousCell.transform.localPosition.y < currentCell.transform.localPosition.y)
        {
            previousCell.ClearBackWall();
            currentCell.ClearFrontWall();

            return;
        }

        //Ha y szerint "lefelé" van, akkor szintén, pontosan fordítva deaktiválja a falakat
        if (previousCell.transform.localPosition.y > currentCell.transform.localPosition.y)
        {
            previousCell.ClearFrontWall();
            currentCell.ClearBackWall();

            return;
        }
    }

}