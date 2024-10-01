using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using PrimeTween;
using TMPro;

namespace HillClimb3d.UI.Loading
{
    public class LoadManager : MonoBehaviour
    {
        public static LoadManager Instance { get; private set; }

        [SerializeField]
        private Canvas _canvas;

        [SerializeField]
        private Image _backGround;

        [SerializeField]
        private TextMeshProUGUI _tipText;

        [SerializeField]
        float _audioVolume = 0.4f;

        private AudioSource _audioSours;

        [SerializeField]
        List<AudioClip> _mainMenu, _game;

        [SerializeField]
        List<string> _tips;



        const float TIME_FOR_ONE_CYCLE = 0.5F;

        private void Start()
        {
            Instance = this;

            _audioSours = GetComponent<AudioSource>();

            _audioSours.clip = _mainMenu[Random.Range(0, _mainMenu.Count)];
            _audioSours.Play();


            Tween.LocalPositionY(_backGround.transform, -Screen.height, TIME_FOR_ONE_CYCLE, Ease.InExpo, startDelay: 0.2f).OnComplete(() => _canvas.enabled = false);
            Tween.AudioVolume(_audioSours, _audioVolume, 1f);
        }



        public void ChangeScreen(string sceneName)
        {
            _canvas.enabled = true;
            WriteRandomTips();
            Tween.LocalPositionY(_backGround.transform, 0, TIME_FOR_ONE_CYCLE, Ease.InExpo).OnComplete(() => NextStep(sceneName));
            Tween.AudioVolume(_audioSours, 0, TIME_FOR_ONE_CYCLE);
        }

        void NextStep(string sceneName)
        {
            if (sceneName == "MainMenu")
                _audioSours.clip = _mainMenu[Random.Range(0, _mainMenu.Count)];
            else
                _audioSours.clip = _game[Random.Range(0, _game.Count)];

            Tween.StopAll();
            AsyncOperation async = SceneManager.LoadSceneAsync(sceneName);
            async.completed += SceneLoaded;
        }

        private void SceneLoaded(AsyncOperation asyncOperation)
        {
            _audioSours.Play();
            Tween.LocalPositionY(_backGround.transform, -Screen.height, TIME_FOR_ONE_CYCLE, Ease.InExpo, startDelay: 0.2f).OnComplete(() => _canvas.enabled = false);
            Tween.AudioVolume(_audioSours, _audioVolume, 1f);
        }

        private void WriteRandomTips()
        {
            _tipText.text = "Tips - " + _tips[Random.Range(0, _tips.Count)];
        }
    }
}
