using UnityEngine;
using PrimeTween;

namespace HillClimb3d.Tweekers {
    public class AnimationForObject : MonoBehaviour
    {
        Tween _anim;

        const float TIME_FOR_ONE_CYCLE_PEACE = 1F;
        const float DISTANT_TO_UP_PEACE = 0.5F;
        private void Start()
        {
            _anim = Tween.PositionY(transform, transform.position.y + DISTANT_TO_UP_PEACE, TIME_FOR_ONE_CYCLE_PEACE , Ease.InExpo, -1, CycleMode.Yoyo);
            _anim = Tween.EulerAngles(transform, startValue: Vector3.zero, endValue: new Vector3(0, 360), duration: TIME_FOR_ONE_CYCLE_PEACE, Ease.Default, -1, CycleMode.Restart, startDelay: TIME_FOR_ONE_CYCLE_PEACE );
            //Tween.Scale(transform, new Vector3(1.3f, 0.7f, 1.5f), 1f, Ease.InExpo,-1,CycleMode.Yoyo);
        }

        const float TIME_TO_TAKE = 0.5F;
        const float DISTANT_TO_UP_TAKE = 2F;
        public void TakeAnim()
        {
            GetComponent<AudioSource>().Play();
            _anim.Stop();
            _anim = Tween.PositionY(transform, transform.position.y + DISTANT_TO_UP_TAKE, TIME_TO_TAKE, Ease.InExpo);
            _anim = Tween.Scale(transform, new Vector3(0f, 0f, 0f), TIME_TO_TAKE, Ease.InExpo).OnComplete(() => Destroy(gameObject));
        }
    }
}
