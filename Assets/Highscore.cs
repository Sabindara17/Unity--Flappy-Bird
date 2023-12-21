using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Highscore : MonoBehaviour
{
    public PlayerController player;
    public float score;

    public TextMeshProUGUI Scoretext;
    public float Score;

    public TextMeshProUGUI Highscoretext;
    public float HighScore;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();

        if (PlayerPrefs.HasKey("HighScore"))
        {
            HighScore = PlayerPrefs.GetFloat("HighScore");
        }
        else
        {
            HighScore = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Highscoretext.text = HighScore.ToString();
        Scoretext.text=Score.ToString();
        if (player == null)
        {
            SaveHighScore();
        }
    }

    public void SaveHighScore()
    {
        if (Score > PlayerPrefs.GetFloat("HighScore"))
        {
            PlayerPrefs.SetFloat("HighScore", Score);
        }
    }
}
