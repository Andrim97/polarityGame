using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plank_move : MonoBehaviour
{
    
    public float speed = 1.5f;
    float step;

    float curr_x_pos;
    float curr_y_pos;

    public bool vertical_move = true;
    public int distance_right = 0;
    public int distance_left = 0;
    public int distance_up = 0;
    public int distance_down = 0;

    public float dir = 0;
    void Start()
    {
        step = speed * Time.deltaTime;
        dir = step;
        curr_x_pos = transform.position.x;
        curr_y_pos = transform.position.y;
    }
    
    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > curr_x_pos + distance_right) {
            dir = -step;
        }
        if(transform.position.x < curr_x_pos + distance_left) {
            dir = step;
        }
        if(transform.position.y > curr_y_pos + distance_up) {
            dir = -step;
        }
        if(transform.position.y < curr_y_pos + distance_down) {
            dir = step;
        }

        if(vertical_move) { transform.Translate(dir, 0, 0); }
        if(!vertical_move) { transform.Translate(0, dir, 0); }
    }


    // public Vector2 MoveDude(Player player) {
    //     if(vertical_move) { return player.transform.Translate(dir, 0); }
    //     if(!vertical_move) { return player.transform.Translate(0, dir); }
    // }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log("this is anotuher place");
    }
}
