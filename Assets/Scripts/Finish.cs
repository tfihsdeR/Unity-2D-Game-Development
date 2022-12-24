using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Finish : MonoBehaviour
{

    private AudioSource finishSoundEffect;

    private Rigidbody2D rb;

    [SerializeField] private Text scoreText;

    [SerializeField] private GameObject player;

    private bool levelFinished = false;

    private void Start()
    {
        finishSoundEffect = GetComponent<AudioSource>();
        rb = player.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {

        if (collision.gameObject.name == "Player" && !levelFinished) 
        {
            levelFinished = true;
            rb.bodyType = RigidbodyType2D.Static;

            // Bitiş müziği çal
            finishSoundEffect.Play();

            Invoke("completeLevel", 2f);

        }

        
    }

    private void completeLevel()
    {
        PlayerPrefs.SetString("Last Score", scoreText.text);
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

}
