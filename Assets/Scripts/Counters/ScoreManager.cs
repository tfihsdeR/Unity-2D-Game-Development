using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager instance;

    public Text scoreText;
    private int Score = 0;

    private string lastScore;

    [SerializeField] private AudioSource cherryAudioSource;
    

    void Start()
    {
    if (instance == null)
    {
        instance = this;
    }

    lastScore = PlayerPrefs.GetString("Last Score");


    if (SceneManager.GetActiveScene().name == "Level 1")
    {
        Score = 0;
    }else
    {
        scoreText.text = lastScore;
        Score = System.Convert.ToInt32(scoreText.text[1..]);
    }

    
    }

    public void changeScore(int cherryValue)
    {
        Score+=cherryValue;
        scoreText.text = "X" + Score.ToString();
    }

    public void cherryAudio()
    {
        cherryAudioSource.Play();
    }


}
