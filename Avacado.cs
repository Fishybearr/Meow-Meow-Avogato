using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Avacado : MonoBehaviour
{
    [Header("Audio")]

    AudioSource aud;

    /*
    public AudioClip hitMouse;
    public AudioClip whiteHit;
    public AudioClip bounceHit;
    public AudioClip greenHit;
    public AudioClip redHit;
    public AudioClip pawHit;
    */

    [Header("Main Stuff")]
    Rigidbody2D rb;

    public GameObject paw;


    public Text showScore;

    public GameObject gmScreen;

    public Text HS;
    public Text newHighScore;

    //public int score = 0;

    

    Vector2 startPos;

    public float pushX;
    public float pushY;

    public GameObject Pick;
    // Start is called before the first frame update
    void Start()
    {

        aud = gameObject.GetComponent<AudioSource>();
        Cursor.visible = false;

        // PlayerPrefs.SetInt("score", 0);

        gmScreen.SetActive(false);

        rb = gameObject.GetComponent<Rigidbody2D>();

        rb.constraints = RigidbodyConstraints2D.FreezeAll;

        startPos = gameObject.transform.position;

        showScore.text = PlayerPrefs.GetInt("score").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }




     void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Mouse")
        {
           // rb.AddForce(new Vector2(pushX, pushY), ForceMode2D.Force);
          //  aud.PlayOneShot(hitMouse); // play mouse hit sound
            
        }

        else if (collision.gameObject.tag == "green")
        {
            //aud.PlayOneShot(greenHit);
           // Debug.Log("Change");

            paw.GetComponent<Animator>().SetBool("Moving", false); // Don't think this works

            PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") + 1);// score++;
            showScore.text = PlayerPrefs.GetInt("score").ToString(); //score.ToString();

            gameObject.transform.position = startPos;
            rb.velocity = new Vector2(0, 0);
            rb.rotation = 90;

            Pick.GetComponent<Picker>().ResetLayout();
        }

        else if (collision.gameObject.tag == "bounce")
        {
           // aud.PlayOneShot(bounceHit);
        }

        else if (collision.gameObject.tag == "Spike" )
        {
            //aud.PlayOneShot(redHit);

            Gameover();
        }

        else if ( collision.gameObject.tag == "Paw")
        {
           // aud.PlayOneShot(pawHit);
            Gameover();
        }


       
    }


    public void StartGame()
    {
        rb.constraints = RigidbodyConstraints2D.None;
    }

    public void Gameover()
    {
        Cursor.visible = true;
        if (PlayerPrefs.GetInt("score") > PlayerPrefs.GetInt("Hscore"))
        {
            PlayerPrefs.SetInt("Hscore", PlayerPrefs.GetInt("score"));

            newHighScore.text = "New High Score";
        }

        else
            newHighScore.text = "";

        HS.text = PlayerPrefs.GetInt("Hscore").ToString();

        gameObject.transform.position = startPos;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;

        gmScreen.SetActive(true);
    }

    public void RestartLevel()
    {
        PlayerPrefs.SetInt("score", 0);
        SceneManager.LoadScene(1);
    }

    public void toMenu()
    {
        PlayerPrefs.SetInt("score", 0);
        SceneManager.LoadScene(0);
        
    }

/*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "white")
        {
            aud.PlayOneShot(whiteHit);
        }
    }
*/




}
