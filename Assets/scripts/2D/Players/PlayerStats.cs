using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayer", menuName = "ScriptableObjects/Cars/PlayerStats", order = 1)]
public class PlayerStats : ScriptableObject
{
    public int MaxLevel = 5;

    [SerializeField]
    private int _correctLevelOfSpeed, _correctLevelOfFuel = 1;

    public int CorrectLevelOfSpeed { get { return _correctLevelOfSpeed; } set { _correctLevelOfSpeed = value > MaxLevel ? MaxLevel : value; } }
    public int CorrectLevelOfFuel { get { return _correctLevelOfFuel; } set { _correctLevelOfFuel = value > MaxLevel ? MaxLevel : value; } }

    [SerializeField]
    private float _maxScore = 0;
    public float MaxScore { get; }

    [SerializeField]
    private float _correctScore = 0;
    public float CorrectScore
    {

        get { return _correctScore; }
        set
        {
            if (value > 0)
                _correctScore = value;

            if (_maxScore < _correctScore)
                _maxScore = _correctScore;
        }
    }

    public int Coins;

    public float CalculateSpeedMultiplier(CarSettings car)
    {
        // ��������, ����� currentLevel ��� � �������� ����������� ���������
        _correctLevelOfSpeed = Mathf.Clamp(_correctLevelOfSpeed, 1, MaxLevel);

        // ������� ������� ��������� ��������
        return car.StartSpeedMult + ((car.MaxSpeedMult - car.StartSpeedMult) / (MaxLevel - 1)) * (_correctLevelOfSpeed - 1);
    }

    public float CalculateFuelMultiplier(CarSettings car)
    {
        // ��������, ����� currentLevel ��� � �������� ����������� ���������
        _correctLevelOfFuel = Mathf.Clamp(_correctLevelOfFuel, 1, MaxLevel);

        // ������� ������� ��������� ��������
        return car.StartFuelEffec - ((car.StartFuelEffec - car.MaxFuelEffec) / (MaxLevel - 1)) * (_correctLevelOfFuel - 1);
    }
}
