using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene("2D GraficUpdate");
    }
}
