using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;


namespace Player
{
    public class PlayerChildTransform
    {
        public Transform childTransform;
        public PlayerChildTransform(Transform _childTransform)
        {
            childTransform = _childTransform;
        }
        public void AddLocalPosition(Vector3 addPos)
        {
            var currentPos = childTransform.transform.localPosition;
            childTransform.transform.DOLocalMove(currentPos + addPos, .2f).SetEase(Ease.InOutCubic);
        }
        public void AddLocalPosition(Vector3 addPos, UnityAction action)
        {
            var currentPos = childTransform.transform.localPosition;
            childTransform.transform.DOLocalMove(currentPos + addPos, .2f).SetEase(Ease.InOutCubic).OnComplete(() =>
            {
                action.Invoke();
            });
        }
        public void SetLocalPosition()
        {
            var currentPos = childTransform.transform.localPosition;
            float newY = Mathf.Round(currentPos.y / 1.1f) * 1.1f;
            childTransform.transform.localPosition = currentPos;
        }
    }
}
