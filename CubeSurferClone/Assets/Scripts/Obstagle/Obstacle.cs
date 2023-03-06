using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Obstacle
{
    [RequireComponent(typeof(Rigidbody))]
    public class Obstacle : MonoBehaviour
    {
        ObstacleRigidbody rigidbody;
        ObstacleCollider collider;

        [SerializeField] GameObject m_SingeObs;
        [SerializeField] GameObject m_TwinObs;
        public GameObject activeObs;
        [OnValueChanged("ChangeObs")] public ObstacleType type;
        MeshRenderer[] meshRenderer;
        [OnValueChanged("SetColor")]
        public Color color = Color.white;

        private void Start()
        {
            collider = new ObstacleCollider();
            rigidbody = new ObstacleRigidbody(GetComponent<Rigidbody>());
            rigidbody.SetConstains(RigidbodyConstraints.FreezeAll);
            rigidbody.SetGravity(false);
        }
        public void ChangeObs()
        {
            switch (type)
            {
                case ObstacleType.Singe:
                    m_SingeObs.SetActive(true);
                    m_TwinObs.SetActive(false);
                    activeObs = m_SingeObs;
                    SetColor();
                    break;
                case ObstacleType.Twin:
                    m_SingeObs.SetActive(false);
                    m_TwinObs.SetActive(true);
                    activeObs = m_TwinObs.transform.GetChild(0).gameObject;
                    SetColor();
                    break;
            }
        }
        public void SetColor()
        {
            meshRenderer = GetComponentsInChildren<MeshRenderer>();

            foreach (var item in meshRenderer)
            {
                var tempMaterial = new Material(item.sharedMaterial);
                tempMaterial.color = color;
                item.sharedMaterial = tempMaterial;
            }
        }
        private void OnCollisionEnter(Collision collision)
        {
            collider.CollisionEnter(collision);
        }
    }
}
