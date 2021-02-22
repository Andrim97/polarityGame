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

    public int distance_right = 5;
    public int distance_left = -5;

    float dir;
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
        transform.Translate(dir, 0, 0);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("this is anotuher place");
    }
}
