﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{

    public GameObject obj;
    float randomY;
    Vector2 whereToSpawn;
    public float spawnRate = 2f;
    float nextSpawn = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextSpawn)
        {
            if(obj != null)
            {
                nextSpawn = Time.time + spawnRate;
                randomY = Random.Range(-4.4f, 4.4f);
                whereToSpawn = new Vector2(transform.position.x, transform.position.y + randomY);
                Instantiate(obj, whereToSpawn, Quaternion.identity);
            }
        }
    }
}