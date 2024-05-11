using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Door : MonoBehaviour
{
    //Ajtó prefabre való referálás
    public GameObject closeddoorPrefab;
    public GameObject openeddoorPrefab;
    //labirintus nagysága
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

    // Ha összeszedte a 12 kreditet és még csukva van a kijárat, kinyitja
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

            //Az ajtó x koordinátájának randomizálása
            X = 4 * Random.Range(0, mazeSize / 4);
            //Az ajtó y koordinátájának randomizálása
            Y = 4 * Random.Range(0, mazeSize / 4);

            //A legenerált vektorok hozzárendelése egy pozició változóhoz
            Vector2 Position = new Vector2(X, Y);

            //Ajtó generálása
            currentClosedDoor = Instantiate(closeddoorPrefab, Position, Quaternion.identity);
    }
}
