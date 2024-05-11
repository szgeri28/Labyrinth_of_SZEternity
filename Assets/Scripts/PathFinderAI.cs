using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PathFinderAI : MonoBehaviour
{
    [SerializeField] Transform target;
    //Ágens létrehozása agnes néven, NavMesh-t alkalmazunk
    NavMeshAgent agens;

    void Start()
    {
        agens = GetComponent<NavMeshAgent>();
        agens.updateRotation = false;
        agens.updateUpAxis = false; 
    }

    // Beállítjuk az Ágens célpontját, azaz magát a játékost
    void Update()
    {
        agens.SetDestination(target.position);
    }
}
