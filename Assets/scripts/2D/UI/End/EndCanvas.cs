using UnityEngine;
using TMPro;
using HillClimb3d.UI.Loading;

namespace HillClimb3d.UI
{
    public class EndCanvas : MonoBehaviour
    {
        public TextMeshProUGUI Name, Score, Coin;

        public void OnContinButton()
        {
            LoadManager.Instance.ChangeScreen("MainMenu");
        }
    }
}