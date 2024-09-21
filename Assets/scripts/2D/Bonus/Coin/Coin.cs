using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinInit : MonoBehaviour
{

    [SerializeField]
    CoinSettings _settings;
    private void Start()
    {
        transform.GetComponentInChildren<TextMeshProUGUI>().text = _settings.Value.ToString();

        transform.localScale *= _settings.Size;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            //“”“ ¿Õ»Ã¿÷»ﬁ –Œ‘À ¬—“¿¬»ÿ. Ó ?


        }
    }
}
