using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivaorController : MonoBehaviour
{
    public SpriteRenderer sprrender;
    public KeyCode keypressed;
    public Sprite spr_orginal;
    public Sprite spr_pressed;


    void Start()
    {
        sprrender = this.GetComponent<SpriteRenderer>();

    }

   
    void Update()
    {
        if (Input.GetKeyDown(keypressed))
        {
            sprrender.sprite = spr_pressed;
        }

        if (Input.GetKeyUp(keypressed))
        {
            sprrender.sprite = spr_orginal;
        }

    }
}
