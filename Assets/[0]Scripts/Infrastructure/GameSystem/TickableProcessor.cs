using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace Game.Infrastructure.GameSystem
{
    public sealed class TickableProcessor : MonoBehaviour, IGameStartListener, IGameFinishListener, IGamePauseListener
    {
        private readonly List<ITickable> _tickables = new();

        private readonly List<ITickable> _removeTickables = new();

        private readonly List<ITickable> _addNewTickables = new();


        private bool _isGameActive;


        public void AddTickable(ITickable tickable)
        {
            if (tickable == null) return;

            _addNewTickables.Add(tickable);
        }

        public void RemoveTickable(ITickable tickable)
        {
            if (tickable == null) return;

            _removeTickables.Add(tickable);
        }


        private void Update()
        {
            HandleAddingTickables();
            HandleRemovingTickables();

            if (!_isGameActive) return;
            HandleTick();
        }

        private void HandleAddingTickables()
        {
            if (_addNewTickables.Count <= 0) return;
            _tickables.AddRange(_addNewTickables);
            _addNewTickables.Clear();
        }

        private void HandleRemovingTickables()
        {
            if (_removeTickables.Count <= 0) return;
            foreach (var remove in _removeTickables)
            {
                _tickables.Remove(remove);
            }

            _removeTickables.Clear();
        }

        private void HandleTick()
        {
            var deltaTime = Time.deltaTime;
            foreach (var tick in _tickables.Where(tick => tick != null))
            {
                tick.Tick(deltaTime);
            }
        }


        public void OnGameStart()
        {
            _isGameActive = true;
        }

        public void OnGameFinish()
        {
            _isGameActive = false;
        }

        public void OnGamePause()
        {
            _isGameActive = false;
        }

        public void OnGameResume()
        {
            _isGameActive = true;
        }
    }
}
