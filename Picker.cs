using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Picker : MonoBehaviour
{

    public AudioMixer music;
    public GameObject av;
    public GameObject mouse;

    public Sprite green;
    public Sprite white;
    public Sprite red;
    public Sprite bounce;

    int scoreRef;

    public List<GameObject> Boxes;
    // Start is called before the first frame update
    void Start()
    {
        music.SetFloat("MusicVol", PlayerPrefs.GetFloat("mVol"));

        ResetLayout();

       
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.X))
        {
            ResetLayout();
        }
        */

        scoreRef = PlayerPrefs.GetInt("score");//av.GetComponent<Avacado>().score;
    }




    public void ResetLayout()
    {
        for(int x = 0; x <= 17; x++)
        {
            if(x == 7 || x == 8 || x == 9)
            {
                Boxes[x].GetComponent<SpriteRenderer>().sprite = bounce;
                Boxes[x].tag = "bounce";
            }

            else
            {
                Boxes[x].GetComponent<SpriteRenderer>().sprite = white;
                Boxes[x].tag = "white";
            }
            
        }

        int spikes = 0;
        if(scoreRef <= 5)
        {
             spikes = Random.Range(1, 5);
        }

        else if(scoreRef <= 15)
        {
             spikes = Random.Range(5, 10);
          
        }

        else 
        {
            spikes = Random.Range(10, 15);
            mouse.transform.localScale = new Vector3(mouse.transform.localScale.x * .75f, mouse.transform.localScale.y * .75f, mouse.transform.localScale.z * .75f);
        }

        /*
        if(scoreRef == 10)
        {
            mouse.transform.localScale = new Vector3(mouse.transform.localScale.x * .75f, mouse.transform.localScale.y * .75f, mouse.transform.localScale.z * .75f);
        }

        
        else if(scoreRef == 20)
        {
            mouse.transform.localScale = new Vector3(mouse.transform.localScale.x * .75f, mouse.transform.localScale.y * .75f, mouse.transform.localScale.z * .75f);
        }
        */
        

        // Doesn't account for repeats

        for(int i = 0; i < spikes; i++)
        {
            int tileNum = Random.Range(0, 17);

            while(tileNum == 7 || tileNum == 8 || tileNum == 9)
            {
                tileNum = Random.Range(0, 17);
            }

            Boxes[tileNum].GetComponent<SpriteRenderer>().sprite = red;
            Boxes[tileNum].tag = "Spike";
        }

        int greenTile = Random.Range(0, 17);

        Boxes[greenTile].GetComponent<SpriteRenderer>().sprite = green;

        Boxes[greenTile].tag = "green";


        /*
        if (greenTile <= 16)
        {
            Boxes[greenTile + 1].GetComponent<SpriteRenderer>().sprite = white;
            Boxes[greenTile + 1].tag = "white";
        }

        else
        {
            Boxes[greenTile - 1].GetComponent<SpriteRenderer>().sprite = white;
            Boxes[greenTile - 1].tag = "white";
        }

        */
        

       
    }
}
