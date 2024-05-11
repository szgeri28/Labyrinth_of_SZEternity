using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeCell : MonoBehaviour
{
    //Falakra hivatkozás
    [SerializeField]
    public GameObject _leftWall;

    [SerializeField]
    public GameObject _rightWall;

    [SerializeField]
    public GameObject _frontWall;

    [SerializeField]
    public GameObject _backWall;
    //meglátogatottságot ellenõrzõ blokk
    [SerializeField]
    public GameObject _unvisitedBlock;

    //cellalátogató bool
    public bool IsVisited { get; private set; }

    //cellalátogató függvény
    public void Visit()
    {
        //igazra állítja a boolt(szóval meglátogatott)
        IsVisited = true;
        //megnézi, hogy ha az unvisitedblock aktív
        if(_unvisitedBlock != null)
        {
            //akkor azt kikapcsoljuk
            _unvisitedBlock.SetActive(false);
        };
    }

    //Falak deaktiválására szolgáló függvények
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
