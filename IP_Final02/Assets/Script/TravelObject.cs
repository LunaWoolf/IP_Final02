using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The "Player" / "Camera" that move automatically along the track
public class TravelObject : MonoBehaviour
{
    public List<Vector3> desList; // list of Destination
    public int curDesIndex = -1; // cur index of the desList
    public Vector3 curDestination;
    public float speed;
    public TrackGenerator trackGenerattor;
    public GameController gc;

    void FixedUpdate()
    {
        if (desList.Count > 1 && curDesIndex < 0) // If there are more than one Destination in the list, set the first Destination
        {
            curDesIndex = 0;
            curDestination = desList[0];
        }

        // if get to the current Destination, that the current Destination to be the next one on the list 
        if ( Vector3.Distance(transform.position,desList[curDesIndex]) < 1f && curDesIndex < desList.Count) 
        {
            curDesIndex++;
            curDestination = desList[curDesIndex]; // Set next item in list to be current Destination
        }
        else
        {
            if(gc.start)
            transform.position = Vector3.MoveTowards(transform.position, curDestination, Time.deltaTime * speed);  // travel to the destination
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // if enter the collider with this tag, turn to right for 90 degrees
        if (other.tag == "TurnRightPoint")
        {
            trackGenerattor.PickSpawnTrack(); // Generate a new Track in front of the list 
            StartCoroutine(Rotate(Vector3.up * 90, 0.8f)); 
        }

        // if enter the collider with this tag, turn to right for 90 degrees
        if (other.tag == "TurnLeftPoint")
        {
            trackGenerattor.PickSpawnTrack();// Generate a new Track in front of the list
            StartCoroutine(Rotate(Vector3.up * -90, 0.8f)); 
        }
        
       
    }

    // Smoothly turn 90 degree
    IEnumerator Rotate(Vector3 angle, float time)
    {
        Quaternion curAngle = transform.rotation; // current angle
        Quaternion toAngle = Quaternion.Euler(transform.eulerAngles + angle); // the angle that we want after this rotation

        // turn each frame 
        for (float i = 0; i <= 1; i += Time.deltaTime / time)
        {
            transform.rotation = Quaternion.Slerp(curAngle, toAngle, i);
            yield return null;
        }
        transform.rotation = toAngle; // finish the rotation
    }


}
