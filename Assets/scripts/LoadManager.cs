using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using PrimeTween;

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
        float _audioVolume = 0.4f;

        [SerializeField]
        List<AudioClip> _audioClips;

        const float TIME_FOR_ONE_CYCLE = 0.5F;

        private void Start()
        {
            Instance = this;
            AudioSource _audio = GetComponent<AudioSource>();
            _audio.clip = _audioClips[Random.Range(0, _audioClips.Count)];
            _audio.Play();


            Tween.LocalPositionY(_backGround.transform, -Screen.height, TIME_FOR_ONE_CYCLE, Ease.InExpo, startDelay: 0.2f).OnComplete(() => _canvas.enabled = false);
            Tween.AudioVolume(_audio, _audioVolume, 1f);
        }

        public void ChangeScreen(string sceneName)
        {
            _canvas.enabled = true;
            Tween.LocalPositionY(_backGround.transform, 0, TIME_FOR_ONE_CYCLE, Ease.InExpo).OnComplete(() => NextStep(sceneName));
            Tween.AudioVolume(GetComponent<AudioSource>(), 0, TIME_FOR_ONE_CYCLE);
        }

        void NextStep(string sceneName)
        {
            Tween.StopAll();
            SceneManager.LoadScene(sceneName);
        }
    }
}
