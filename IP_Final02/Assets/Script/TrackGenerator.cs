using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackGenerator : MonoBehaviour
{
    public Track[] tracks;
    public Track firstTrack;
    public List<GameObject> trackInScene;

    private Track previousTrack;

    public Vector3 spawnOrigin;
    public Vector3 spawnPos;

    public int spawnamount = 10;

    public TravelObject travelObject;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            PickSpawnTrack();
        }

        if (trackInScene.Count > 11)
        {
            GameObject temp = trackInScene[0];
            trackInScene.RemoveAt(0);
            Destroy(temp);
        }

    }


    void Start()
    {
        previousTrack = firstTrack;

        for (int i = 0; i < spawnamount; i++)
        {
            PickSpawnTrack();
        }
        
    }

    public void PickSpawnTrack()
    {
        Track curTrack = PickNextTrack();

        GameObject objectfromTrack = curTrack.Tracks[0];
        GameObject temp = Instantiate(objectfromTrack, spawnPos + spawnOrigin, Quaternion.identity);
        trackInScene.Add(temp);
        travelObject.desList.Add(spawnPos + spawnOrigin);
        previousTrack = curTrack;

    }

    Track PickNextTrack()
    {

        List<Track> nextTrackList = new List<Track>();

        Track nextTrack = null;

        Track.Direction requiredDir = Track.Direction.South;

        switch (previousTrack.exitdir)
        {
            case Track.Direction.North:
                requiredDir = Track.Direction.South;
                spawnPos = spawnPos + new Vector3(0, 0, previousTrack.trackSize.y);
                break;

            case Track.Direction.West:
                requiredDir = Track.Direction.East;
                spawnPos = spawnPos + new Vector3(- previousTrack.trackSize.x, 0, 0.5f);
                break;

            case Track.Direction.East:
                //Debug.Log("Exit East");
                requiredDir = Track.Direction.West;
                spawnPos = spawnPos + new Vector3(previousTrack.trackSize.x, 0, 0.5f);
                break;
        }

        for (int i = 0; i < tracks.Length; i ++)
        {
            if (tracks[i].entrydir == requiredDir)
            {
                nextTrackList.Add(tracks[i]);
            }
        }


        nextTrack = nextTrackList[Random.Range(0, nextTrackList.Count)];
        return nextTrack;

    }



}
