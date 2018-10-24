using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public float scrollSpeed = 0.5f;
    public Renderer rend;
    public MeshRenderer mesh;

    // Use this for initialization
    void Start()
    {
        rend = GetComponent<Renderer>();
        scrollSpeed = 1;
    }

    // Update is called once per frame
    void Update()
    {
        float offset = Time.time * scrollSpeed;
        rend.material.SetTextureOffset("_MainTex", new Vector2(0, -offset));
    }
}
