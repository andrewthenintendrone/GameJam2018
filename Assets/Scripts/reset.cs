using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;


public class reset : MonoBehaviour
{
    [HideInInspector]
    public bool isPlayerDead;

    
	// Use this for initialization
	void Start ()
    {
        
        isPlayerDead = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.R) || isPlayerDead )
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);            
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Application.isEditor)
            {
                UnityEditor.EditorApplication.isPlaying = false;
            }
            else
            {
                Application.Quit();
            }
            
           
        }
	}
}
