using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject cameraa;
    public GameObject[] pipes;
    public int Score;
    float startpos = 0;
    

    
    //UI
    public Button Startbtn;
    public TMP_Text Gameover;
    public TMP_Text Scores;

   

  
 

    // Start is called before the first frame update
    void Start()
    {
        
        Startbtn.enabled = true;
        Gameover.text = "";
        Score = 0;




        for (int i = 0; i < 3; i++)

        {
            startpos += 8;
            Instantiate(pipes[Random.Range(0, pipes.Length)], new Vector2(startpos, Random.Range(-2.0f, 2.0f)), Quaternion.identity);
        }

       
       

    }
    public void GenerateNewPipe()
    {
        startpos += 8;
        Instantiate(pipes[Random.Range(0, pipes.Length)], new Vector2(startpos, Random.Range(-2.0f, 2.0f)), Quaternion.identity);
    }


    // Update is called once per frame
    void Update()
    {
        if(player.GetComponent<PlayerController>().canplay) 
            cameraa.transform.position = new Vector3(player.transform.position.x, 0, -10);

       
    }
    
    

    public void GameOver()
    {
        player.GetComponent<PlayerController>().canplay = false;

        Debug.Log("Game Over");
        Gameover.text = "Game Over";
        player.gameObject.SetActive(true);
        

        StartCoroutine(Over());       
    }

   IEnumerator Over()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("GameOver");

    }

    

    public void StartGame()
    {
        player.GetComponent<PlayerController>().canplay = true;
        Startbtn.gameObject.SetActive(false);
        
        Scores.text = Score.ToString();

       
    }

    public void IncreaseScore()
    {
        Score++;
        Debug.Log("Score: " + Score);
        Scores.text = Score.ToString();
        GenerateNewPipe();

        if(Score > 5)
        {
            player.GetComponent<PlayerController>().speed += 0.5f;
            player.GetComponent<PlayerController>().gravity += 0.2f;
        }

        
    }


   
   

    
}
