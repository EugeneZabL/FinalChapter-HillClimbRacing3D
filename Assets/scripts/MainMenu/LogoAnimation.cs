using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PrimeTween;

public class LogoAnimation : MonoBehaviour
{
    private void Start()
    {
        Tween.LocalRotation(transform,new Vector3(0,0,10),4f,Ease.Default,cycles:-1,CycleMode.Yoyo);
        Tween.Scale(transform, 0.7f, 2f, Ease.Default, cycles: -1, CycleMode.Yoyo);
    }
}
