using UnityEngine;

[CreateAssetMenu(fileName = "NewCarType", menuName = "ScriptableObjects/Cars/CarSettings", order = 1)]
public class CarSettings : ScriptableObject
{
    public float StartSpeedMult = 0.5f;
    public float MaxSpeedMult = 1.2f;


    public float StartFuelEffec = 5.0f;
    public float MaxFuelEffec = 1f;

    public int MaxColors { get { return _colors.Length; } }

    [SerializeField]
    private int _colorIndex;
    public int ColorIndex
    {
        get { return _colorIndex; }
        set
        {
            if (value >= MaxColors)
                value = MaxColors;
            if (value < 0)
                value = 0;

            _colorIndex = value;
        }
    }

    [SerializeField]
    private GameObject _carPrefab;
    [SerializeField]
    private Material[] _colors;

    [SerializeField]
    private AudioClip _idle, _lowOn, _lowOff, _medOn, _medOff, _highOn, _highOff;

    public AudioClip TakeAClip(float speed, float maxSpeed, bool isActive)
    {
        //Debug.Log("speed " + speed + " maxSpeed " + maxSpeed + " isActive " + isActive);

        // Если машина не движется, вернуть звук холостого хода
        if (speed > -1 && speed < 1)
        {
            return _idle;
        }

        // Рассчитываем отношение текущей скорости к максимальной
        float speedRatio = speed / maxSpeed;

        //Debug.Log("speedRatio " + speedRatio);

        // В зависимости от отношения скорости возвращаем нужный звук
        if (speedRatio < 0.33f)
        {
            return isActive ? _lowOn : _lowOff; // Низкая скорость
        }
        else if (speedRatio < 0.66f)
        {
            return isActive ? _medOn : _medOff; // Средняя скорость
        }
        else
        {
            return isActive ? _highOn : _highOff; // Высокая скорость
        }
    }

    public void TakeCarModel(Transform _parent)
    {

        foreach (Transform child in _parent)
        {
            Destroy(child.gameObject);  // Удаляем каждый дочерний объект
        }

        GameObject newObject = Instantiate(_carPrefab,_parent);

        Renderer[] meshes = newObject.GetComponentsInChildren<Renderer>();
        foreach(Renderer mesh in meshes)
        {
            mesh.material = _colors[_colorIndex];
        }
    }
}