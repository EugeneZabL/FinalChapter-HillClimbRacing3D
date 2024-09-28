using UnityEngine;
using TMPro;

namespace HillClimb3d.UI.Shop
{
    public class ShopMenu : MonoBehaviour
    {
        [SerializeField]
        private int _basePrice = 20;

        [SerializeField]
        private PlayerStats _playerStat;

        [SerializeField]
        private TextMeshProUGUI _levelSpeed, _levelFuel, _coins;

        [SerializeField]
        private NotificationManger _notifi;


        private void OnEnable()
        {
            _levelSpeed.text = _playerStat.CorrectLevelOfSpeed + "/" + _playerStat.MaxLevel + (_playerStat.CorrectLevelOfSpeed < _playerStat.MaxLevel ? "\n <size=40%>" + "Now need - " + _basePrice * _playerStat.CorrectLevelOfSpeed : "");
            _levelFuel.text = _playerStat.CorrectLevelOfFuel + "/" + _playerStat.MaxLevel + (_playerStat.CorrectLevelOfFuel < _playerStat.MaxLevel ? "\n <size=40%>" + "Now need - " + _basePrice * _playerStat.CorrectLevelOfFuel : "");
            UpdateCoins();
        }

        public void OnBuySpeed()
        {
            if (_playerStat.CorrectLevelOfSpeed < _playerStat.MaxLevel && _basePrice * _playerStat.CorrectLevelOfSpeed <= _playerStat.Coins)
            {
                _playerStat.Coins -= _basePrice * _playerStat.CorrectLevelOfSpeed;
                _playerStat.CorrectLevelOfSpeed++;

                _levelSpeed.text = _playerStat.CorrectLevelOfSpeed + "/" + _playerStat.MaxLevel + (_playerStat.CorrectLevelOfSpeed < _playerStat.MaxLevel ? "\n <size=40%>" + "Now need - " + _basePrice * _playerStat.CorrectLevelOfSpeed : "");
            }
            else
            {
                if (_playerStat.CorrectLevelOfSpeed == _playerStat.MaxLevel)
                    _notifi.Message("<color=\"green\"> Maximum Improvement");
                else
                    _notifi.Message("<color=\"red\"> Not enough money");
            }
            UpdateCoins();
        }
        public void OnBuyFuel()
        {
            if (_playerStat.CorrectLevelOfFuel < _playerStat.MaxLevel && _basePrice * _playerStat.CorrectLevelOfFuel <= _playerStat.Coins)
            {
                _playerStat.Coins -= _basePrice * _playerStat.CorrectLevelOfFuel;
                _playerStat.CorrectLevelOfFuel++;

                _levelFuel.text = _playerStat.CorrectLevelOfFuel + "/" + _playerStat.MaxLevel + (_playerStat.CorrectLevelOfFuel < _playerStat.MaxLevel ? "\n <size=40%>" + "Now need - " + _basePrice * _playerStat.CorrectLevelOfFuel : "");
            }
            else
            {
                if (_playerStat.CorrectLevelOfFuel == _playerStat.MaxLevel)
                    _notifi.Message("<color=\"green\"> Maximum Improvement");
                else
                    _notifi.Message("<color=\"red\"> Not enough money");
            }
            UpdateCoins();
        }

        void UpdateCoins()
        {
            _coins.text = _playerStat.Coins.ToString();
        }
    }
}
