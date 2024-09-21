using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PauseDisable : MonoBehaviour
{
    public float _counter = 4;

    [SerializeField]
    private GameObject _interface;

    [SerializeField]
    private GameObject _counterObj;

    [SerializeField]
    private TextMeshProUGUI _text;

    private void OnEnable()
    {
        _interface.SetActive(false);
        _counterObj.SetActive(true);

        _text.text = _counter.ToString("F0");
        _counter = 4;
    }

    private void Update()
    {
        _counter -= 1 * Time.unscaledDeltaTime;
        _text.text = _counter.ToString("F0");

        if (_counter < 1)
        {
            _interface.SetActive(true);
            _counterObj.SetActive(false);

            Time.timeScale = 1;

            gameObject.SetActive(false);
            this.enabled = false;
        }
    }
}
