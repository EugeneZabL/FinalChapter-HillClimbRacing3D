using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayer", menuName = "ScriptableObjects/Cars/PlayerStats", order = 1)]
public class PlayerStats : ScriptableObject
{
    public CarSettings CarType;

    public int MaxLevel = 5;

    [SerializeField]
    private int _correctLevelOfSpeed, _correctLevelOfFuel = 1;

    public int CorrectLevelOfSpeed { get { return _correctLevelOfSpeed; } set { _correctLevelOfSpeed = value > MaxLevel ? MaxLevel : value; } }
    public int CorrectLevelOfFuel { get { return _correctLevelOfFuel; } set { _correctLevelOfFuel = value > MaxLevel ? MaxLevel : value; } }

    [SerializeField]
    private float _maxScore = 0;
    public float MaxScore { get { return _maxScore; } set { _maxScore = value>_maxScore ? value : _maxScore; } }

    public int Coins;

    public float CalculateSpeedMultiplier()
    {
        // ѕроверка, чтобы currentLevel был в пределах допустимого диапазона
        _correctLevelOfSpeed = Mathf.Clamp(_correctLevelOfSpeed, 1, MaxLevel);

        // ‘ормула расчета множител€ скорости
        return CarType.StartSpeedMult + ((CarType.MaxSpeedMult - CarType.StartSpeedMult) / (MaxLevel - 1)) * (_correctLevelOfSpeed - 1);
    }

    public float CalculateFuelMultiplier()
    {
        // ѕроверка, чтобы currentLevel был в пределах допустимого диапазона
        _correctLevelOfFuel = Mathf.Clamp(_correctLevelOfFuel, 1, MaxLevel);

        // ‘ормула расчета множител€ скорости
        return CarType.StartFuelEffec - ((CarType.StartFuelEffec - CarType.MaxFuelEffec) / (MaxLevel - 1)) * (_correctLevelOfFuel - 1);
    }
}
