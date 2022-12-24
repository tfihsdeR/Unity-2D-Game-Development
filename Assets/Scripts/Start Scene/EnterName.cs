using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnterName : MonoBehaviour
{
    private string username;
    [SerializeField] GameObject inputName;
    [SerializeField] Text displayWelcome;

    public void storeName()
    {
        username = inputName.GetComponent<Text>().text;
        displayWelcome.GetComponent<Text>().text = "Welcome " + username +" to the game!";
        PlayerPrefs.SetString("username", username);
    }
}
