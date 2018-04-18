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
                StartCoroutine(GameObject.FindObjectOfType<SceneFade>().FadeAndLoadNextScene(SceneFade.FadeDirection.In));
            }
        } 
    }
}
