using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is the script for each Note(Arrow) that moves down
public class Note : MonoBehaviour
{
    private bool canpressed; //the note is in the press zone and can be pressed
    public KeyCode keyToPressed; //Which key to press for this note
    public string noteType; //The type of the Note, There are four type (L - left, R - right, U- up, D - down)
    public GameObject activator; 

    void Start()
    {
        string activatorName = "Activator_" + noteType; // Find the Activator base on the type of note
        activator = GameObject.Find(activatorName);
    }

    void FixedUpdate()
    {
        // Make sure the x position is always the same as activator
        transform.position = new Vector3(activator.transform.position.x, transform.position.y, transform.position.z);
    }

    void Update()
    {
        if (Input.GetKeyDown(keyToPressed))
        {
            if (canpressed)
            {
                // if the key has been pressed when it's in the press zone, player gain points, and this will destory itself
                GameController.instance.NoteHit();
                this.gameObject.SetActive(false);
                //Destroy(this.gameObject);
            }
        }
    }

    //If the Note enter the collider of the Activator, it can be pressed 
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Activator")
        {
            canpressed = true; //Call function in GameController when miss the note
        }
    }

    //If the Note exit the collider of the Activator, it can't be pressed and will destory itself
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Activator")
        {
            canpressed = false;
            this.gameObject.SetActive(false);
            //Destroy(this.gameObject); 
            GameController.instance.NoteMiss(); //Call function in GameController when miss the note
        }
    }
}
