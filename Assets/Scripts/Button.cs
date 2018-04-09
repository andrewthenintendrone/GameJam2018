using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

    public GameObject door;
	// Use this for initialization
	void Start ()
    {
        door.GetComponent<Animator>().StopPlayback();
	}

    private void Update()
    {
        
    }
    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
     
        if (collision.GetComponent<Rigidbody2D>() != null)
        {


            if (collision.GetComponent<Rigidbody2D>().mass >= 3)
            {
               // transform.localScale -= new Vector3(0, 0.1f, 0) * Time.deltaTime;
                // transform.position -= new Vector3(0, 0.1f, 0) * Time.deltaTime;
                door.GetComponent<Animator>().SetBool("isOpen",true);

                //Debug.Log(door.GetComponent<Animator>().speed);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        door.GetComponent<Animator>().SetBool("isOpen", false);
    }
}
