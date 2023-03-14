using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOVer : MonoBehaviour
{

    // Set this a place to hold pos for avacado and bool if it should reset position or not
    //Also make it so that hitting the avacdo with mouse more than a couple times in a sec hurts it
    public GameObject dataHandler;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Avacado" || collision.tag == "Mouse")
        {
            //Debug.LogError("Gameover");
        }
    }
}
