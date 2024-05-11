using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeCell : MonoBehaviour
{
    //Falakra hivatkoz�s
    [SerializeField]
    public GameObject _leftWall;

    [SerializeField]
    public GameObject _rightWall;

    [SerializeField]
    public GameObject _frontWall;

    [SerializeField]
    public GameObject _backWall;
    //megl�togatotts�got ellen�rz� blokk
    [SerializeField]
    public GameObject _unvisitedBlock;

    //cellal�togat� bool
    public bool IsVisited { get; private set; }

    //cellal�togat� f�ggv�ny
    public void Visit()
    {
        //igazra �ll�tja a boolt(sz�val megl�togatott)
        IsVisited = true;
        //megn�zi, hogy ha az unvisitedblock akt�v
        if(_unvisitedBlock != null)
        {
            //akkor azt kikapcsoljuk
            _unvisitedBlock.SetActive(false);
        };
    }

    //Falak deaktiv�l�s�ra szolg�l� f�ggv�nyek
    public void ClearLeftWall()
    {
        _leftWall.SetActive(false);
    }

    public void ClearRightWall()
    {
        _rightWall.SetActive(false);
    }

    public void ClearFrontWall()
    {
        _frontWall.SetActive(false);
    }

    public void ClearBackWall()
    {
        _backWall.SetActive(false);
    }

}
