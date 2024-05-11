using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Door : MonoBehaviour
{
    //Ajt� prefabre val� refer�l�s
    public GameObject closeddoorPrefab;
    public GameObject openeddoorPrefab;
    //labirintus nagys�ga
    public int mazeSize = 80;
    public int X = 0;
    public int Y = 0;

    public static bool IsOpened = false;
    private GameObject currentClosedDoor;

    // Start is called before the first frame update
    void Start()
    {
        Generate();
    }

    // Ha �sszeszedte a 12 kreditet �s m�g csukva van a kij�rat, kinyitja
    void Update()
    {
        int kreditValue = ItemPickup.kredit;
        if (ItemPickup.kredit == 12 && IsOpened == false)
        {
            Destroy(currentClosedDoor);
            Vector2 Position = new Vector2(X, Y);
            Instantiate(openeddoorPrefab, Position, Quaternion.identity);
            IsOpened = true;
        }
    }

    public void Generate()
    {

            //Az ajt� x koordin�t�j�nak randomiz�l�sa
            X = 4 * Random.Range(0, mazeSize / 4);
            //Az ajt� y koordin�t�j�nak randomiz�l�sa
            Y = 4 * Random.Range(0, mazeSize / 4);

            //A legener�lt vektorok hozz�rendel�se egy pozici� v�ltoz�hoz
            Vector2 Position = new Vector2(X, Y);

            //Ajt� gener�l�sa
            currentClosedDoor = Instantiate(closeddoorPrefab, Position, Quaternion.identity);
    }
}
