using UnityEngine;

namespace GameManager
{
    [CreateAssetMenu(fileName = "New Game Setttings",menuName = "Game Setting")]
    public class GameSettings : ScriptableObject
    {
        public float playerMoveSpeed;
        public float playerFollowSpeed;
        public float collectableOffset;
    }
}
