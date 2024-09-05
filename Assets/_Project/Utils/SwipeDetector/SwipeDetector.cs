using UnityEngine.Events;
using UnityEngine;

namespace _Project.Utils
{
    public sealed class SwipeDetector : MonoBehaviour
    {
        [SerializeField] private bool detectSwipeAfterRelease = true;
        [SerializeField, Range(0, 100)] private float _minSwipeDistance = 20f;

        [Space(10)]
        [Header("events:")]
        public UnityEvent onSwipeUp;
        public UnityEvent onSwipeDown;
        public UnityEvent onSwipeLeft;
        public UnityEvent onSwipeRight;

        private Vector2 _swipeDownPosition;
        private Vector2 _swipeUpPossition;

        private void Update()
        {
            foreach (var touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    _swipeUpPossition = touch.position;
                    _swipeDownPosition = touch.position;
                }

                if (touch.phase == TouchPhase.Moved)
                {
                    if (!detectSwipeAfterRelease)
                    {
                        _swipeDownPosition = touch.position;
                        DetectSwipe();
                    }
                }

                if (touch.phase == TouchPhase.Ended)
                {
                    _swipeDownPosition = touch.position;
                    DetectSwipe();
                }
            }
        }

        void DetectSwipe()
        {
            var verticalMove = VerticalMoveValue();
            var horizontalMove = HorizontalMoveValue();

            if (verticalMove > _minSwipeDistance && verticalMove > horizontalMove)
            {
                if (_swipeDownPosition.y - _swipeUpPossition.y > 0)
                {
                    onSwipeUp?.Invoke();
                }
                else if (_swipeDownPosition.y - _swipeUpPossition.y < 0)
                {
                    onSwipeDown?.Invoke();
                }
                _swipeUpPossition = _swipeDownPosition;
            }
            else if (horizontalMove > _minSwipeDistance && horizontalMove > verticalMove)
            {
                if (_swipeDownPosition.x - _swipeUpPossition.x > 0)
                {
                    onSwipeRight?.Invoke();
                }
                else if (_swipeDownPosition.x - _swipeUpPossition.x < 0)
                {
                    onSwipeLeft?.Invoke();
                }
                _swipeUpPossition = _swipeDownPosition;
            }
        }

        float VerticalMoveValue()
        {
            return Mathf.Abs(_swipeDownPosition.y - _swipeUpPossition.y);
        }

        float HorizontalMoveValue()
        {
            return Mathf.Abs(_swipeDownPosition.x - _swipeUpPossition.x);
        }
    }
}
