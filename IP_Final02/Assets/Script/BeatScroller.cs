using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour
{
    public float bpm;

    public bool start;
    
    void Start()
    {
        bpm = bpm / 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (!start)
        {
           
        }
        else
        {
            transform.position -= new Vector3(0, bpm * Time.deltaTime, 0);
        }
       
    }
}
