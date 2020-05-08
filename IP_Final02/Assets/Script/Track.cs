using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ScriptableObject for the Track
[CreateAssetMenu(menuName = "Track")]
public class Track : ScriptableObject
{
    public GameObject[] Tracks; //List of possible track - This is useful when there are different type decoration for Tracks. Sadly I only have one model for each track now.
    public Vector2 trackSize = new Vector2(9f, 9f);// Size of the track

    //The direction 
    public enum Direction
    {
        North,
        East,
        South,
        West
    }
    
    public Direction entrydir;//the direction player enter 
    public Direction exitdir;//the direction player exit


}
