using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 20;
    public Transform kredit; // A játékos Transform komponense
    public ItemPickup ItemPickup;

    private Rigidbody2D rb;
    private Vector2 direction;
    private Coroutine stopCoroutine;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        FindKredits();
        MoveEnemy();
    }

    void FindKredits()
    {
        GameObject kreditObject = GameObject.FindGameObjectWithTag("Kredit");
        if (kreditObject != null)
        {
            kredit = kreditObject.transform;
        }
    }


    void MoveEnemy()
    {
        if (kredit != null)
        {
            Rotate();

            // Irány vektor kiszámítása a játékos felé
            direction = (kredit.position - transform.position).normalized;

            // Mozgás az irányba
            rb.velocity = direction * moveSpeed;
        }
    }

    private void FixedUpdate()
    {
        if (kredit == null)
        {
            FindKredits(); 
            MoveEnemy();
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Kredit"))
        {
            // Adjon a kredit változóhoz egyet, és ezt adja hozzá a HUDban elhelyezkedõ counterhez is
            ItemPickup.kredit++;
            ItemPickup.kreditText.text = ItemPickup.kredit + "/12";

            StopEnemy();

            if (stopCoroutine != null)
            {
                StopCoroutine(stopCoroutine);
            }

            stopCoroutine = StartCoroutine(StopforSeconds(5f));

            // Ha az összes kreditet felvette, ne keressen többet
            if (ItemPickup.kredit >= 12)
            {
                return;
            }

            // Új kredit keresése
            FindKredits();

            
            if (kredit != null)
            {
                MoveEnemy();

                
                moveSpeed = 2; 
            }
            else
            {
                // Ha nincs új kredit, akkor a mozgás ismételt megállítása
                moveSpeed = 0;
                rb.velocity = Vector2.zero;
            }
        }
    }
    
    public void Rotate()
    {
        var relativePos = kredit.position - transform.position;
        var angle = Mathf.Atan2(relativePos.y, relativePos.x) * Mathf.Rad2Deg + 90;
        var rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = rotation;
    }

    void StopEnemy()
    {
        moveSpeed = 0;
        rb.velocity = direction * moveSpeed; ;
    }

    IEnumerator StopforSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        StartEnemy();
    }

    void StartEnemy()
    {
        direction = (kredit.position - transform.position).normalized;
        rb.velocity = direction * moveSpeed;
    }

}
