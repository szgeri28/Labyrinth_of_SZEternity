using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Speed kezdeti értéke
    public float moveSpeed = 5f;
    //Fizika hozzárendelése a karakterhez
    public Rigidbody2D rb;
    public Animator animator;

    Vector2 movement;
    
    void Update()
    {
        //Irányzatok hozzárendelése a movementhez
       movement.x = Input.GetAxisRaw("Horizontal");
       movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        //normalized a keresztirányú mozgásban segít(enélkül a karakter 40 % -al gyorsabb keresztirányban)
        movement = new Vector2 (movement.x, movement.y).normalized;
    }

    void FixedUpdate() 
    {
        //Elmozdulás a sebesség és idõ függvényében
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        

    }
}
