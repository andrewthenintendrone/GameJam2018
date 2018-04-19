using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

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
        if (Input.GetAxisRaw("Reset") > 0 || isPlayerDead )
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);            
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #endif
            Application.Quit();
        }
	}
}
