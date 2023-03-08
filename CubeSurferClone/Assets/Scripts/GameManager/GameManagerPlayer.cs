using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;


namespace GameManager
{
    public class GameManagerPlayer
    {
        PlayerProperties playerProperties;
        Player.Player player;
        public GameManagerPlayer(Player.Player _player)
        {
            player = _player;
            playerProperties = player.properties;
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
        public void SetSpline()
        {
            player.SetSpline();
        }
    }
}
