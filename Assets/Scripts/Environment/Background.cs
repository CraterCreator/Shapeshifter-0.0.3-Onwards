using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public float scrollSpeed;
    public Renderer rend;
    public MeshRenderer mesh;

    // Use this for initialization
    void Awake()
    {
        rend = GetComponent<Renderer>();
        scrollSpeed = 1.25f;
    }

    // Update is called once per frame
    void Update()
    {
        float offset = Time.time * scrollSpeed;
        rend.material.SetTextureOffset("_MainTex", new Vector2(0, -offset));
    }
}
