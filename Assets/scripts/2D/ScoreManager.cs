using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    private int _currentCoin = 0;
    public int currentCoin { get; set; }

    private float _currentScore = 0;
    public float CurrentScore { get { return Mathf.Round(_currentScore + _distantCounter._metersCounter * _distantMulti); } }

    private PlayerStats _playerStat;
    private DistantLabel _distantCounter;

    [SerializeField]
    private float _distantMulti = 12.0f;

    private GameObject _endCanvas;


    void Start()
    {
        _playerStat = GetComponent<Car2d>().PlayerStat;
        _distantCounter = LableHandler.Instance.DistantLabel;
    }

    private void FixedUpdate()
    {
        LableHandler.Instance.UpdateCoinLine(_currentCoin);
        LableHandler.Instance.UpdateScoreLine(_currentScore + (_distantCounter._metersCounter*_distantMulti));
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


        _currentScore += Mathf.Round(_distantCounter._metersCounter * _distantMulti) + (isWin ? 1000:0);
        endScript.Score.text = _playerStat.MaxScore < _currentScore ? "New Record! \n<color=\"green\">Score - " + _currentScore : "Score - " + _currentScore;

        endScript.Coin.text = _playerStat.Coins + " + " + _currentCoin + "\nMoney - "+ (_playerStat.Coins + _currentCoin);

        SaveStats();
    }

    public void SaveStats()
    {
        _playerStat.MaxScore = Mathf.Round(_currentScore);
        _playerStat.Coins += _currentCoin;
    }


}

