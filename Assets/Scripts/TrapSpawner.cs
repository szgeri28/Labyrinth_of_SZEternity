using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSpawning : MonoBehaviour
{
    //Prefabre referálás
    public GameObject itemPrefab;
    //Labirintus alap mérete
    public int mazeSize = 80;
    //Csapdák száma
    public int Count = 30;

    void Start()
    {
        GenerateTraps();
    }

    //Csapdák generálása
    public void GenerateTraps()
    {
        for (int i = 0; i < Count; i++)
        {
            //x és y koordináták meghatározása és csapda legenerálása
            int X = NumRandom(mazeSize);
            int Y = NumRandom(mazeSize);
            Vector2 Position = new Vector2(X, Y);
            Instantiate(itemPrefab, Position, Quaternion.identity);
        }
    }

    //Csapda helyének randomizálása
    public int NumRandom(int mazeSize)
    {
        //Határok beállítása
        int x = Random.Range(-1, mazeSize - 1);

        //Az elsõ cellán belül lehet
        if( x < 2)
        {
            return x;
        }
        //Ne generálódjon falba
        else if((x - 2) % 4 == 0)
        {
            return NumRandom(mazeSize);
        }
        //Ne generálódjon a cellák közepére (kreditek helye)
        else if (x % 4 == 0 || x == 0)
        {
            return NumRandom(mazeSize);
        }
        //Ha a fentiek nem teljesülnek akkor szabad a hely a generáláshoz
        else
        {
            return x;
        }
    }
}