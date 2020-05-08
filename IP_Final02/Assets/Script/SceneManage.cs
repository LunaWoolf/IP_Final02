using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//this is the scene Manager. It won;t be destory when change scene and it keeps track of values Pass scene
// Keep track of Music, Difficulty, score and combo
public class SceneManage : MonoBehaviour
{
    public static SceneManage Instance = null;

    public Animator anim; //The Animator for the scene transformation animation
    public Music[] musicList; //The list of music that can be played 
    public Music selectMusic; //The music that player select 

    public int level; // level of Difficulty
    public int score; //score player got 
    public int combo;// highest combo player got

    void Awake()
    {
        // Don't destory this after change scene
        DontDestroyOnLoad(this);
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        
    }

    //Call the coroutine to play trans Scene Animation 
    public void ToStartScene()
    {
        StartCoroutine(TransStartScene());
    }
    //Call the coroutine to play trans Scene Animation 
    public void ToGameScene()
    {
        StartCoroutine(TransGameScene());
    }
    //Call the coroutine to play trans Scene Animation 
    public void ToEndScene()
    {
        StartCoroutine(TransEndScene());
    }

    //Transform to Start scene after playing the transform animation
    IEnumerator TransStartScene()
    {
        anim.SetTrigger("trans");
        yield return new WaitForSeconds(3f); // time to play animation
        SceneManager.LoadScene(0);
    }

    //Transform to Game scene after playing the transform animation
    IEnumerator TransGameScene()
    {
        anim.SetTrigger("trans");
        yield return new WaitForSeconds(3f);// time to play animation
        SceneManager.LoadScene(1);
    }

    //Transform to End scene after playing the transform animation
    IEnumerator TransEndScene()
    {
        anim.SetTrigger("trans");
        yield return new WaitForSeconds(3f);// time to play animation
        SceneManager.LoadScene(2);

    }

 




}
