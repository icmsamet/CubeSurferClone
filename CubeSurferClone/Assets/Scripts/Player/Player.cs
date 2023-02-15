using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    [System.Serializable]
    public class Properties
    {
        public Transform childModel;
        public float speed;
    }
    public class Player : MonoBehaviour
    {
        [SerializeField] Properties properties;
        [SerializeField] DynamicJoystick dynamicJoystick;
        PlayerMovement playerMovement;
        PlayerMovementInput playerMovementInput;

        private void Start()
        {
            playerMovementInput = new PlayerMovementInput(dynamicJoystick);
            playerMovement = new PlayerMovement(properties.speed, properties.childModel.transform, playerMovementInput);
        }
        private void FixedUpdate()
        {
            playerMovement.Move();
        }
    }
}
