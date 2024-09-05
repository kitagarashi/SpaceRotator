using UnityEngine;
using DG.Tweening;

namespace _Project.Gameplay
{
    public sealed class Rotator : MonoBehaviour
    {
        [SerializeField] private float _rotateTime = 1.5f;

        private void Start()
        {
            transform
                .DORotate(new Vector3(0, 0, 360), _rotateTime, RotateMode.FastBeyond360)
                .SetLoops(-1, LoopType.Restart)
                .SetEase(Ease.Linear);
        }
    }
}
