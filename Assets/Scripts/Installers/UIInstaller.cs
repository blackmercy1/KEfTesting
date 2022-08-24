using MainPlayer.PlayerSettings;
using UnityEngine;

namespace Installers
{
    public class UIInstaller : MonoBehaviour
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private StatisticsView _statisticsView;
        [SerializeField] private PlayerSettingsConfig _playerSettingsConfig;
        [SerializeField] private EndGameView _endGameView;
        
        private Statistics _statistics;
        
        public void Initialize(Statistics statistics)
        {
            _statisticsView.Initialize(statistics, _playerSettingsConfig);
        }

        public UI Install(Score score, Camera camera)
        {
            return CreateUI(score, camera);
        }

        private UI CreateUI(Score score, Camera camera)
        {
            var canvas = Instantiate(_canvas);

            var endGameView = Instantiate(_endGameView, canvas.transform);
            endGameView.gameObject.SetActive(false);

            var ui = new UI(canvas, endGameView, camera);
            return ui;
        }
    }
}