using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Speed kezdeti �rt�ke
    public float moveSpeed = 5f;
    //Fizika hozz�rendel�se a karakterhez
    public Rigidbody2D rb;
    public Animator animator;

    Vector2 movement;
    
    void Update()
    {
        //Ir�nyzatok hozz�rendel�se a movementhez
       movement.x = Input.GetAxisRaw("Horizontal");
       movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        //normalized a keresztir�ny� mozg�sban seg�t(en�lk�l a karakter 40 % -al gyorsabb keresztir�nyban)
        movement = new Vector2 (movement.x, movement.y).normalized;
    }

    void FixedUpdate() 
    {
        //Elmozdul�s a sebess�g �s id� f�ggv�ny�ben
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        

    }
}
