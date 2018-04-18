using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{    
    public GameObject door;
    private List<Button> otherButtons = new List<Button>();
    private bool pressed = false;


	void Start ()
    {
        // find other buttons
        foreach(Button currentButton in GameObject.FindObjectsOfType<Button>())
        {
            // ignore self
            if(currentButton != this)
            {
                otherButtons.Add(currentButton);
            }
        }
	}

   //When an object hits the button open the door
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Rigidbody2D>() != null)
        {
            pressed = true;
        }

        bool allPreseed = true;
        foreach(Button currentButton in otherButtons)
        {
            if(!currentButton.pressed)
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
