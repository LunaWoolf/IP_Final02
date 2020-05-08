using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour
{
    public float bpm;

    public bool start;
    public SceneManage sm;

    void Start()
    {
        sm = FindObjectOfType<SceneManage>();
        bpm = sm.selectMusic.bpm;
        bpm = bpm / 60;
       
        
    }


    void FixedUpdate()
    {
        if (!start)
        {
           //do nothing
        }
        else 
        {
            transform.position -= new Vector3(0, bpm * Time.deltaTime, 0);
        }
       
    }
}
