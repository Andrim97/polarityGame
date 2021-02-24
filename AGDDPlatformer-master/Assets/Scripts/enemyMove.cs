using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMove : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D obj;

    public bool going_right = false;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        obj.transform.position -= transform.right * Time.deltaTime *10;
        //obj.transform.Translate(-1,0,0);
        if(obj.transform.position.x <= -10) {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        Destroy(gameObject);
    }
}