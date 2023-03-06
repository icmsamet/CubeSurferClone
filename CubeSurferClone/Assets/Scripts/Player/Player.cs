using System.Collections;
using System.Collections.Generic;
using Dreamteck.Splines;
using UnityEngine;

namespace Player
{
    public class Player : MonoBehaviour
    {
        public static Player instance { get; private set; }
        public PlayerProperties properties = new PlayerProperties();
        PlayerMovement playerMovement;
        PlayerMovementInput playerMovementInput;
        PlayerCollider playerCollider;
        PlayerChildTransform playerChild;
        PlayerCubeHolder playerCube;
        PlayerChildRaycast playerChildRaycast;
        PlayerTrail playerTrail;
        private void Awake()
        {
            if (!instance)
                instance = this;
        }
        private void Start()
        {
            playerMovementInput = new PlayerMovementInput(properties.dynamicJoystick);
            playerMovement = new PlayerMovement(properties.moveSpeed, properties.moveObject.transform, playerMovementInput);
            playerCollider = new PlayerCollider(properties);
            playerChild = new PlayerChildTransform(properties.childModel.transform);
            playerCube = new PlayerCubeHolder(properties);
            playerChildRaycast = new PlayerChildRaycast(playerChild);
            playerTrail = new PlayerTrail(properties.trailRenderer);
            playerTrail.SetColor(properties.childModel.GetComponent<MeshRenderer>().material.color);
        }
        private void FixedUpdate()
        {
            playerMovement.Move();
        }
        private void OnCollisionEnter(Collision collision)
        {
            StartCoroutine(playerCollider.CollisionEnter(collision));
        }
        public void ChildAddLocalPos(Vector3 addPos)
        {
            playerChild.AddLocalPosition(addPos);
        }
        public void CheckAllCollectable()
        {
            playerCube.CheckAll();
            playerChildRaycast.CheckSelf();
        }
        public void SetTrailColor(Color color)
        {
            playerTrail.SetColor(color);
        }
    }
}
