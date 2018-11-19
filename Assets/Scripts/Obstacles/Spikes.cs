using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public UI ui;
    public float moveSpeed;
    public GameObject raycastOrigin, manager;
    // Use this for initialization
    void Start()
    {
        ui = GameObject.Find("UI Controller").GetComponent<UI>();
        raycastOrigin = this.transform.Find("Origin").gameObject;
        manager = GameObject.Find("Game Manager");

        moveSpeed = 0.0825f;
        Destroy(gameObject, 10);
    }

    // Update is called once per frame
    void Update()
    {
        if(manager.activeSelf == false)
        {
            Destroy(gameObject);
        }

        if (raycastOrigin != null)
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


            if (hit.transform.tag == "Player" || hit2.transform.tag == "Player" || hit3.transform.tag == "Player")
            {
                Destroy(raycastOrigin);
                ui.score += 1;
            }
        }

    }
}
