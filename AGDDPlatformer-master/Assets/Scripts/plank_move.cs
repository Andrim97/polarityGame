using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plank_move : MonoBehaviour
{
    
    public float speed = 1.5f;
    
    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.Translate(step, 0, 0);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("this is anotuher place");
    }
}
