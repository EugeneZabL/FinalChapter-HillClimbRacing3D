using UnityEngine;
using UnityEngine.EventSystems;
using PrimeTween;
using HillClimb3d.CommonLogic;

namespace HillClimb3d.UI.Controll
{
    public class GasButtonTrigger : EventTrigger
    {
        Vector3 _baseScale;
        const float SCALE_MIN = 0.8F;
        const float TIME = 0.3F;

        private void Start()
        {
            _baseScale = transform.localScale;
        }
        public override void OnPointerUp(PointerEventData data)
        {
            Car2d.Instance.BreakIsPressed = false;

            Tween.Scale(transform, _baseScale, TIME, Ease.InOutBack);
        }
        public override void OnPointerDown(PointerEventData data)
        {
            Car2d.Instance.BreakIsPressed = true;
            
            Tween.Scale(transform, _baseScale* SCALE_MIN, TIME, Ease.InOutBack);
        }
    }
}
