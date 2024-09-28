using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HillClimb3d.UI;

namespace HillClimb3d.CommonLogic
{
    public class ScoreManager : MonoBehaviour
    {

        private int _currentCoin = 0;
        public int CurrentCoin { get; set; }

        private float _currentScore = 0;
        public float CurrentScore { get { return Mathf.Round(_currentScore + _distantCounter.MetersCounter * _distantMulti); } }

        private PlayerStats _playerStat;
        private DistantCalculate _distantCounter;

        [SerializeField]
        private float _distantMulti = 1.0f;

        private GameObject _endCanvas;

        const float BONUS_WIN_SCORE = 1000;

        void Start()
        {
            _playerStat = Car2d.Instance.PlayerStat;
            _distantCounter = LableHandler.Instance.DistantCalc;
        }

        private void FixedUpdate()
        {
            LableHandler.Instance.UpdateFuel(Car2d.Instance.AmountOfFuel);
            LableHandler.Instance.UpdateCoinLine(_currentCoin);
            LableHandler.Instance.UpdateScoreLine(_currentScore + (_distantCounter.MetersCounter * _distantMulti));
        }

        public void TakeCoin(CoinSettings coinStat)
        {
            _currentScore += coinStat.ScoreMulti * coinStat.Value;
            _currentCoin += coinStat.Value;
        }

        public void EndGame(bool isWin)
        {
            LableHandler.Instance.HUDCanvas.gameObject.SetActive(false);

            _endCanvas = Instantiate(Resources.Load("EndCanvas") as GameObject);
            _endCanvas.SetActive(true);

            EndCanvas endScript = _endCanvas.GetComponent<EndCanvas>();
            if (isWin)
                endScript.Name.text = "Congratulations, you've won! ;)";
            else
                endScript.Name.text = "Running out of fuel! :(";


            _currentScore += Mathf.Round(_distantCounter.MetersCounter * _distantMulti) + (isWin ? BONUS_WIN_SCORE : 0);
            endScript.Score.text = _playerStat.MaxScore < _currentScore ? "New Record! \n<color=\"green\">Score - " + _currentScore : "Score - " + _currentScore;

            endScript.Coin.text = _playerStat.Coins + " + " + _currentCoin + "\nMoney - " + (_playerStat.Coins + _currentCoin);

            SaveStats();
        }

        public void SaveStats()
        {
            _playerStat.MaxScore = Mathf.Round(_currentScore);
            _playerStat.Coins += _currentCoin;
        }


    }
}

