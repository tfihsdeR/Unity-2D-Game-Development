using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator anim;


    [SerializeField] private AudioSource deathSoundEffect;

    public Text scoreText;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.CompareTag("Trap") || collision.gameObject.CompareTag("Slime"))
        {
            Die();
        }

    }

    public void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        deathSoundEffect.Play();
        anim.SetTrigger("death");
        
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
