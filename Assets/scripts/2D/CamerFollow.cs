using UnityEngine;

namespace HillClimb3d.CommonLogic
{
    public class CamerFollow : MonoBehaviour
    {
        [SerializeField]
        Transform _posToFollow;

        void Update()
        {
            transform.position = Vector3.Lerp(transform.position, _posToFollow.position, Time.deltaTime);
        }
    }
}
