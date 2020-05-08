using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is for the note sheet that contains notes(arrows) that falls down
//The fall down start when the game start 
public class BeatScroller : MonoBehaviour
{
    public float bpm; //the beat pre minute of the music
    public bool start; //is the game start or not
    public SceneManage sm; //reference to the scene Manager

    void Start()
    {
        sm = FindObjectOfType<SceneManage>(); 
        bpm = sm.selectMusic.bpm; // Get the bpm from the Scene Manager
        bpm = bpm / 60; //divided the bpm by 60, so it becoms "beat pre second".
    }

    void FixedUpdate()
    {
        // The NoteSheet start to move down once the game start
        if (start)
        {
            transform.position -= new Vector3(0, bpm * Time.deltaTime, 0);
        }    
    }
}
