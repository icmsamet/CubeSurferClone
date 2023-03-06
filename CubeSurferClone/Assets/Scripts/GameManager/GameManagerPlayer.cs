using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;


namespace GameManager
{
    public class GameManagerPlayer
    {
        PlayerProperties playerProperties;
        public GameManagerPlayer(PlayerProperties _playerProperties)
        {
            playerProperties = _playerProperties;
        }

        public void SetPlayerSpeeds(float moveSpeed,float followSpeed)
        {
            playerProperties.followSpeed = followSpeed;
            playerProperties.moveSpeed = moveSpeed;
            playerProperties.splineFollower.followSpeed = playerProperties.followSpeed;
        }

        public void StartGame()
        {
            GameSettings gameSettings = Resources.Load<GameSettings>("Game Settings");
            SetPlayerSpeeds(gameSettings.playerMoveSpeed, gameSettings.playerFollowSpeed);
        }

        public void StopGame()
        {
            SetPlayerSpeeds(0, 0);
        }
    }
}
