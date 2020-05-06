using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    private bool canpressed;
    public KeyCode keyToPressed;
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(keyToPressed))
        {
            if (canpressed)
            {
                this.gameObject.SetActive(false);

                GameController.instance.NoteHit();
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canpressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canpressed = false;
            GameController.instance.NoteMiss();
        }
    }
}
