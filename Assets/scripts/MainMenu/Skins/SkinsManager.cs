using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HillClimb3d.UI.Skins
{
    public class SkinsManager : MonoBehaviour
    {
        [SerializeField]
        private List<CarSettings> _carTypes;

        [SerializeField]
        private PlayerStats _playerStat;

        [SerializeField]
        private Transform _carModel;

        private int _index = 0;

        private void OnEnable()
        {
            _playerStat.CarType.TakeCarModel(_carModel);
            _index = _carTypes.IndexOf(_playerStat.CarType);
        }

        public void OnLeftSkins()
        {
            if (_index > 0)
                _index--;
            else
                _index = _carTypes.Count - 1;

            _playerStat.CarType = _carTypes[_index];
            _playerStat.CarType.TakeCarModel(_carModel);
        }
        public void OnRightSkins()
        {
            if (_index < _carTypes.Count - 1)
                _index++;
            else
                _index = 0;

            _playerStat.CarType = _carTypes[_index];
            _playerStat.CarType.TakeCarModel(_carModel);
        }

        public void OnLeftColor()
        {
            if (_playerStat.CarType.ColorIndex > 0)
                _playerStat.CarType.ColorIndex--;
            else
                _playerStat.CarType.ColorIndex = _playerStat.CarType.MaxColors - 1;

            _playerStat.CarType.TakeCarModel(_carModel);
        }

        public void OnRightColor()
        {
            if (_playerStat.CarType.ColorIndex < _playerStat.CarType.MaxColors - 1)
                _playerStat.CarType.ColorIndex++;
            else
                _playerStat.CarType.ColorIndex = 0;

            _playerStat.CarType.TakeCarModel(_carModel);
        }
    }
}
