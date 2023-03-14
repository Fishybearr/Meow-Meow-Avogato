using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    public GameObject Avacado;

    bool touchingAv = false;

    public float moveSpeed;

    Vector3 mousePos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Input.mousePosition;

        mousePos = Camera.main.ScreenToWorldPoint(mousePos);



        transform.position = new Vector3 (mousePos.x,mousePos.y,0); // Change this to an instant lerp

        //transform.position = Vector2.Lerp(transform.position, new Vector3(mousePos.x,mousePos.y,0), moveSpeed);



    }


    /*
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Avacado")
        {
            Avacado.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 200));
        }
    }

    */


/*
    IEnumerator canCollider()
    {
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        yield return new WaitForSeconds(.2f);

        if(touchingAv == false)
        {
            gameObject.GetComponent<CircleCollider2D>().enabled = true;
        }
        
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Avacado")
        {
            touchingAv = true;
            StartCoroutine(canCollider());
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Avacado")
        {
            touchingAv = false;
        }
    }

    */
}
