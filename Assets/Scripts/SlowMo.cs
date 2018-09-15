using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMo : MonoBehaviour
{
    public static bool slowOn;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (slowOn == false && col.tag == "Player")
        {
            StartCoroutine(slowTime());
        }
    }

    IEnumerator slowTime()
    {
        for (int i = 0; i < 1; i++)
        {
            slowOn = true;
            float currentSpeed = Time.timeScale;
            Time.timeScale = 0.5f;
            yield return new WaitForSeconds(.2f);
            Time.timeScale = currentSpeed;
            slowOn = false;
        }
    }
}
