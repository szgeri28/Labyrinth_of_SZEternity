using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatSpawning : MonoBehaviour
{
    //kreditre való referálás
    public GameObject itemPrefab;
    //labirintus nagysága
    public int mazeSize = 80;
    //UI számláló
    public int Count = 2;
    public bool IsGenererated = false;

    //Ha felvettük mind a 12 kreditet legenerálja a puskákat
    public void Update()
    {
        if (ItemPickup.kredit == 12 && IsGenererated == false)
        {
            GenerateCheatItems();
            IsGenererated = true;
        }
    }

    //kredit random generálása
    public void GenerateCheatItems()
    {
        //0-tól a kívánt mennyiségig(jelen esetben ez 12)
        for (int i = 0; i < Count; i++)
        {
            //A kredit x koordinátájának randomizálása
            int X = 4 * Random.Range(0, mazeSize / 4);
            //A kredit y koordinátájának randomizálása
            int Y = 4 * Random.Range(0, mazeSize / 4);

            //A legenerált vektorok hozzárendelése egy pozició változóhoz
            Vector2 Position = new Vector2(X, Y);

            //Item generálása
            Instantiate(itemPrefab, Position, Quaternion.identity);
        }
    }
}