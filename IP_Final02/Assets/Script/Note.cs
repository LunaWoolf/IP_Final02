using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    private bool canpressed;
    public KeyCode keyToPressed;
    public string noteType;
    public GameObject activator;

    void Start()
    {
        string temp = "Activator_" + noteType;
        activator = GameObject.Find(temp);
    }

    void FixedUpdate()
    {
        transform.position = new Vector3(activator.transform.position.x, transform.position.y, transform.position.z);
    }

    void Update()
    {
        if (Input.GetKeyDown(keyToPressed))
        {
            if (canpressed)
            {
                Destroy(this.gameObject);

                GameController.instance.NoteHit();
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Activator")
        {
            canpressed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Activator")
        {
            canpressed = false;
            Destroy(this.gameObject);
            GameController.instance.NoteMiss();
        }
    }
}
