using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    public static SceneManage Instance = null;

    public Animator anim;
    public Music[] musicList;
    public Music selectMusic;

    public int level;
    public int score;
    public int combo;

    void Awake()
    {
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

    public void ToStartScene()
    {
        StartCoroutine(TransStartScene());
        //SceneManager.LoadScene(0);
    }

    public void ToGameScene()
    {
        StartCoroutine(TransGameScene());
        //SceneManager.LoadScene(1);
    }


    public void ToEndScene()
    {
        StartCoroutine(TransEndScene());
        //SceneManager.LoadScene(2);
    }

    IEnumerator TransStartScene()
    {
        anim.SetTrigger("trans");
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(0);

    }

    IEnumerator TransGameScene()
    {
        anim.SetTrigger("trans");
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(1);
        
    }

    IEnumerator TransEndScene()
    {
        anim.SetTrigger("trans");
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(2);

    }

 




}
