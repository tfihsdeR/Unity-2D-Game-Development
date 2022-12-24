using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBS : MonoBehaviour
{
    //private GameObject player;
    private Animator anim;
    private CapsuleCollider2D cc;
    private Rigidbody2D rb;


    [SerializeField] private GameObject slime;
    [SerializeField] private GameObject parentSlime;


    private void Start() 
    {
        //player = GameObject.FindGameObjectWithTag("Player");
        anim = slime.GetComponent<Animator>();
        cc = slime.GetComponent<CapsuleCollider2D>();
        rb = slime.GetComponent<Rigidbody2D>();
    }
    

    /*private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Player")
        {
            death();
        }
    }*/


    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.tag == "Player")
        {
            death();
        }
    }


    private void death()
    {
        cc.isTrigger = true;
        anim.SetTrigger("death");
        Destroy(parentSlime,1.4f);
    }
}
