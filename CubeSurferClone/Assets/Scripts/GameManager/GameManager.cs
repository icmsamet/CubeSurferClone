using System.Collections;
using System.Collections.Generic;
using Dreamteck.Splines;
using UnityEngine;
using TMPro;

namespace GameManager
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance { get; private set; }
        [Header("Components")]
        [SerializeField] Player.Player player;
        [SerializeField] int score;
        [SerializeField] int levelID;
        public bool hasStarted = false; 
        [Header("----------")]
        [SerializeField] TextMeshProUGUI scoreText;
        [SerializeField] GameObject startPanel;
        [SerializeField] GameObject failPanel;
        [SerializeField] GameObject winPanel;
        /************/
        GameManagerPlayer managerPlayer;
        GameManagerScore managerScore;
        GameManagerLevelSpawner levelLoader;
        private void Awake()
        {
            if (!instance)
                instance = this;
        }
        private void Start()
        {
            managerPlayer = new GameManagerPlayer(player.properties);
            managerPlayer.StopGame();
            managerScore = new GameManagerScore(score, scoreText);
            managerScore.StartScore();
            StartPanelState(true);
            FailPanelState(false);
            levelLoader = new GameManagerLevelSpawner();
            //levelLoader.SpawnLevel(levelID);
        }

        public void StartGame()
        {
            StartPanelState(false);
            managerPlayer.StartGame();
            hasStarted = true;
        }
        public void WinGame()
        {
            WinPanelState(true);
            managerPlayer.StopGame();
        }
        public void FailGame()
        {
            FailPanelState(true);
            managerPlayer.StopGame();
        }
        public void StartPanelState(bool state)
        {
            startPanel.SetActive(state);
        }
        public void WinPanelState(bool state)
        {
            winPanel.SetActive(state);
        }
        public void FailPanelState(bool state)
        {
            failPanel.SetActive(state);
        }
        public bool CheckStart()
        {
            return hasStarted;
        }
    }
}
