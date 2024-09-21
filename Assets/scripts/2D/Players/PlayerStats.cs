using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayer", menuName = "ScriptableObjects/Cars/PlayerStats", order = 1)]
public class PlayerStats : ScriptableObject
{
    public int MaxLevel = 5;


    private int _correctLevelOfSpeed = 1;
    private int _correctLevelOfFuel = 1;

    public int CorrectLevelOfSpeed { get { return _correctLevelOfSpeed; } set { _correctLevelOfSpeed = value > MaxLevel ? MaxLevel : value; } }
    public int CorrectLevelOfFuel { get { return _correctLevelOfFuel; } set { _correctLevelOfFuel = value > MaxLevel ? MaxLevel : value; } }


    private float _maxScore = 0;
    public float MaxScore { get; }


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

    public float CalculateSpeedMultiplier(CarSettings car)
    {
        // ѕроверка, чтобы currentLevel был в пределах допустимого диапазона
        _correctLevelOfSpeed = Mathf.Clamp(_correctLevelOfSpeed, 1, MaxLevel);

        // ‘ормула расчета множител€ скорости
        return car.StartSpeedMult + ((car.MaxSpeedMult - car.StartSpeedMult) / (MaxLevel - 1)) * (_correctLevelOfSpeed - 1);
    }

    public float CalculateFuelMultiplier(CarSettings car)
    {
        // ѕроверка, чтобы currentLevel был в пределах допустимого диапазона
        _correctLevelOfFuel = Mathf.Clamp(_correctLevelOfFuel, 1, MaxLevel);

        // ‘ормула расчета множител€ скорости
        return car.StartFuelEffec - ((car.StartFuelEffec - car.MaxFuelEffec) / (MaxLevel - 1)) * (_correctLevelOfFuel - 1);
    }
}
