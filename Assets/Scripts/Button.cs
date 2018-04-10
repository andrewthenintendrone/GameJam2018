using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{    
    public GameObject door;
    public List<GameObject> otherButtons;
    private bool pressed = false;


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
            pressed = true;
        }

        bool allPreseed = true;
        foreach(GameObject currentButton in otherButtons)
        {
            if(!currentButton.GetComponent<Button>().pressed)
            {
                allPreseed = false;
            }
        }

        if(allPreseed)
        {
            door.GetComponent<Animator>().SetBool("isOpen", true);
        }
    }

    //when there is no longer an object on the button close the door
    private void OnTriggerExit2D(Collider2D collision)
    {
        pressed = false;
        door.GetComponent<Animator>().SetBool("isOpen", false);
    }
}
