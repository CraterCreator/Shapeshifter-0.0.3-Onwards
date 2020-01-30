using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MM : MonoBehaviour
{
    public UI ui;

    public void Off()
    {
        ui.score = 0;
        ui.scoreObj.SetActive(true);
        gameObject.SetActive(false);
    }
}
