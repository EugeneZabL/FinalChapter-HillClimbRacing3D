using UnityEngine;
using HillClimb3d.UI.Loading;

namespace HillClimb3d.UI
{
    public class MainMenuManager : MonoBehaviour
    {
        public void OnClick()
        {
            LoadManager.Instance.ChangeScreen("2D GraficUpdate");
        }
    }
}
