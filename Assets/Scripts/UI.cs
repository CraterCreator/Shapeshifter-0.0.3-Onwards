using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public float monitor;
    // Use this for initialization
    void Start()
    {
        StartCoroutine(SpeedUp());
    }

    // Update is called once per frame
    void Update()
    {
        monitor = Time.timeScale;
    }

    IEnumerator SpeedUp()
    {
        for (int i = 0; i < i + 1; i++)
        {
            yield return new WaitForSeconds(1);
            Time.timeScale = Time.timeScale + 0.01f;
        }
    }
}
