using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour {
    
	// Use this for initialization
	void Start ()
    {
		
	}

    // Update is called once per frame


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (GetComponent<Animator>().GetBool("isOpen"))
        {
            if (collision.tag == "Player" )
            {
                SceneManager.LoadScene(1);
            }
            
        } 
    }
}
