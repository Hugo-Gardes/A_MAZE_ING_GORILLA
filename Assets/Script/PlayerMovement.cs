using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public audiomanger audio;
    public int timeLine = 0; //0 present, 1 past, 2 future

    public float speed;
    public Rigidbody2D body;
    private Vector3 velocity = Vector3.zero;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    public Tilemap present;
    public Tilemap past;
    public Tilemap future;

    public Tilemap pastGround;
    public Tilemap presentGround;
    public Tilemap futureGround;

    public Tilemap presentSwitch;
    public Tilemap pastSwitch;
    public Tilemap futureSwitch;
    public float x;
    public float y;

    void Start()
    {
    }

    void FixedUpdate()
    {
        x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        y = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        Vector3 vel = new Vector2(x, y);
        body.velocity = Vector3.SmoothDamp(body.velocity, vel, ref velocity, 0.005f);
        switchMap();
        if (x > 0.3 || x < -0.3) {
            flip(x);
            animator.SetFloat("speed", my_abs(x));
            audio?.gorilla_step();
        } else {
            flip(y);
            animator.SetFloat("speed", my_abs(y));
            if (y < -0.3 || y > 0.3) {
                audio?.gorilla_step();
            } else {
                audio?.gorilla_breath();
            }
        }
    }

    float my_abs(float nbr)
    {
        if (nbr < 0) {
            nbr *= -1;
        }
        return (nbr);
    }

    void flip(float speed)
    {
        if (speed < 0.3) {
            spriteRenderer.flipX = true;
        } else {
            spriteRenderer.flipX = false;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "past")
        {
            audio?.portal_start();
            audio?.set_time_music(1);
            timeLine = 1;
        }

        if (col.gameObject.name == "present")
        {
            audio?.portal_start();
            audio?.set_time_music(0);
            timeLine = 0;
        }

        if (col.gameObject.name == "future")
        {
            audio?.portal_start();
            audio?.set_time_music(2);
            timeLine = 2;
        }
    }


    //Switch entre passé présent et futur
    void switchMap()
    {
        switchMapVisual();
        switchMapPhysical();
    }

    //change quelle map est visible entre les map passé présent future
    void switchMapVisual()
    {
        present.GetComponent<TilemapRenderer>().enabled = false;
        past.GetComponent<TilemapRenderer>().enabled = false;
        future.GetComponent<TilemapRenderer>().enabled = false;

        pastGround.GetComponent<TilemapRenderer>().enabled = false;
        presentGround.GetComponent<TilemapRenderer>().enabled = false;
        futureGround.GetComponent<TilemapRenderer>().enabled = false;

        presentSwitch.GetComponent<TilemapRenderer>().enabled = false;
        pastSwitch.GetComponent<TilemapRenderer>().enabled = false;
        futureSwitch.GetComponent<TilemapRenderer>().enabled = false;
        switch (timeLine)
        {
            case 0:
                presentGround.GetComponent<TilemapRenderer>().enabled = true;
                present.GetComponent<TilemapRenderer>().enabled = true;
                pastSwitch.GetComponent<TilemapRenderer>().enabled = true;
                futureSwitch.GetComponent<TilemapRenderer>().enabled = true;
                break;
            case 1:
                past.GetComponent<TilemapRenderer>().enabled = true;
                pastGround.GetComponent<TilemapRenderer>().enabled = true;
                presentSwitch.GetComponent<TilemapRenderer>().enabled = true;
                futureSwitch.GetComponent<TilemapRenderer>().enabled = true;
                break;
            case 2:
                future.GetComponent<TilemapRenderer>().enabled = true;
                futureGround.GetComponent<TilemapRenderer>().enabled = true;
                pastSwitch.GetComponent<TilemapRenderer>().enabled = true;
                presentSwitch.GetComponent<TilemapRenderer>().enabled = true;
                break;
        }
    }


    //change les collision entre les map passé présent future
    void switchMapPhysical()
    {
        present.GetComponent<TilemapCollider2D>().enabled = false;
        past.GetComponent<TilemapCollider2D>().enabled = false;
        future.GetComponent<TilemapCollider2D>().enabled = false;

        presentSwitch.GetComponent<TilemapCollider2D>().enabled = false;
        pastSwitch.GetComponent<TilemapCollider2D>().enabled = false;
        futureSwitch.GetComponent<TilemapCollider2D>().enabled = false;
        switch (timeLine)
        {
            case 0:
                present.GetComponent<TilemapCollider2D>().enabled = true;
                pastSwitch.GetComponent<TilemapCollider2D>().enabled = true;
                futureSwitch.GetComponent<TilemapCollider2D>().enabled = true;
                break;
            case 1:
                past.GetComponent<TilemapCollider2D>().enabled = true;
                presentSwitch.GetComponent<TilemapCollider2D>().enabled = true;
                futureSwitch.GetComponent<TilemapCollider2D>().enabled = true;
                break;
            case 2:
                future.GetComponent<TilemapCollider2D>().enabled = true;
                pastSwitch.GetComponent<TilemapCollider2D>().enabled = true;
                presentSwitch.GetComponent<TilemapCollider2D>().enabled = true;
                break;
        }
    }
}
