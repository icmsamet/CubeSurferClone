using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerChildRaycast
    {
        PlayerChildTransform playerChild;

        public PlayerChildRaycast(PlayerChildTransform _playerChild)
        {
            playerChild = _playerChild;
        }

        public void CheckSelf()
        {
            RaycastHit hit;
            // Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(playerChild.childTransform.position, playerChild.childTransform.TransformDirection(Vector3.down), out hit, 1))
            {
                playerChild.SetLocalPosition();
                Debug.DrawRay(playerChild.childTransform.position, playerChild.childTransform.TransformDirection(Vector3.down) * hit.distance, Color.yellow);
            }
            else
            {
                playerChild.AddLocalPosition(new Vector3(0, -1.1f, 0), CheckSelf);
            }
        }
    }
}
