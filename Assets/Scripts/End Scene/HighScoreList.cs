using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreList : MonoBehaviour
{
    [SerializeField] private Text HighScoreText;

    private List<int> scoreList;
    private List<string> usernameList;

    private int LastScore;
    private string username;


    private void Start()
    {
        LastScore = System.Convert.ToInt32(PlayerPrefs.GetString("Last Score")[1..]);
        username = PlayerPrefs.GetString("username");

        scoreList = new List<int>(){10,9,8,7,6,5,4,3,2,1};
        usernameList = new List<string>(){"name_1","name_2","name_3","name_4","name_5","name_6","name_7","name_8","name_9","name_10"};

        Debug.Log("last score " + LastScore + "\n" + username);


        for (int i=0; i < scoreList.Count; i++)
        {
            if (LastScore >= scoreList[i])
            {
                print("first i: "+i);
                scoreList.RemoveAt(9);
                scoreList.Insert(i, LastScore);

                usernameList.RemoveAt(9);
                usernameList.Insert(i, username);
                break;
            }
            print("second i :"+i);
        }

        HighScores();
    }

    public void HighScores()
    {
        HighScoreText.text = usernameList[0]+ " " + scoreList[0].ToString()+
                        "\n"+ usernameList[1]+ " " + scoreList[1].ToString()+
                        "\n"+ usernameList[2]+ " " + scoreList[2].ToString()+
                        "\n"+ usernameList[3]+ " " + scoreList[3].ToString()+
                        "\n"+ usernameList[4]+ " " + scoreList[4].ToString()+
                        "\n"+ usernameList[5]+ " " + scoreList[5].ToString()+
                        "\n"+ usernameList[6]+ " " + scoreList[6].ToString()+
                        "\n"+ usernameList[7]+ " " + scoreList[7].ToString()+
                        "\n"+ usernameList[8]+ " " + scoreList[8].ToString()+
                        "\n"+ usernameList[9]+ " " + scoreList[9].ToString();
    }
}
