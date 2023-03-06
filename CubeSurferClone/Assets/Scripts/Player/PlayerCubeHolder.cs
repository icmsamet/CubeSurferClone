using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerCubeHolder
    {
        PlayerProperties playerProperties;
        public PlayerCubeHolder(PlayerProperties _playerProperties)
        {
            playerProperties = _playerProperties;
        }
        public void CheckAll()
        {
            foreach (Transform item in playerProperties.cubeHolder.transform)
            {
                item.gameObject.GetComponent<Collectable.Collectable>().CheckSelf();
            }
        }
    }
}
