using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EndCanvas : MonoBehaviour
{
    public TextMeshProUGUI Name, Score, Coin;

    public void OnContinButton()
    {
        SceneManager.LoadScene("MainMenu");

    }
}
