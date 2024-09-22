using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FuelScript : MonoBehaviour
{
    [SerializeField]
    FuelSettings _settings;

    private void Start()
    {
        transform.GetComponentInChildren<TextMeshProUGUI>().text = _settings.Value.ToString();

        transform.localScale *= _settings.Size;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {

            Destroy(GetComponent<Collider2D>());

            collision.attachedRigidbody.GetComponent<Car2d>().AmountOfFuel += _settings.Value;

            GetComponent<AnimationForObject>().TakeAnim();

        }
    }
}
