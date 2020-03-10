using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    

 
    void OnTriggerEnter2D(Collider2D collider)
    {
        
        if (collider.gameObject.tag == "Player")
        {
            Debug.Log("game Ended");

            SceneManager.LoadScene(0);
            PlatformSpawner.mapLevel++;
        }

    }
    

}
