using UnityEngine;
using HillClimb3d.CommonLogic;

namespace HillClimb3d.UI
{
    public class DistantCalculate : MonoBehaviour
    {
        [SerializeField]
        private Transform _player, _finish;

        private Vector3 _start;

        [HideInInspector]
        private float _metersCounter = 0;

        public float MetersCounter { get; }


        private void Start()
        {
            if(_player == null)
                _player = Car2d.Instance.GetComponent<Transform>();

            if(_finish == null)
                _finish = FinishManager.Instance.GetComponent<Transform>();

            _start = _player.transform.position;

            LableHandler.Instance.DistancesSlider.maxValue = Vector3.Distance(_player.position, _finish.position);

        }

        private void FixedUpdate()
        {
            _metersCounter += Mathf.Abs(Vector3.Distance(_start, _player.position) - LableHandler.Instance.DistancesSlider.value);

            LableHandler.Instance.UpdateDistance(Vector3.Distance(_player.position, _finish.position), Vector3.Distance(_start, _player.position));
        }
    }
}
