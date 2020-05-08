using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    public Music[] musicList;

    public static SceneManage Instance = null;

    public Music selectMusic;

    public int level;

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

    void Start()
    {


    }


    void Update()
    {

    }

    IEnumerator ToGameScene()
    {
        //fadeAnim.SetInteger("FadeState", 2);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(1);
    }


}
