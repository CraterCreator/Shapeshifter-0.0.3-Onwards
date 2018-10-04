using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator anim;
    public bool RPrep, SPrep, LPrep;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        //Time.timeScale = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {

        // Outer Animations
        /*
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
        
    */

        //Inner Animations

        // Default
        if(Input.anyKey == false)
        {
            anim.SetBool("Sides", false);
            anim.SetBool("Right", false);
            anim.SetBool("Left", false);
            anim.SetBool("RTS", false);
            anim.SetBool("STR", false);
            anim.SetBool("LTS", false);
            anim.SetBool("STL", false);
            RPrep = false;
            SPrep = false;
            LPrep = false;
        }

        // Sides
        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow) && RPrep == false)
        {
            anim.SetBool("Sides", true);
            anim.SetBool("Right", false);
            anim.SetBool("Left", false);
            anim.SetBool("RTS", false);
            SPrep = true;
        }
        else
        {
            anim.SetBool("Sides", false);
        }

        // Right
        if (Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow))
        {
            anim.SetBool("Right", true);
            RPrep = true;
            LPrep = false;
        }
        else
        {
            anim.SetBool("Right", false);
        }

        // Right to Sides
        if (RPrep == true && Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow))
        {
            SPrep = true;
            anim.SetBool("RTS", true);
            anim.SetBool("Right", false);
            anim.SetBool("Sides", false);
        }
        else
        {
            anim.SetBool("RTS", false);
        }

        // SidesToRight
        if(SPrep == true && Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow))
        {
            anim.SetBool("Right", true);
            anim.SetBool("STR", true);
            anim.SetBool("RTS", false);
        }

        else
        {
            anim.SetBool("STR", false);
        }

        // Left
        if (Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
        {
            anim.SetBool("Left", true);
            LPrep = true;
            RPrep = false;
        }
        else
        {
            anim.SetBool("Left", false);
        }

        // Left to Sides
        if (LPrep == true && Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.LeftArrow))
        {
            SPrep = true;
            anim.SetBool("LTS", true);
            anim.SetBool("Left", false);
            anim.SetBool("Sides", false);
        }
        else
        {
            anim.SetBool("LTS", false);
        }

        // Sides To Left
        if (SPrep == true && Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
        {
            anim.SetBool("Left", true);
            anim.SetBool("STL", true);
            anim.SetBool("RTS", false);
        }

        else
        {
            anim.SetBool("STL", false);
        }
    }
}
