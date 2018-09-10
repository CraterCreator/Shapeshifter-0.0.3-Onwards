using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator anim;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKey == false)
        {
            anim.SetBool("Middle", false);
            anim.SetBool("Left", false);
            anim.SetBool("Right", false);
            anim.SetBool("R2M", false);
            anim.SetBool("L2M", false);
        }

        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow))
        {
            anim.SetBool("Middle", true);
        }
        else
        {
            anim.SetBool("Middle", false);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            anim.SetBool("Left", true);

            if(Input.GetKey(KeyCode.RightArrow))
            {
                anim.SetBool("L2M", true);
            }
            else
            {
                anim.SetBool("L2M", false);
            }
        }
        else
        {
            anim.SetBool("Left", false);
        }
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            anim.SetBool("Right", true);

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                anim.SetBool("R2M", true);
            }
            else
            {
                anim.SetBool("R2M", false);
            }
        }
        else
        {
            anim.SetBool("Right", false);
        }
        
    }
}
