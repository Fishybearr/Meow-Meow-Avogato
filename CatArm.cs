using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatArm : MonoBehaviour
{
    float randTime = 0;

    public AudioClip meow;
    public AudioClip woosh;

    AudioSource audiO;
    public GameObject arm;
    
   // float duration = 5;

    public GameObject warningIcon;

    Animator anim;
    Vector3 origPos;
    // Start is called before the first frame update
    void Start()
    {
        origPos = gameObject.transform.position;
        anim = arm.GetComponent<Animator>();

        audiO = gameObject.GetComponent<AudioSource>();              ///////////////////////////////////// Make cat arm happen more often if score is higher

        //15 25
        int randInv = Random.Range(15, 25);

        Invoke("CheckForScore", .5f);
        Invoke("catCall", randInv);
    }

    // Update is called once per frame
    void Update()
    {
      /* 
        if (Input.GetKeyDown("e"))
        {
            StartCoroutine(ArmAnim());
        }
      */
       
    }


/*
    IEnumerator attack()
    {

        float time = 0;

        float positionY = Random.Range(-4, 3.9f);

        origPos.y = positionY;

        while (time < duration)
        {
            gameObject.transform.position = Vector3.Lerp(origPos, new Vector3(-.90f, origPos.y, 0), time / duration);
            time += Time.deltaTime;
        }
        

        //gameObject.transform.position = new Vector3(origPos.x, positionY, 0);
        //-.90

        

        yield return null;

    }



    */




    IEnumerator ArmAnim()
    {
        int direction = Random.Range(1, 3);

       

        float posY = Random.Range(-4, 3.9f);

        gameObject.transform.position = new Vector3(origPos.x, posY, 0);

        audiO.PlayOneShot(meow);
        StartCoroutine(Woosh());

        if (direction == 1)
        {
          //  Debug.Log("first");

            gameObject.transform.eulerAngles += 180f * Vector3.up;
            warningIcon.transform.position = new Vector3(0, posY, 0);
        }
        else if(direction == 2)
        {
           // Debug.Log("other");
            warningIcon.transform.position = new Vector3(0, posY, 0); 
             

        }

        /*
        if(gameObject.transform.rotation.y == -180)
        {
            warningIcon.transform.position = new Vector3(1.2f, posY, 0); // Fix this
        }

         else if(gameObject.transform.rotation.y == 0)
        {
            warningIcon.transform.position = new Vector3(-1.2f, posY, 0);
        }

        */




        yield return new WaitForSeconds(1);
        warningIcon.transform.position = new Vector3( 0, 100, 0);

        
        anim.SetBool("Moving", true);
        yield return new WaitForSeconds(2f);
        anim.SetBool("Moving", false);

        //gameObject.transform.eulerAngles -= 180 * Vector3.up;


        
    }


    void catCall()
    { //25,100
        // randTime = Random.Range(25, 100);

        Invoke("catCall", randTime);
        StartCoroutine(ArmAnim());
    }

    void CheckForScore()
    {
        Invoke("CheckForScore", 10);

        if (PlayerPrefs.GetInt("score") >= 10)
        {
            // >= 10, 15,35
            randTime = Random.Range(15, 35);
        }

        else if (PlayerPrefs.GetInt("score") >= 20)
        {

            randTime = Random.Range(10, 25);
        }

        else 
            randTime = Random.Range(25, 100);
    }

    IEnumerator Woosh()
    {
        yield return new WaitForSeconds(1.3f);

        audiO.PlayOneShot(woosh);

    }
}
