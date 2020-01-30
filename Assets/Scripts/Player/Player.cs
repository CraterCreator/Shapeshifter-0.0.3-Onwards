using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator anim;
    public UI ui;
    public bool right, left;

    private float timer, dualTimer;

    void Start()
    {
        anim.SetTrigger("Dead");
    }

    void Update()
    {
        Controls();

        if (Input.touchCount == 0)
        {
            left = false;
            right = false;
            anim.SetBool("Right", false);
            anim.SetBool("Left", false);
        }
        else
        {
            anim.SetBool("Right", right);
            anim.SetBool("Left", left);
        }

        if (ui.mainMenu.activeSelf == false)
        {
            if (Input.GetMouseButton(1) || Input.GetMouseButton(0))
                if (timer < 0.5f)
                    timer += Time.deltaTime;

            if (Input.GetMouseButton(1) && Input.GetMouseButton(0))
            {
                if (dualTimer < 0.5)
                    dualTimer += Time.deltaTime;
            }
            else
            if (dualTimer > 0)
                dualTimer -= Time.deltaTime;

            if (!Input.GetMouseButton(1) && !Input.GetMouseButton(0))
                if (timer > 0)
                    timer -= Time.deltaTime;

            anim.SetFloat("DualTimer", dualTimer);
            anim.SetFloat("Timer", timer);
            anim.SetBool("Right", Input.GetMouseButton(1));
            anim.SetBool("Left", Input.GetMouseButton(0));
        }
        else
        {
            anim.SetFloat("DualTimer", 0);
            anim.SetFloat("Timer", 0);
            anim.SetBool("Right", false);
            anim.SetBool("Left", false);
        }
    }

    void Controls()
    {

        for (int i = 0; i < Input.touchCount; i++)
        {
            Vector3 touchpos = Camera.main.ScreenToWorldPoint(Input.touches[i].position);

            if (Input.touchCount == 0)
            {
                right = false;
                left = false;
            }

            if (touchpos.x > 0 && Input.touches[i].phase == TouchPhase.Began)
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

    void Center()
    {
        GameObject left = gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
        GameObject right = gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject;
        left.transform.position = Vector3.zero;
        right.transform.position = Vector3.zero;
    }
}
