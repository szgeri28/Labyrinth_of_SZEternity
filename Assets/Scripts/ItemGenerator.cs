using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    //kreditre val� refer�l�s
    public GameObject itemPrefab; 
    //labirintus nagys�ga
    public int mazeSize = 80;
    //UI sz�ml�l�
    public int Count;


    public void Start()
    {
        GenerateRandomItem();
    }

    //kredit random gener�l�sa
    public void GenerateRandomItem()
    {
        //0-t�l a k�v�nt mennyis�gig(jelen esetben ez 12)
        for (int i = 0; i < Count; i++)
        {
            //A kredit x koordin�t�j�nak randomiz�l�sa
            int X = 4 * Random.Range(0, mazeSize / 4);
            //A kredit y koordin�t�j�nak randomiz�l�sa
            int Y = 4 * Random.Range(0, mazeSize / 4);

            //A legener�lt vektorok hozz�rendel�se egy pozici� v�ltoz�hoz
            Vector2 Position = new Vector2(X, Y);

            //Item gener�l�sa
            Instantiate(itemPrefab, Position, Quaternion.identity);
        }
    }
}