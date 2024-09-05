using UnityEngine;
using TMPro;

namespace _Project.Services
{
    [RequireComponent(typeof(TMP_Text))]
    public class ScoreService : Singleton<ScoreService>
    {
        private TMP_Text _score;
        private int _currentScore;

        protected override void Awake()
        {
            base.Awake();
            _score = GetComponent<TMP_Text>();
        }

        public void UpdateScore(int value)
        {
            _currentScore += value;
            _score.text = _currentScore.ToString();

            AnimationService.Instance.PlayAnimation(_score.gameObject, null);
        }
    }
}
