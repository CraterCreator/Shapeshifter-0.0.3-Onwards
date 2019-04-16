using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public float moveSpeed;
    private UI ui;
    // Use this for initialization
    void Start()
    {
        ui = GameObject.Find("UI Controller").GetComponent<UI>();

        moveSpeed = 4.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (ui.mainMenu.activeSelf == true)
        {
            Destroy(gameObject);
        }

        if (gameObject.tag != "CheckpointFinish")
        {
            transform.Translate(0, -moveSpeed * Time.deltaTime, 0);
        }

    }
}
