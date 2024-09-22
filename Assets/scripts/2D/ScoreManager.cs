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

    [SerializeField]
    GameObject _endCanvas;


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
        _endCanvas.SetActive(true);

        EndCanvas endScript = _endCanvas.GetComponent<EndCanvas>();
        if (isWin)
            endScript.Name.text = "You won";
        else
            endScript.Name.text = "Running out of fuel! :(";

        float tempScore = Mathf.Round(_distantCounter._metersCounter * _distantMulti);
        endScript.Score.text = _playerStat.MaxScore < tempScore ? "New Record! \n<color=\"green\">Score - " + tempScore : "Score - " + tempScore;

        endScript.Coin.text = _playerStat.Coins + " + " + _currentCoin + "\nMoney - "+ (_playerStat.Coins + _currentCoin);

        SaveStats();
    }

    public void SaveStats()
    {
        _currentScore += _distantCounter._metersCounter * _distantMulti;

        _playerStat.MaxScore = Mathf.Round(_currentScore);
        _playerStat.Coins += _currentCoin;
    }


}

