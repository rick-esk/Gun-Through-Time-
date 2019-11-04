﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Camera cam;

    public Joystick j1;
    public Joystick j2;

    Vector2 movement;
    Vector2 mousePos;
    Vector2 direccion;

    public Transform spawnPoint;

    public GameObject target;

    public bool controles;

    // Update is called once per frame
    void Update()
    {
        //controles tactiles o Manuales para casos de prueba
       if (controles == true)
        {
            movement.x = j1.Horizontal;
            movement.y = j1.Vertical;
            if (j2.Horizontal != 0f || j2.Vertical != 0f)
            {
                direccion.x = j2.Horizontal;
                direccion.y = j2.Vertical;
            }
        } 
        else 
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            direccion = mousePos - rb.position;
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookdir = direccion;
        float angle = Mathf.Atan2(lookdir.y, lookdir.x) * Mathf.Rad2Deg -0f;
        rb.rotation = angle;
    }



    // Funcion para que el jugador sea matado por una bala y respawn
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Bullet"))
        {
            GameControl.health -= 1;
            Handheld.Vibrate();
        }
        if (col.gameObject.tag.Equals("Heart"))
        {
            GameControl.health += 1;
            Destroy(col.gameObject);
            ScoreScript.scoreValue += 50;
        }
    }

    
}