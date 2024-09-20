using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FuelBar : MonoBehaviour
{
    private TextMeshProUGUI _text;

    private Slider _slider;

    private Car2d _player;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("CarBody").GetComponent<Car2d>();
        _text = transform.GetComponentInChildren<TextMeshProUGUI>();
        _slider = GetComponent<Slider>();
    }

    private void FixedUpdate()
    {
        _text.text = _player.AmountOfFuel.ToString("F1");
        _slider.value = _player.AmountOfFuel;
    }
}
