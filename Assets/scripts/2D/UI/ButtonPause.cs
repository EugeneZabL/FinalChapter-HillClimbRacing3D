using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPause : MonoBehaviour
{
    bool isPaused = false;
    public void OnClickPause()
    {
        isPaused = !isPaused;
        if(isPaused)
            Time.timeScale = 0.0f;
        else
            Time.timeScale = 1.0f;
    }
}
