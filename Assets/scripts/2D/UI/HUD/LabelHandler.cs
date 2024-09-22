using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LableHandler : MonoBehaviour
{
    public static LableHandler Instance { get; private set; }

    private void Awake()
    {
        // Если уже есть экземпляр, не создаём новый и уничтожаем текущий объект
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // Устанавливаем текущий экземпляр как активный
        Instance = this;

        // Не вызываем DontDestroyOnLoad, чтобы объект был уничтожен при смене сцены
    }

    private void OnDestroy()
    {
        // При уничтожении сцены или объекта сбрасываем ссылку
        if (Instance == this)
        {
            Instance = null;
        }
    }

    public Canvas HUDCanvas;

    [SerializeField]
    TextMeshProUGUI _scoreLable, _coinLable, _fuelLable, _distanceLable;

    [SerializeField]
    Slider _fuelSlider, _distanceSlider;

    public Slider DistancesSlider { get {return _distanceSlider; } set { _distanceSlider = value; } }

    public DistantLabel DistantLabel;

    public void UpdateScoreLine(float score)
    {
        _scoreLable.text = score.ToString("F0");
    }
    public void UpdateCoinLine(float coins)
    {
        _coinLable.text = coins.ToString("F0");
    }

    public void UpdateFuel(float amountFuel)
    {
        _fuelLable.text = amountFuel.ToString("F1");
        _fuelSlider.value = amountFuel;
    }

    public void UpdateDistance(float playerToFinish, float playerToStart)
    {
        _distanceLable.text = playerToFinish.ToString("F0");
        _distanceSlider.value = playerToStart;
    }
}
