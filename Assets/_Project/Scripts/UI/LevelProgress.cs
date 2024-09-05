using _Project.Services;
using UnityEngine;
using TMPro;

namespace _Project.UI
{
    public sealed class LevelProgress : MonoBehaviour
    {
        [SerializeField] private TMP_Text _levelCounter;
        [SerializeField] private Progressbar _progressBar;

        private void Start()
        {   
            UpdateUI();
        }

        private void OnEnable()
        {
            _progressBar.OnComplete += LevelUp;
        }

        private void OnDisable()
        {
            _progressBar.OnComplete -= LevelUp;
        }

        private void LevelUp()
        {
            SaveService.Level++;
            AnimationService.Instance.PlayAnimation(_progressBar.gameObject, null);
            AudioService.Instance.PlaySound("Score");
            UpdateUI();
        }

        private void UpdateUI()
        {
            _levelCounter.text = SaveService.Level.ToString();
        }
    }
}
