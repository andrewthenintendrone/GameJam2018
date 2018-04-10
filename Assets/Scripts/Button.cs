using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

    public GameObject door;	
	void Start ()
    {
        //default the door to not play
        door.GetComponent<Animator>().StopPlayback();
	}

   //When an object hits the button open the door
    private void OnTriggerEnter2D(Collider2D collision)
    {
     
        if (collision.GetComponent<Rigidbody2D>() != null)
        {          
                door.GetComponent<Animator>().SetBool("isOpen",true);           
        }
    }

    //when there is no longer an object on the button close the door
    private void OnTriggerExit2D(Collider2D collision)
    {
        door.GetComponent<Animator>().SetBool("isOpen", false);
    }
}
