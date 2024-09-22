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
        // ���� ��� ���� ���������, �� ������ ����� � ���������� ������� ������
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // ������������� ������� ��������� ��� ��������
        Instance = this;

        // �� �������� DontDestroyOnLoad, ����� ������ ��� ��������� ��� ����� �����
    }

    private void OnDestroy()
    {
        // ��� ����������� ����� ��� ������� ���������� ������
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
