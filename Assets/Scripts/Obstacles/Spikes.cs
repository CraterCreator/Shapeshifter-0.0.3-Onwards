using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public float moveSpeed;

    private UI ui;
    private GameObject raycastOrigin, manager;
    private SpriteRenderer triggerL, triggerR;
    private Spawner spawner;
    private Animator anim;
    private int right, left;
    // Use this for initialization
    void Start()
    {
        ui = GameObject.Find("UI Controller").GetComponent<UI>();
        raycastOrigin = transform.Find("Origin").gameObject;
        manager = GameObject.Find("Game Manager");
        spawner = GameObject.Find("Game Manager").GetComponent<Spawner>();

        if (gameObject.name == "Middle Tri(Clone)")
        {
            anim = GetComponent<Animator>();
            triggerL = transform.Find("Trigger Left").GetComponent<SpriteRenderer>();
            triggerR = transform.Find("Trigger Right").GetComponent<SpriteRenderer>();
        }

        Destroy(gameObject, spawner.destroyTimer);
        moveSpeed = 0.0825f;
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.activeSelf == false)
        {
            Destroy(gameObject, 0.01f);
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


            if (gameObject.name != "Middle Tri(Clone)" && hit.transform.tag == "Player" || gameObject.name != "Middle Tri(Clone)" && hit2.transform.tag == "Player" || gameObject.name != "Middle Tri(Clone)" && hit3.transform.tag == "Player")
            {
                Destroy(raycastOrigin);
                ui.score += 1;
            }

            if (gameObject.name == "Middle Tri(Clone)" && hit.transform.tag == "Player")
            {
                triggerR.color = Color.green;
                right += 1;
            }

            if (gameObject.name == "Middle Tri(Clone)" && hit2.transform.tag == "Player")
            {
                triggerL.color = Color.green;
                left += 1;
            }

            if (right == 2 || left == 2)
            {
                anim.SetBool("Lose", true);
                triggerR.color = Color.red;
                triggerL.color = Color.red;
                left = 0;
                right = 0;
                Destroy(raycastOrigin);
            }

            if (right == 1 && left == 1)
            {
                anim.SetBool("Win", true);
                ui.score += 1;
                left = 0;
                right = 0;
                Destroy(raycastOrigin);
            }
        }

    }
}
