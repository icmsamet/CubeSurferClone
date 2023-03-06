using Dreamteck.Splines;
using UnityEngine;

namespace Player
{
    [System.Serializable]
    public class PlayerProperties
    {
        public SplineFollower splineFollower;
        public DynamicJoystick dynamicJoystick;
        public TrailRenderer trailRenderer;
        public Transform moveObject;
        public Transform childModel;
        public Transform cubeHolder;
        public float followSpeed;
        public float moveSpeed;
    }
}
