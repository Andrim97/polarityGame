using System;
using UnityEngine;

namespace AGDDPlatformer
{
    public class CameraTarget : MonoBehaviour
    {
        public Transform[] targets;

        void LateUpdate()
        {
            float averageX = 0;
            foreach (Transform target in targets)
            {
                averageX += target.position.x;
            }

            averageX /= targets.Length;

            transform.position = new Vector3(averageX, transform.position.y, transform.position.z);
        }
    }
}
