using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;


namespace Default
{
    internal sealed class AnimatedMover : MonoBehaviour
    {
        [SerializeField] Transform[] points;
        [SerializeField] private float timeBetweenPoints;


        internal void Move(Transform item, TweenCallback callBack)
        {
            var seq = DOTween.Sequence(this).SetUpdate(true);
            foreach (var point in points)
            {
                seq.Append(item.DOMove(point.position, timeBetweenPoints));
            }

            seq.AppendCallback(callBack);
        }

        private void OnDestroy()
        {
            DOTween.KillAll(this);
        }
    }
}
