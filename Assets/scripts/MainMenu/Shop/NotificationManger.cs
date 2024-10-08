using UnityEngine;
using TMPro;
using PrimeTween;

namespace HillClimb3d.UI
{
    public class NotificationManger : MonoBehaviour
    {

        [SerializeField]
        TextMeshProUGUI _text;

        Tween _anim = new Tween();

        public void Message(string textMessage)
        {
            _anim.Stop();

            transform.localScale = new Vector3(1, 1, 1);

            _text.text = textMessage;

            _anim = Tween.Scale(transform, 0f, 5f);
        }
    }
}
