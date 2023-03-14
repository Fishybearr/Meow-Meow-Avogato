using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioZones : MonoBehaviour
{
   

    AudioSource sound;

   public AudioClip normalHit;
    public AudioClip bounce;

    AudioClip soundToPlay;
    public bool isBounce;
    // Start is called before the first frame update
    void Start()
    {

       

        if(isBounce == true)
        {
            soundToPlay = bounce;
        }
        else if (isBounce == false)
        {

            soundToPlay = normalHit;
        }

        sound = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
         if(collision.tag == "Avacado")
        {
            sound.PlayOneShot(soundToPlay);
        }
    }
}
