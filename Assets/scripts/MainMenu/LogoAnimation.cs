using UnityEngine;
using PrimeTween;

namespace HillClimb3d.Tweekers
{
    public class LogoAnimation : MonoBehaviour
    {
        const float ANGLE_Y = 10;
        const float TIME_FOR_ONE_CYCLE = 4F;

        const float SIZE_SCALE = 0.7F;

        private void Start()
        {
            Tween.LocalRotation(transform, new Vector3(0, 0, ANGLE_Y), TIME_FOR_ONE_CYCLE, Ease.Default, cycles: -1, CycleMode.Yoyo);
            Tween.Scale(transform, SIZE_SCALE, TIME_FOR_ONE_CYCLE/2, Ease.Default, cycles: -1, CycleMode.Yoyo);
        }
    }
}