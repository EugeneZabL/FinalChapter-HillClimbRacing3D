using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FuelInit : MonoBehaviour
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
        Debug.Log("ok&");
        if (collision.transform.tag == "Player")
        {

            //“”“ ¿Õ»Ã¿÷»ﬁ –Œ‘À ¬—“¿¬»ÿ. Ó ?

            collision.attachedRigidbody.GetComponent<Car2d>().AmountOfFuel += _settings.Value;

            Destroy(gameObject);
        }
    }
}
