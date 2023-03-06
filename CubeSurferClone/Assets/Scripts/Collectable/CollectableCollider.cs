using DG.Tweening;
using UnityEngine;

namespace Collectable
{
    public class CollectableCollider
    {
        Collectable collectable;

        public CollectableCollider(Collectable _collectable)
        {
            collectable = _collectable;
        }

        public void CollisionEnter(Collision collision)
        {
            var player = collision.gameObject.GetComponent<Player.Player>();
            if (player && !collectable.isCollected)
            {
                collectable.gameObject.tag = "Collected";
                collectable.isCollected = true;
                player.ChildAddLocalPos(new Vector3(0, 1.1f, 0));
                collectable.transform.SetParent(player.properties.cubeHolder);
                collectable.transform.localPosition = Vector3.zero;
                for (int i = 0; i < player.properties.cubeHolder.transform.childCount; i++)
                {
                    var currentObj = player.properties.cubeHolder.transform.GetChild(i).gameObject;
                    currentObj.transform.DOLocalMoveY(currentObj.transform.localPosition.y + 1.1f, .2f).SetEase(Ease.InOutCubic);
                }
                Player.Player.instance.SetTrailColor(collectable.color);
            }
        }
    }
}