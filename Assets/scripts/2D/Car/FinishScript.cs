using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HillClimb3d.CommonLogic
{
    public class FinishManager : MonoBehaviour
    {
        public static FinishManager Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.transform.tag == "Player")
            {
                collision.attachedRigidbody.GetComponent<Car2d>().StopGame(true);
            }
        }
    }
}
