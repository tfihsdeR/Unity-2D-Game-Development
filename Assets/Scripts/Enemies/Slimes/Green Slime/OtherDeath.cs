using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherDeath : MonoBehaviour
{
    private CapsuleCollider2D capcol;
    private Animator anim;

    

    private void Start() 
    {
        capcol = GetComponent<CapsuleCollider2D>();
        anim = GetComponent<Animator>();
    }


    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            death();
        }
    }


    private void death()
    {
        capcol.isTrigger = true;
        anim.SetTrigger("Death");
        //Destroy(slime.GetComponent<Rigidbody2D>());
        Destroy(gameObject, 1.4f);
    }
}
