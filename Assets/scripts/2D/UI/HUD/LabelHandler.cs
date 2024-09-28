using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace HillClimb3d.UI
{
    public class LableHandler : MonoBehaviour
    {
        public static LableHandler Instance { get; private set; }

        [HideInInspector]
        public Canvas HUDCanvas;

        [HideInInspector]
        public DistantCalculate DistantCalc;

        [SerializeField]
        TextMeshProUGUI _scoreLable, _coinLable, _fuelLable, _distanceLable;

        [SerializeField]
        Slider _fuelSlider, _distanceSlider;

        public Slider DistancesSlider { get { return _distanceSlider; } set { _distanceSlider = value; } }

        private void Awake()
        {
            Instance = this;
            HUDCanvas = GetComponent<Canvas>();
            DistantCalc = GetComponent<DistantCalculate>();
        }

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
}
