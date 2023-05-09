using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Yrr.UI;
using System;

namespace Default
{
    internal sealed class ScoresWindow : UIScreen
    {
        [SerializeField] private TextMeshProUGUI scoresText;


        private void Start()
        {
            UpdateCounter();

            LevelManager.Instance.CurrentCounterMission.OnChange += OnDataChanged;
        }

        private void OnDestroy()
        {
            if (LevelManager.Instance != null)
                LevelManager.Instance.CurrentCounterMission.OnChange -= OnDataChanged;
        }

        private void OnDataChanged(int obj)
        {
            UpdateCounter();
        }

        public void UpdateCounter()
        {
            scoresText.text =
                $"{LevelManager.Instance.CurrentCounterMission.Value}/{LevelManager.Instance.CurrentCounterMissionMax.Value}";
        }


    }
}
