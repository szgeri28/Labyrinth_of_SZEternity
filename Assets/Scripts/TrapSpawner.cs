using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSpawning : MonoBehaviour
{
    //Prefabre refer�l�s
    public GameObject itemPrefab;
    //Labirintus alap m�rete
    public int mazeSize = 80;
    //Csapd�k sz�ma
    public int Count = 30;

    void Start()
    {
        GenerateTraps();
    }

    //Csapd�k gener�l�sa
    public void GenerateTraps()
    {
        for (int i = 0; i < Count; i++)
        {
            //x �s y koordin�t�k meghat�roz�sa �s csapda legener�l�sa
            int X = NumRandom(mazeSize);
            int Y = NumRandom(mazeSize);
            Vector2 Position = new Vector2(X, Y);
            Instantiate(itemPrefab, Position, Quaternion.identity);
        }
    }

    //Csapda hely�nek randomiz�l�sa
    public int NumRandom(int mazeSize)
    {
        //Hat�rok be�ll�t�sa
        int x = Random.Range(-1, mazeSize - 1);

        //Az els� cell�n bel�l lehet
        if( x < 2)
        {
            return x;
        }
        //Ne gener�l�djon falba
        else if((x - 2) % 4 == 0)
        {
            return NumRandom(mazeSize);
        }
        //Ne gener�l�djon a cell�k k�zep�re (kreditek helye)
        else if (x % 4 == 0 || x == 0)
        {
            return NumRandom(mazeSize);
        }
        //Ha a fentiek nem teljes�lnek akkor szabad a hely a gener�l�shoz
        else
        {
            return x;
        }
    }
}