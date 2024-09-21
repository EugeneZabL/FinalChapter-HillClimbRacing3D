using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using PrimeTween;

public class NotificationManger : MonoBehaviour
{

    [SerializeField]
    TextMeshProUGUI _text;

    CanvasGroup _canvasGroup;

    private void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }
    public void Message(string textMessage)
    {
        _canvasGroup.alpha = 1;

        _text.text = textMessage;

        Tween.Custom(1f,0f,1f, onValueChange: newVal => _canvasGroup.alpha = newVal, startDelay: 2f);
    }
}
