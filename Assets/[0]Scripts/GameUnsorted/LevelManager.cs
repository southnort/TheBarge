using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Yrr.Utils;


namespace Default
{
    internal sealed class LevelManager : MonoBehaviour
    {
        [SerializeField] private int missionCounter;

        internal static LevelManager Instance
        {
            get
            {
                if (!_instance)
                    _instance = GameObject.FindObjectOfType<LevelManager>();

                return _instance;
            }
        }

        private static LevelManager _instance;


        private void Awake()
        {
            _instance = this;


            CurrentCounterMission = new ReactiveInt(0);
            CurrentCounterMissionMax = new ReactiveInt(missionCounter);

            CurrentCounterMission.OnChange += AutoSave;

            CurrentCounterMission.Value = PlayerData.CurrentData.CurrentMissionCounter;
        }

        private void OnDestroy()
        {
            CurrentCounterMissionMax.OnChange -= AutoSave;
        }

        private void AutoSave(int value)
        {
            PlayerData.CurrentData.CurrentMissionCounter = value;
            PlayerData.CurrentData.SaveData();

        }

        private void OnDisable()
        {
            PlayerData.CurrentData.SaveData();
        }


        public ReactiveInt CurrentCounterMission;
        public ReactiveInt CurrentCounterMissionMax;
    }
}
