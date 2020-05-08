using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is the script for the Activator.
//Change the sprite of the Activator when player pressed certain key
public class ActivaorController : MonoBehaviour
{
    public SpriteRenderer sprrender;
    public KeyCode keypressed; // Key to pressed for this Activator
    public Sprite spr_orginal; //original sprites
    public Sprite spr_pressed; // sprites that change to when player pressed certain key.


    void Start()
    {
        //reference to spriteRender 
        sprrender = this.GetComponent<SpriteRenderer>();
    }

   
    void Update()
    {
        //Change sprite to pressed when pressed
        if (Input.GetKeyDown(keypressed))
        {
            sprrender.sprite = spr_pressed;
        }

        //Change sprite to the orginal when not pressing
        if (Input.GetKeyUp(keypressed))
        {
            sprrender.sprite = spr_orginal;
        }

    }
}
