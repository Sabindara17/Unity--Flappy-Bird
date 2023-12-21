using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject player;
   
    public float gravity = 2.5f;
    public float jump = 7f;
    public float speed = 6f;
    public bool canplay;
    float rotation;

    //Sound
    public AudioSource Jumpaudio;    
    public AudioSource overAudio;
    public AudioSource scoreAudio;

    //highscore
     
     int highscore;
    public TMP_Text highscoreText;



    // Start is called before the first frame update
    void Start()
    {
        player.GetComponent<Rigidbody2D>().gravityScale = 0;
        player.GetComponent<Animator>().enabled = false;


        highscore = PlayerPrefs.GetInt("HighScore");
        highscoreText.GetComponent<TMP_Text>().text =$"HighScore = {highscore.ToString()}";
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canplay)
        {

           
            player.GetComponent<Animator>().enabled = true;

            if (Input.GetKeyDown(KeyCode.Space) || (Input.touchCount >0) || (Input.GetMouseButtonDown(0)))
            {
                //direction = Vector2.up * strength;
                player.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, jump);
                player.GetComponent<Rigidbody2D>().gravityScale = gravity;

                
                Jumpaudio.Play();
            }
            if (rb.velocity.y > 0 && rotation < 30)
            {
                rotation += 4;
                transform.eulerAngles = new Vector3(0, 0, rotation);
            }
            if (rb.velocity.y < 0 && rotation > -30)
            {
                rotation -= 4;
                transform.eulerAngles = new Vector3(0, 0, rotation);
            }




        }

        if ((player.transform.position.y > 5.6f) || (player.transform.position.y < -5.41f))
        {
            Debug.Log("Is Touched");
            FindObjectOfType<GameManager>().GameOver();
        }



        //if (Input.GetKeyDown(KeyCode.S))
        //{
        //    canplay = true;
        //}

        if (Input.GetKeyDown(KeyCode.P))
        {
            canplay = false;
        }

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if ((other.gameObject.tag =="Obstacle"))
        {
            //Debug.Log("Is Touched");
            FindObjectOfType<GameManager>().GameOver();
            player.GetComponent<Animator>().enabled = false;

            overAudio.Play();

          
            
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.gameObject.tag == "Scoring"))
        {
            FindObjectOfType<GameManager>().IncreaseScore();

            scoreAudio.Play();
            

        }

        if(FindObjectOfType<GameManager>().Score > highscore)
        {
            highscore = FindObjectOfType<GameManager>().Score;
            highscoreText.GetComponent<TMP_Text>().text = $"HighScore : {highscore}";
            PlayerPrefs.SetInt("HighScore", highscore);
        }


        
    }



}
