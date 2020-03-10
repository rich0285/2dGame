using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeLevel : MonoBehaviour
{
    public Text changeLvl;

    void Update()
    {
        CurrentLevel();
    }
  public void CurrentLevel()
  {
      changeLvl.text ="Map Level: "+ PlatformSpawner.mapLevel.ToString();

  }
}
