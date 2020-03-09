using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    

     PlatformSpawner pfs;
    void OnTriggerEnter2D(Collider2D collider)
    {
        pfs = GameObject.FindObjectOfType<PlatformSpawner>();
        
       
        if (collider.gameObject.tag == "Player")
        {
            Debug.Log("game Ended");
            
            
            SceneManager.LoadScene(1);
            pfs.mapLevel++;


        }

    }
    

}
