using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is the trackGenerator that generate the tracks.
//It will first generate 10 track. Each times player move away from one track, it will add one to the front
// and remove the last one.
public class TrackGenerator : MonoBehaviour
{
    //List of tracks
    public Track[] tracks;
    public Track firstTrack; //first Track in the scene
    public List<GameObject> trackInScene; //List of track currently in the scene

    private Track previousTrack;// previous Track that has been placed

    //public Vector3 spawnOrigin;
    public Vector3 spawnPos; // The position to spawn next tiles

    public int spawnamount = 10; // The spawn amount at first.

    public TravelObject travelObject; //the camera object that travel through the track

    public void Update()
    {
        // if there is more than 11 track, remove the last one
        if (trackInScene.Count > 11)
        {
            GameObject temp = trackInScene[0];
            trackInScene.RemoveAt(0);
            Destroy(temp);
        }
    }


    void Start()
    {
        //set previousTrack as the first Track
        previousTrack = firstTrack;

        //generate 10 tracks
        for (int i = 0; i < spawnamount; i++)
        {
            PickSpawnTrack();
        }
    }

    //pick the track that match the exit & entry direction and put it int the position
    public void PickSpawnTrack()
    {
        Track curTrack = PickNextTrack();
        GameObject objectfromTrack = curTrack.Tracks[0]; //This format will be useful if there is more than one model of each track type
        GameObject temp = Instantiate(objectfromTrack, spawnPos, Quaternion.identity);
        trackInScene.Add(temp); //add this new track to the currenttrack list
        travelObject.desList.Add(spawnPos); // Add the position to the travel destination list
        previousTrack = curTrack; // set current track as previous track
    }

    //pick the track that match the exit & entry direction
    Track PickNextTrack()
    {
        //This format will be useful if there is more than one model of each track type
        List<Track> nextTrackList = new List<Track>();
        Track nextTrack = null;
        // The enter  dirction that required for next track
        Track.Direction requiredDir = Track.Direction.South;

        //check the exit direction of the perivous track and set the required enter direction for next track
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
                requiredDir = Track.Direction.West;
                spawnPos = spawnPos + new Vector3(previousTrack.trackSize.x, 0, 0.5f);
                break;
        }

        //go through the track list to find the track that match the direction and add it to the nextTrackList
        //This format will be useful if there is more than one model of each track type
        for (int i = 0; i < tracks.Length; i ++)
        {
            if (tracks[i].entrydir == requiredDir)
            {
                nextTrackList.Add(tracks[i]);
            }
        }

        // Go through nextTrackList and ramdomly pick one for next track
        //This format will be useful if there is more than one model of each track type
        //For this game, for now there will be only one possible track in the list
        nextTrack = nextTrackList[Random.Range(0, nextTrackList.Count)];
        return nextTrack; // return the next Track

    }



}
