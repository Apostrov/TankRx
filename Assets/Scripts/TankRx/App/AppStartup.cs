using UnityEngine;

namespace TankRx.App
{
    public class AppStartup : MonoBehaviour
    {
        private bool _loadStarted = false;

        private void LoadGame()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        }

        void Start()
        {
            _loadStarted = false;
            InitCallback();
        }

        private void InitCallback()
        {
            if (_loadStarted)
                return;

#if UNITY_EDITOR
            LoadGame();
#else
            Invoke(nameof(LoadGame), 0.89f);
#endif

            _loadStarted = true;
        }
    }
}