using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherDeathBS : MonoBehaviour
{
    private CapsuleCollider2D capcol;
    private Animator anim;
    private Rigidbody2D rb;

    

    private void Start() 
    {
        capcol = GetComponent<CapsuleCollider2D>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
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
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
        //Destroy(slime.GetComponent<Rigidbody2D>());
        Destroy(gameObject, 1.4f);
    }
}
