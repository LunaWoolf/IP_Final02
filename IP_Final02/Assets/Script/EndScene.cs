using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Manage UI in the End Scene
// Pass the value to Scene Manager
public class EndScene : MonoBehaviour
{
    SceneManage sm; // reference to the Scene Manager
    public Animator transanim; // The scene transformation animator
    public GameObject scoreText; //reference of the Game Object of the score Text 
    public GameObject comboText; //reference of the Game Object of the combo Text 

    void Start()
    {
        sm = FindObjectOfType<SceneManage>();
        sm.anim = transanim; // pass the animator value to the scene Manage
        scoreText.GetComponent<Text>().text = "Score: " + sm.score; // Get the score and combo from Scene Manager change the text
        comboText.GetComponent<Text>().text = "Highest Combo: " + sm.combo;
    }

    //Go to start Scene when click the button
    public void ToStartScene()
    {
        sm.ToStartScene();
    }

}
