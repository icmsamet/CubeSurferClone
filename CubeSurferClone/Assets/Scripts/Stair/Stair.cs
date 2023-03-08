using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Stair
{
    [RequireComponent(typeof(Rigidbody))]
    public class Stair : MonoBehaviour
    {
        StairRigidbody stairRigidbody;
        StairCollider stairCollider;
        StairColor stairColor;


        [OnValueChanged("SetColor")]
        public Color color = Color.white;
        MeshRenderer meshRenderer;

        private void Start()
        {
            stairCollider = new StairCollider();
            stairRigidbody = new StairRigidbody(GetComponent<Rigidbody>());
            stairRigidbody.SetConstains(RigidbodyConstraints.FreezeAll);
            stairRigidbody.SetGravity(false);
            SetColor();
        }
        public void SetColor()
        {
            meshRenderer = GetComponent<MeshRenderer>();
            stairColor = new StairColor(meshRenderer);
            stairColor.SetColor(color);
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (GameManager.GameManager.instance.CheckStart())
                stairCollider.CollisionEnter(collision);
        }
    }
}
