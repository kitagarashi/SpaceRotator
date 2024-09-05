using UnityEngine;

namespace _Project.Screens
{
    public class GameScreen : BaseScreen
    {
        [SerializeField] private GameObject _gameplay;

        private void Awake()
        {
            _gameplay.SetActive(true);
        }
    }
}
