using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScene : MonoBehaviour
{
    SceneManage sm;
    public Animator anim;
    public GameObject scoreText;
    public GameObject comboText;

    void Start()
    {
        sm = FindObjectOfType<SceneManage>();
        sm.anim = anim;
        scoreText.GetComponent<Text>().text = "Score: " + sm.score;
        comboText.GetComponent<Text>().text = "Highest Combo: " + sm.combo;
    }

    public void ToStartScene()
    {
        sm.ToStartScene();
    }

}
