using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    [System.Serializable]
    public class Properties
    {
        public DynamicJoystick dynamicJoystick;
        public Transform childModel;
        public Transform cubeHolder;
        public float speed;
    }
    public class Player : MonoBehaviour
    {
        [SerializeField] Properties properties;
        PlayerMovement playerMovement;
        PlayerMovementInput playerMovementInput;

        private void Start()
        {
            playerMovementInput = new PlayerMovementInput(properties.dynamicJoystick);
            playerMovement = new PlayerMovement(properties.speed, properties.childModel.transform, playerMovementInput);
        }
        private void FixedUpdate()
        {
            playerMovement.Move();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.tag == "Cube" && collision.gameObject.tag != "GotCube")
            {
                collision.gameObject.tag = "GotCube";
                properties.childModel.transform.localPosition += new Vector3(0, 1, 0);
                collision.transform.SetParent(properties.cubeHolder);
                collision.gameObject.transform.localPosition = Vector3.zero;
                for (int i = 0; i < properties.cubeHolder.transform.childCount; i++)
                {
                    properties.cubeHolder.transform.GetChild(i).gameObject.transform.localPosition += new Vector3(0, 1, 0);
                }
            }
            else if(collision.gameObject.tag == "Obstacle")
            {
                collision.gameObject.tag = "Untagged";
                Destroy(properties.cubeHolder.transform.GetChild(properties.cubeHolder.transform.childCount-1).gameObject);
                properties.childModel.transform.localPosition -= new Vector3(0, 1, 0);
                for (int i = 0; i < properties.cubeHolder.transform.childCount; i++)
                {
                    properties.cubeHolder.transform.GetChild(i).gameObject.transform.localPosition -= new Vector3(0, 1, 0);
                }
            }
        }
    }
}
