using System.Collections;
using UnityEngine;
using UnityEngine.AI;


public class EnemyAI : MonoBehaviour
{
    // Referencia a célpontra, akit az ellenség követ
    [SerializeField] Transform target;

    public Animator animator;


    // Referencia a NavMeshAgent komponensre a navigációhoz
    NavMeshAgent agent;

    // Az ellenség sebessége patrolling és chasing közben
    public float patrolSpeed = 2f;
    public float chaseSpeed = 7f;


    // Idõintervallum a járkáláshoz
    public float patrolTime = 0f;

    // Referencia a játékos transformjára
    private Transform player;

    // Változó, ami jelzi, hogy az ellenség éppen üldözi-e a játékost
    private bool isChasing = false;

    // Detektálási radius a játékos azonosításához
    public float detectionRadius = 20f;

    void Start()
    {
        // Inicializálás és patrolling elindítása
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        // Játékos megtalálása a tag alapján
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Patrolling coroutine indítása
        StartCoroutine(Patrol());
    }

    void Update()
    {
        // Számoljuk ki a távolságot a játékostól
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Ellenõrizzük, hogy a játékos a detektálási radiuson belül van-e
        if (distanceToPlayer < detectionRadius)
        {
            // Ha a játékos a detektálási radiusban van, kezdje el a chasinget
            isChasing = true;
            agent.speed = chaseSpeed;
            StopCoroutine(Patrol()); // Megállítjuk a patrollingot
            agent.SetDestination(player.position); // Beállítjuk a célpontot a játékos pozíciójára
        }
        else if (isChasing)
        {
            // Ha a játékos már nincs a detektálási radiusban, térjen vissza a patrollinghoz
            isChasing = false;
            StartCoroutine(Patrol()); // Újraindítjuk a patrollingot

        }
       
    }

    // Coroutine a patrollingos viselkedéshez
    IEnumerator Patrol()
    {
        agent.speed = patrolSpeed;
        while (true)
        {
            // Beállítunk egy véletlenszerû célpontot a jelenlegi pozíciónk körül
            Vector3 randomDirection = Random.insideUnitSphere * 50f;
            randomDirection += transform.position;

            // Használjuk a NavMesh-et, hogy megtaláljunk egy érvényes pozíciót a megadott területen belül
            NavMeshHit hit;
            NavMesh.SamplePosition(randomDirection, out hit, 50f, 1 << NavMesh.GetAreaFromName("Walkable"));
            agent.SetDestination(hit.position);

            // Várunk a meghatározott patrolling idõre
            yield return new WaitForSeconds(patrolTime);
        }
    }
}