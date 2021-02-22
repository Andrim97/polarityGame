using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plank_move : MonoBehaviour
{
    
    public float speed = 1.5f;
    float step;

    float dir;
    void Start()
    {
        step = speed * Time.deltaTime;
        dir = step;
    }
    
    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > 5) {
            dir = -step;
        }
        if(transform.position.x < 1) {
            dir = step;
        }
        transform.Translate(dir, 0, 0);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("this is anotuher place");
    }
}
