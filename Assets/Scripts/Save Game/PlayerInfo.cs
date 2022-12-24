using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    public string level;
    public Text score;

    public void Start() 
    {
        level = SceneManager.GetActiveScene().name;
    }


    public void saveGame()
    {
        SaveSystem.SaveGame(this);
    }

    public void loadGame()
    {
        GameData data = SaveSystem.LoadGame();

        level = data.level;
        score.text = data.score;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];

        transform.position = position;
    }
}
