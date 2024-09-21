using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PrimeTween;

public class AnimBackGround : MonoBehaviour
{
    private void Start()
    {
        Tween.PositionX(transform, -60f, 15, Ease.Linear, -1, CycleMode.Yoyo);
    }
}
