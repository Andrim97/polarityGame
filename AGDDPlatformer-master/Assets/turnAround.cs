using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnAround : MonoBehaviour
{
    public GameObject plank;

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("got here");
        plank.GetComponent<plank_move>().speed = plank.GetComponent<plank_move>().speed * -1;
    }

}
