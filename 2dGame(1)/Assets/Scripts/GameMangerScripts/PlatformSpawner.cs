using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using URandom = UnityEngine.Random;
using Random = System.Random;

public class PlatformSpawner : MonoBehaviour
{
    public float mapLevel = 2;
    public GameObject platform;
    private float randX;
    private Vector2 whereToSpawn;
    private float noLevel = 0f;
    private float yStartHeight = -2;
    public GameObject fin;

    // Update is called once per frame
  

    void Update()
    {
     

        if (noLevel < mapLevel)
        {
            PlatformCreator();
            noLevel++;
            yStartHeight = yStartHeight + 2;
            if (noLevel == mapLevel)
            {
                // spawn finishLine
                whereToSpawn = new Vector2(randX, yStartHeight - 1);
                Instantiate(fin, whereToSpawn, Quaternion.identity);
            }
        }

    }
    void PlatformCreator()
    {
        randX = URandom.Range(GetRandomNumber(), lastNumber);
        whereToSpawn = new Vector2(randX, yStartHeight);
        Instantiate(platform, whereToSpawn, Quaternion.identity);

        Debug.Log(randX.ToString());
    }

    private static int lastNumber;
    private static int iterations = 0;
    public static int GetRandomNumber()
    {
        Random ran = new Random();
        int number = 0; // 0 is a placeholder value
        iterations++;
        if (iterations == 1) // If it is the first number to get - just return a random number
        {
            number = ran.Next(-6, 6);
        }
        if (iterations > 1) // If it isn't - make sure the last number isn't the same as the newly generated random number
        {
            bool foundValidNumber = false;
            while (!foundValidNumber)
            {
                number = ran.Next(-6, 6);
                if (number != lastNumber)
                {
                    foundValidNumber = true;
                }
            }
        }
        // Saving the newly generated number
        lastNumber = number;
        return number;
    }
}






