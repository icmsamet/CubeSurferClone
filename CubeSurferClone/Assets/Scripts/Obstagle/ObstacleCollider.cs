using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Obstacle
{
    public class ObstacleCollider
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
                    if(GameManager.GameManager.instance.CheckStart())
                        GameManager.GameManager.instance.FailGame();
                }
            }
        }
    }
}
