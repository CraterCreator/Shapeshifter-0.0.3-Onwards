using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public float scrollSpeed;
    public Renderer rend;
    public MeshRenderer mesh;

    // Use this for initialization
    void Start()
    {
        rend = GetComponent<Renderer>();
        // StartCoroutine(Repeat());
        scrollSpeed = 2.25f;
    }

    // Update is called once per frame
    void Update()
    {
        float offset = scrollSpeed * Time.time;
        rend.material.SetTextureOffset("_MainTex", new Vector2(0, -offset));
    }

    IEnumerator Repeat()
    {
        for (int i = 0; i < i + 1; i++)
        {
            scrollSpeed += 0.05f;
            yield return new WaitForEndOfFrame();
        }
    }
}
