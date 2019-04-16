using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator anim;
    private UI ui;
    public bool RPrep, SPrep, LPrep, right, left;
    private Vector2 mousePos;

    // Use this for initialization
    void Start()
    {
        ui = GameObject.Find("UI Controller").GetComponent<UI>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Controls();

        if (Input.touchCount == 0)
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
        if (ui.mainMenu.activeSelf == false)
        {
            //Inner Animations

            // Default

            // Sides
            if (left == true && right == true && RPrep == false)
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
            if (right == true && !left == true)
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
            if (RPrep == true && left == true && right == true)
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
            if (SPrep == true && right == true && !left == true)
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
            if (left == true && !right == true)
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
            if (LPrep == true && right == true && left == true)
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
            if (SPrep == true && left == true && !right == true)
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

        else
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
    }

    void Controls()
    {

        for (int i = 0; i < Input.touchCount; i++)
        {
            Vector3 touchpos = Camera.main.ScreenToWorldPoint(Input.touches[i].position);

            if(touchpos.x > 0 && Input.touches[i].phase == TouchPhase.Began)
            {
                right = true;
            }

            if (touchpos.x > 0 && Input.touches[i].phase == TouchPhase.Ended)
            {
                right = false;
            }

            if (touchpos.x < 0 && Input.touches[i].phase == TouchPhase.Began)
            {
                left = true;
            }

            if (touchpos.x < 0 && Input.touches[i].phase == TouchPhase.Ended)
            {
                left = false;
            }
        }

    }
}
