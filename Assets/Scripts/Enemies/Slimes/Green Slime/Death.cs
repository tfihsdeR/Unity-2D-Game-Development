using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    //private GameObject player;
    private Animator anim;
    private CapsuleCollider2D cc;


    [SerializeField] private GameObject slime;
    [SerializeField] private GameObject parentSlime;

    private CapsuleCollider2D capCol;


    private void Start() 
    {
        //player = GameObject.FindGameObjectWithTag("Player");
        anim = slime.GetComponent<Animator>();
        cc = slime.GetComponent<CapsuleCollider2D>();
        capCol = GetComponent<CapsuleCollider2D>();
    }
    

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Player")
        {
            capCol.enabled = false;
            slime.GetComponent<CapsuleCollider2D>().enabled = false;
            death();
        }
    }


    private void death()
    {
        cc.isTrigger = true;
        anim.SetTrigger("Death");
        //Destroy(slime.GetComponent<Rigidbody2D>());
        Destroy(parentSlime,1.4f);
    }
}
