using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasterEgg : MonoBehaviour
{

    public GameObject topHat;
    // Start is called before the first frame update
    void Start()
    {
        topHat.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("h"))
        {
            topHat.SetActive(true);
        }
    }




}
