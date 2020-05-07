using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Track")]
public class Track : ScriptableObject
{
    public GameObject[] Tracks;
    public Vector2 trackSize = new Vector2(9f, 9f);

    public enum Direction
    {
        North,
        East,
        South,
        West
    }
    public Direction entrydir;
    public Direction exitdir;


}
