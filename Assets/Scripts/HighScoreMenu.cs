using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreMenu : MonoBehaviour
{
    public Text playerName;
    public Text highScore;
    
    // Start is called before the first frame update
    void Start()
    {
        playerName.text = (PlayerPrefs.GetString("PlayerName", ""));
        highScore.text = (PlayerPrefs.GetInt("HighScore", 0)).ToString();
        Debug.Log(highScore);
        Debug.Log(playerName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
