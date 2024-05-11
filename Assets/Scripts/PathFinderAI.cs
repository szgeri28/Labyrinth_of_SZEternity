using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PathFinderAI : MonoBehaviour
{
    [SerializeField] Transform target;
    //�gens l�trehoz�sa agnes n�ven, NavMesh-t alkalmazunk
    NavMeshAgent agens;

    void Start()
    {
        agens = GetComponent<NavMeshAgent>();
        agens.updateRotation = false;
        agens.updateUpAxis = false; 
    }

    // Be�ll�tjuk az �gens c�lpontj�t, azaz mag�t a j�t�kost
    void Update()
    {
        agens.SetDestination(target.position);
    }
}
