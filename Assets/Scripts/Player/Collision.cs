using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Spike")
        {
            gameObject.SetActive(false);
        }

        if(col.tag == "Checkpoint")
        {
            Destroy(col.transform.parent.gameObject);
        }
    }
}