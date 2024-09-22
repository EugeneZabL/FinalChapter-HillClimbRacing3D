using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PrimeTween;

public class AnimationForObject : MonoBehaviour
{
    Tween _anim;
    private void Start()
    {
        _anim = Tween.PositionY(transform, transform.position.y + 0.5f, 1f, Ease.InExpo,-1, CycleMode.Yoyo) ;
        _anim = Tween.EulerAngles(transform, startValue: Vector3.zero, endValue: new Vector3(0, 360), duration: 1f, Ease.Default,-1,CycleMode.Restart, startDelay: 1f);
        //Tween.Scale(transform, new Vector3(1.3f, 0.7f, 1.5f), 1f, Ease.InExpo,-1,CycleMode.Yoyo);
    }

    public void TakeAnim()
    {
        GetComponent<AudioSource>().Play();
        _anim.Stop();
        _anim = Tween.PositionY(transform, transform.position.y + 2f, 0.5f, Ease.InExpo);
        _anim = Tween.Scale(transform, new Vector3(0f, 0f, 0f), 0.5f, Ease.InExpo).OnComplete(()=>Destroy(gameObject));
    }

}
