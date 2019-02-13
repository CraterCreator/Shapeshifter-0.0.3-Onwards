using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{

    private float moveSpeed;
    private UI ui;
    private GameObject raycastOrigin;
    private Spawner spawner;
    private Animator anim, anim2;
    private int right, left;
    // Use this for initialization
    void Start()
    {
        ui = GameObject.Find("UI Controller").GetComponent<UI>();
        raycastOrigin = transform.Find("Origin").gameObject;
        spawner = GameObject.Find("Game Manager").GetComponent<Spawner>();

        if (gameObject.name == "Middle Tri(Clone)")
        {
            anim = GetComponent<Animator>();
        }
        else
        {
            anim2 = GetComponent<Animator>();
        }

        Destroy(gameObject, spawner.destroyTimer);
        moveSpeed = 0.0825f;
    }

    // Update is called once per frame
    void Update()
    {
        if (ui.gameOver.activeSelf == true)
        {
            if (anim2 != null)
            {
                anim2.SetBool("Fade", true);
            }

            if (anim != null)
            {
                anim.SetBool("Fade", true);
            }
        }

        if (raycastOrigin != null && gameObject != null)
        {
            Raycast();
        }

        transform.Translate(0, -moveSpeed * Time.timeScale, 0);
    }

    void Raycast()
    {
        if (gameObject != null)
        {
            RaycastHit2D hit = Physics2D.Raycast(new Vector2(raycastOrigin.transform.position.x + 5, raycastOrigin.transform.position.y), Vector2.left * 4);
            RaycastHit2D hit2 = Physics2D.Raycast(new Vector2(raycastOrigin.transform.position.x - 5, raycastOrigin.transform.position.y), Vector2.right * 4);
            RaycastHit2D hit3 = Physics2D.Raycast(new Vector2(raycastOrigin.transform.position.x, raycastOrigin.transform.position.y), Vector2.right * 2);

            Debug.DrawRay(new Vector2(raycastOrigin.transform.position.x + 5, raycastOrigin.transform.position.y), Vector2.left * 4, Color.green);
            Debug.DrawRay(new Vector2(raycastOrigin.transform.position.x - 5, raycastOrigin.transform.position.y), Vector2.right * 4, Color.green);
            Debug.DrawRay(new Vector2(raycastOrigin.transform.position.x - 1, raycastOrigin.transform.position.y), Vector2.right * 2, Color.green);

            if (ui.gameOver.activeSelf == false && raycastOrigin.activeSelf == true)
            {
                if (gameObject.name != "Middle Tri(Clone)" && hit.transform.tag == "Player" || gameObject.name != "Middle Tri(Clone)" && hit2.transform.tag == "Player" || gameObject.name != "Middle Tri(Clone)" && hit3.transform.tag == "Player")
                {
                    anim2.SetBool("Passed", true);
                    Destroy(raycastOrigin);
                    ui.score += 1;
                }
            }

            if (raycastOrigin.activeSelf == true)
            {
                if (gameObject.name == "Middle Tri(Clone)" && hit.transform.name == "Right")
                {
                    right = 2;
                }

                if (gameObject.name == "Middle Tri(Clone)" && hit.transform.name == "Left")
                {
                    right = 1;
                }

                if (gameObject.name == "Middle Tri(Clone)" && hit2.transform.name == "Right")
                {
                    left = 1;
                }

                if (gameObject.name == "Middle Tri(Clone)" && hit2.transform.name == "Left")
                {
                    left = 2;
                }
            }

            if (left == 1 || right == 1)
            {
                anim.SetBool("Lose", true);
                anim.SetBool("Passed", true);
                left = 0;
                right = 0;
                Destroy(raycastOrigin);
            }

            if (right == 2 && left == 2)
            {
                anim.SetBool("Win", true);
                anim.SetBool("Passed", true);
                ui.score += 1;
                left = 0;
                right = 0;
                Destroy(raycastOrigin);
            }
        }

    }
}
