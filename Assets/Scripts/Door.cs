using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (GetComponent<Animator>().GetBool("isOpen"))
        {
            if (collision.tag == "Player")
            {
                if(SceneManager.GetActiveScene().buildIndex + 1 == SceneManager.sceneCountInBuildSettings)
                {
                    Application.Quit();
                }
               SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);                              
            }
        } 
    }
}
