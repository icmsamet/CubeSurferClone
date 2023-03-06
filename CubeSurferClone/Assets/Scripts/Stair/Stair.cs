using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stair
{
    [RequireComponent(typeof(Rigidbody))]
    public class Stair : MonoBehaviour
    {
        StairRigidbody rigidbody;
        StairCollider collider;

        private void Start()
        {
            collider = new StairCollider();
            rigidbody = new StairRigidbody(GetComponent<Rigidbody>());
            rigidbody.SetConstains(RigidbodyConstraints.FreezeAll);
            rigidbody.SetGravity(false);
        }

        private void OnCollisionEnter(Collision collision)
        {
            collider.CollisionEnter(collision);
        }
    }
}
