using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PrimeTween;

public class AnimationForObject : MonoBehaviour
{
    private void Start()
    {
        Tween.PositionY(transform, transform.position.y + 0.5f, 1f, Ease.InExpo,-1, CycleMode.Yoyo) ;
        Tween.EulerAngles(transform, startValue: Vector3.zero, endValue: new Vector3(0, 360), duration: 1f, Ease.Default,-1,CycleMode.Restart, startDelay: 1f);
        Tween.Scale(transform, new Vector3(1.3f, 0.7f, 1.5f), 1f, Ease.InExpo,-1,CycleMode.Yoyo);
    }
}
