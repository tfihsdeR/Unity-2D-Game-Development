using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowPortal : MonoBehaviour
{
    [SerializeField] private Transform teleportTo;
    [SerializeField] private GameObject player;

    private Animator anim;
    private Animator playerAnim;
    private Rigidbody2D playerRb;


    private void Awake() 
    {
        anim = GetComponent<Animator>();
        playerAnim = player.GetComponent<Animator>();
        playerRb = player.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        playerAnim.enabled = false;
        Invoke("HidePlayer", 1.5f);
        Invoke("TeleportPlayer", 2);
    }


    private void TeleportPlayer()
    {
        player.transform.position = teleportTo.transform.position;
        anim.enabled = false;
        Invoke("DisplayPlayer", 2);
    }


    private void DisplayPlayer()
    {
        player.SetActive(true);
        playerAnim.enabled = true;
        playerRb.bodyType = RigidbodyType2D.Dynamic;
    }


    private void HidePlayer()
    {
        player.SetActive(false);
    }
}
