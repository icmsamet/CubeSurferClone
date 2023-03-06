using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Obstacle
{
    public class ObstacleRigidbody
    {
        Rigidbody rigidbody;

        public ObstacleRigidbody(Rigidbody _rigidbody)
        {
            rigidbody = _rigidbody;
        }
        public void SetConstains(RigidbodyConstraints constraints)
        {
            rigidbody.constraints = constraints;
        }
        public void SetGravity(bool state)
        {
            rigidbody.useGravity = state;
        }
    }
}
