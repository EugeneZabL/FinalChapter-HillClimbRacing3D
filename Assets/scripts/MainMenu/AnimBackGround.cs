using UnityEngine;
using PrimeTween;

namespace HillClimb3d.Tweekers
{
    public class AnimBackGround : MonoBehaviour
    {
        const float END_POSITON_X = -60;
        const float TIME_FOR_ONE_CYCLE = 15;
        private void Start()
        {
            Tween.PositionX(transform, END_POSITON_X, TIME_FOR_ONE_CYCLE, Ease.Linear, -1, CycleMode.Yoyo);
        }
    }
}
