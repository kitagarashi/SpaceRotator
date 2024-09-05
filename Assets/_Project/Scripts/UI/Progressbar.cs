using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;
using System;

namespace _Project.UI
{
    public sealed class Progressbar : MonoBehaviour
    {
        [SerializeField, Range(0, 100)] private float _maxValue = 100f;

        [Header("animation")]
        [SerializeField, Range(0, 10)] private float _fillTime = 0.5f;
        [SerializeField] private Ease _fillEase = Ease.InQuad;
        [SerializeField] private Gradient _fillGradient;

        [Space(10)]
        [SerializeField] private Image _bar;

        public float CurrentValue { get; private set; }

        public Action OnComplete;
        public Action<float> OnValueChanged;

        public void UpdateAmount(float amount)
        {
            CurrentValue += amount;
            CurrentValue = Mathf.Clamp(CurrentValue, 0, _maxValue);
            OnValueChanged?.Invoke(CurrentValue);

            if (CurrentValue >= _maxValue)
            {
                CurrentValue = _maxValue;
                ResetProgress();

                OnComplete?.Invoke();
            }

            UpdateView();
        }

        private void UpdateView()
        {
            float targetFillAmount = CurrentValue / _maxValue;

            _bar
                .DOFillAmount(targetFillAmount, _fillTime)
                .SetEase(_fillEase);

            _bar.DOColor(_fillGradient.Evaluate(targetFillAmount), _fillTime);
        }

        private void ResetProgress()
        {
            CurrentValue = 0;
            UpdateView();
        }
    }
}
