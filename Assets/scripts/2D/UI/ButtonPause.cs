using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPause : MonoBehaviour
{
    public void OnClickPause()
    {
            Time.timeScale = 0.0f;
    }
}
