using UnityEngine;
using HillClimb3d.UI.Loading;


namespace HillClimb3d.UI.Pause
{
    public class PauseButonType : MonoBehaviour
    {
        public void OnMainMenuGo()
        {
            Time.timeScale = 1;
            LoadManager.Instance.ChangeScreen("MainMenu");
        }

        public void OnRestartLevel()
        {
            Time.timeScale = 1;
            LoadManager.Instance.ChangeScreen("2D GraficUpdate");
        }

        public void OnPauseOpen()
        {
            gameObject.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }
}
