using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScene : MonoBehaviour
{
    public GameObject chooseMusic;
    public GameObject chooseDifficulty;
    SceneManage sm;

    void Start()
    {
        sm = FindObjectOfType<SceneManage>();
        chooseDifficulty.SetActive(false);
    }


    public void selectMusic(int index)
    {
      sm.selectMusic = sm.musicList[index];

      chooseMusic.SetActive (false);
      chooseDifficulty.SetActive(true);
    }

    public void selectDifficulty(int setlevel)
    {
        sm.level = setlevel;
        ToGeameScene();
    }

    public void ToGeameScene()
    {
        sm.ToGameScene();
    }
}
