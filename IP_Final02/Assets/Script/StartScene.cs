using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Manage the UI in the Start Scene
// Pass the value to Scene Manager
public class StartScene : MonoBehaviour
{
    public GameObject chooseMusic; // the music play Choose 
    public GameObject chooseDifficulty; // Difficulty player Choose
    SceneManage sm; // reference to the Scene Manager

    void Start()
    {
        sm = FindObjectOfType<SceneManage>(); // set Scene Manager
        chooseDifficulty.SetActive(false); 
    }

    // Call by the button click
    // return the index and get that index of Music from the music list in sceneManager
    public void selectMusic(int index)
    {
      sm.selectMusic = sm.musicList[index];
      chooseMusic.SetActive (false);
      chooseDifficulty.SetActive(true);
    }

    //Choose the difficulty and pass the result to the Scene Manager
    public void selectDifficulty(int setlevel)
    {
        sm.level = setlevel; // pass the difficulty(level) value to the scene manager
        ToGeameScene(); 
    }

    //call Scene Manager to go to the game scene
    public void ToGeameScene()
    {
        sm.ToGameScene();
    }
}
