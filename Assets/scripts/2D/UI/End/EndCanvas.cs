using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

namespace HillClimb3d.UI
{
    public class EndCanvas : MonoBehaviour
    {
        public TextMeshProUGUI Name, Score, Coin;

        public void OnContinButton()
        {
            SceneManager.LoadScene("MainMenu");

        }
    }
}