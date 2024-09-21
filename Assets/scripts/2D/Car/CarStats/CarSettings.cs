using UnityEngine;

[CreateAssetMenu(fileName = "NewCarType", menuName = "ScriptableObjects/Cars/CarSettings", order = 1)]
public class CarSettings : ScriptableObject
{
    public float StartSpeedMult = 0.5f;
    public float MaxSpeedMult = 1.2f;


    public float StartFuelEffec = 5.0f;
    public float MaxFuelEffec = 1f;


    [SerializeField]
    private AudioClip _idle, _lowOn,_lowOff, _medOn, _medOff, _highOn, _highOff;

    public AudioClip TakeAClip(float speed, float maxSpeed, bool isActive)
    {
        //Debug.Log("speed " + speed + " maxSpeed " + maxSpeed + " isActive " + isActive);

        // ���� ������ �� ��������, ������� ���� ��������� ����
        if (speed > -1 && speed<1)
        {
            return _idle;
        }

        // ������������ ��������� ������� �������� � ������������
        float speedRatio = speed / maxSpeed;

        //Debug.Log("speedRatio " + speedRatio);

        // � ����������� �� ��������� �������� ���������� ������ ����
        if (speedRatio < 0.33f)
        {
            return isActive ? _lowOn : _lowOff; // ������ ��������
        }
        else if (speedRatio < 0.66f)
        {
            return isActive ? _medOn : _medOff; // ������� ��������
        }
        else
        {
            return isActive ? _highOn : _highOff; // ������� ��������
        }
    }
}