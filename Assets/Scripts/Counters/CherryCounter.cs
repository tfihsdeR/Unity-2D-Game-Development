using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryCounter : MonoBehaviour
{
    [SerializeField] private AudioSource cherryAudio;

    public int cherryValue = 1;

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ScoreManager.instance.cherryAudio();
            ScoreManager.instance.changeScore(cherryValue); 
            Destroy(gameObject);
        }
    }

    private void Destroy (GameObject gameObject)
    {
        GameObject.Destroy(gameObject);
    }
}
