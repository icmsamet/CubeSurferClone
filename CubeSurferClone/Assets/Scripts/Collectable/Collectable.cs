using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Collectable
{
    public class Collectable : MonoBehaviour
    {
        CollectableCollider collectableCollider;
        CollectableColor collectableColor;

        [OnValueChanged("SetColor")]
        public Color color = Color.white;
        public bool isCollected = false;
        MeshRenderer meshRenderer;

        private void Start()
        {
            collectableCollider = new CollectableCollider(this);
            SetColor();
        }
        public void SetColor()
        {
            meshRenderer = GetComponent<MeshRenderer>();
            collectableColor = new CollectableColor(meshRenderer);
            collectableColor.SetColor(color);
        }
        private void OnCollisionEnter(Collision collision)
        {
            collectableCollider.CollisionEnter(collision);
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
