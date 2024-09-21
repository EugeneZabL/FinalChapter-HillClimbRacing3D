using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerFollow : MonoBehaviour
{
    [SerializeField]
    Transform _posToFollow;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position,_posToFollow.position,Time.deltaTime);
    }
}
