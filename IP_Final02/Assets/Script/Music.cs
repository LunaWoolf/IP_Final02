using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ScriptableObject for the Music clip.
[CreateAssetMenu(menuName = "Music")]
public class Music : ScriptableObject
{
    public AudioClip musicClip; // music to play
    public float bpm; // the bpm (beat pre minutes) of the music 
}
