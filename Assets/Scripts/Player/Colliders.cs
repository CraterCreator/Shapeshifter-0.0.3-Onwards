using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colliders : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        if (name == "RightCol")
        {
            gameObject.transform.position = GameObject.Find("RightWall").transform.position;
        }

        if (name == "LeftCol")
        {
            gameObject.transform.position = GameObject.Find("LeftWall").transform.position;
        }
    }
}
