using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColourSwap : MonoBehaviour
{
    [ColorUsage(true, true)]
    public Color theColor, originalColor, currentColor;
    public ParticleSystem trail;
    public bool colorSet;

    private Collision col;
    private ColourSwap original;
    private SpriteRenderer thisColor;
    private float intensity, factor, t;

    private void Awake()
    {
        col = GameObject.Find("Triangle Left").GetComponent<Collision>();
        original = GameObject.Find("Left Neon").GetComponent<ColourSwap>();

        if (trail == null)
        {
            thisColor = GetComponent<SpriteRenderer>();
            originalColor = thisColor.material.GetColor("_Color");
        }
    }

    // Update is called once per frame
    void Update()
    {
        intensity = (original.theColor.r + original.theColor.g + original.theColor.b) / 3f;
        factor = 1 / intensity;

        if (col.gameover == false)
        {
            if (trail != null)
                ParticleColor();
            else
            {
                if (thisColor.material.name == "PlayerGlow (Instance)")
                {
                    thisColor.material.SetColor("_Color", new Color(original.theColor.r * factor * 3, original.theColor.g * factor * 3, original.theColor.b * factor * 3));
                }
                else
                {
                    thisColor.material.SetColor("_Color", original.theColor);
                }

            }
        }
        else
        {

            if (trail != null)
            {
                trail.gameObject.SetActive(false);
            }
            else
            {

                if (colorSet == false)
                {
                    currentColor = thisColor.material.GetColor("_Color");
                    colorSet = true;
                }

                if (thisColor.material.name == "WallGlow (Instance)")
                {
                    thisColor.material.SetColor("_Color", Color.Lerp(currentColor, originalColor, t));
                    if (t < 1) t += Time.deltaTime / 0.2f;
                }
                else
                {
                    thisColor.material.SetColor("_Color", Color.Lerp(currentColor, Color.black, t));
                    if (t < 1) t += Time.deltaTime / 0.2f;
                    if (gameObject.tag == "Spike")
                        Destroy(gameObject, 0.5f);
                }
            }
        }
    }

    void ParticleColor()
    {
        var main = trail.main;
        main.startColor = original.theColor;
    }
}
