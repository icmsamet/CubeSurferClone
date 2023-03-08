using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stair
{
    public class StairCollider
    {
        public void CollisionEnter(Collision collision)
        {
            foreach (ContactPoint contact in collision.contacts)
            {
                // get the transform of the collided child object
                Transform collidedChildTransform = contact.otherCollider.transform;
                var collectable = collidedChildTransform.gameObject.GetComponent<Collectable.Collectable>();
                if (collectable && collectable.isCollected)
                {
                    collectable.transform.SetParent(null);
                }
                else
                {
                    GameManager.GameManager.instance.WinGame();
                }
            }
        }
    }
}
