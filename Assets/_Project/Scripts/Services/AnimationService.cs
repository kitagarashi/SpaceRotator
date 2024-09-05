using UnityEngine;
using DG.Tweening;

namespace _Project.Services
{
    public sealed class AnimationService : Singleton<AnimationService>
    {
        [SerializeField] private Vector2 _size = new Vector2(0.9f, 0.9f);
        [SerializeField, Range(0, 10)] private float _duration = 0.2f;

        [Header("camera shake:")]
        [SerializeField, Range(0, 10)] private float _shakeDuration = 0.2f;
        [SerializeField, Range(0, 10)] private float _shakeStrength = 0.5f;

        private Camera _camera;

        protected override void Awake()
        {
            _camera = Camera.main;
            base.Awake();
        }

        public void PlayAnimation(GameObject @object, TweenCallback callback)
        {
            if (!DOTween.IsTweening(@object))
            {
                var startSize = @object.transform.localScale;

                DOTween.Sequence()
                    .Append(@object.transform.DOScale(startSize * _size, _duration))
                    .Append(@object.transform.DOScale(startSize, _duration))
                    .AppendCallback(callback);
            }
        }

        public void ShakeCamera()
        {
            _camera.DOShakePosition(_shakeDuration, _shakeStrength);
        }
    }
}
