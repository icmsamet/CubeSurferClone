using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Stair
{
    public class StairRigidbody
    {
        Rigidbody rigidbody;

        public StairRigidbody(Rigidbody _rigidbody)
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
