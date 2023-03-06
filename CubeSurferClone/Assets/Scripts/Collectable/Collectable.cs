using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Collectable
{
    public class Collectable : MonoBehaviour
    {
        CollectableCollider collider;

        [OnValueChanged("SetColor")]
        public Color color = Color.white;
        public bool isCollected = false;
        MeshRenderer meshRenderer;

        private void Start()
        {
            collider = new CollectableCollider(this);
        }
        public void SetColor()
        {
            meshRenderer = GetComponent<MeshRenderer>();

            var tempMaterial = new Material(meshRenderer.sharedMaterial);
            tempMaterial.color = color;
            meshRenderer.sharedMaterial = tempMaterial;
        }
        private void OnCollisionEnter(Collision collision)
        {
            collider.CollisionEnter(collision);
        }
        public void CheckSelf()
        {
            RaycastHit hit;
            // Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 1))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.yellow);
            }
            else
            {
                transform.DOLocalMoveY(transform.localPosition.y - 1.1f, .2f).SetEase(Ease.InOutCubic).OnComplete(() =>
                {
                    Player.Player.instance.CheckAllCollectable();
                });
            }
        }
    }
}
