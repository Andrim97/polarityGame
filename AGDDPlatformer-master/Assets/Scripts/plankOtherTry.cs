using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plankOtherTry : MonoBehaviour
{
    
    public float speed = 1.5f;
    float step;

    float curr_x_pos;
    float curr_y_pos;

    public bool vertical_move = true;
    public float distance_right = 0;
    public float distance_left = 0;
    public float distance_up = 0;
    public float distance_down = 0;

    public float dir = 0;
    void Start()
    {
        step = speed * Time.deltaTime;
        dir = step;
        curr_x_pos = transform.position.x;
        curr_y_pos = transform.position.y;
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        //step = speed * Time.deltaTime;
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

    // void OnCollisionEnter2D(Collision2D collisionInfo)
    // {
    //     if(collisionInfo.gameObject.tag == "Player1") { 
    //         // var ply = new AGDDPlatformer.PlayerController();
    //         // ply.PlatformMove(dir, vertical_move);
    //         if(vertical_move){
    //             collisionInfo.transform.Translate(dir,0,0);
    //         }
    //         if(!vertical_move) {
    //             collisionInfo.transform.Translate(0,dir,0);
    //         }

    //     }
    // }
    void OnCollisionStay2D(Collision2D collisionInfo)
    {
        if(collisionInfo.gameObject.tag == "Player1") { 
            if(vertical_move){
                collisionInfo.transform.Translate(dir,0,0);
            }
            if(!vertical_move) {
                collisionInfo.transform.Translate(0,dir,0);
            }
        }
        if(collisionInfo.gameObject.tag == "Player2") { 
            if(vertical_move){
                collisionInfo.transform.Translate(-dir,0,0);
            }
            if(!vertical_move) {
                collisionInfo.transform.Translate(0,-dir,0);
            }
        }
    }
    // public GameObject MoveDude (Vector3 player) {
    //     if(vertical_move) { return GameObject.Find("Player1").transform.Translate(dir, 0, 0); }
    //     else if(!vertical_move) { return player.transform.Translate(0, dir, 0); }
    //     else { return gameObject.player.transform.Translate(0, 0, 0); }
    // }

    // void OnTriggerEnter2D(Collider2D other)
    // {
    //     if(other.gameObject.tag == "Player1") {
    //             other.transform.parent = transform;
    //         }
    //     if(other.gameObject.tag == "Player2") {
    //             other.transform.parent = transform;
    //         }
    // }

    // void OnTriggerStay2D(Collider2D other)
    // {
    //     if(other.gameObject.tag == "Player1") {
    //             other.transform.parent = transform;
    //         }
    //     if(other.gameObject.tag == "Player2") {
    //             other.transform.parent = transform;
    //         }
    // }
    // void OnTriggerExit2D(Collider2D other)
    // {
    //     if(other.gameObject.tag == "Player1") {
    //             other.transform.parent = GameObject.Find("Base").transform;
    //         }
    //     if(other.gameObject.tag == "Player2") {
    //             other.transform.parent = GameObject.Find("Base").transform;
    //         }
    // }
}
