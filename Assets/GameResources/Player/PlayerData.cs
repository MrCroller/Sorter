using System;
using Sorter.Signals;
using Sorter.Types;
using UnityEngine;
using Zenject;

namespace Sorter.Player
{
    internal class PlayerData
    {
        public IReadOnlyReactiveProperty<int> Health => health;
        public IReadOnlyReactiveProperty<int> Score => score;

        private readonly ReactiveProperty<int> health;
        private readonly ReactiveProperty<int> score;
        private readonly int scoreToWin;

        private readonly SignalBus signalBus;

        public PlayerData(Settings settings, SignalBus signalBus)
        {
            health = new(settings.BaseHealth);
            score = new(0);
            this.signalBus = signalBus;

            scoreToWin = settings.ScoreToWin.GetRandom();
        }

        public void Damage(int amount)
        {
            health.SetValue(health - amount);
            if (health < 1)
            {
                signalBus.AbstractFire(new LoseGame());
            }
        }

        public void AddScore(int amount)
        {
            score.SetValue(score + amount);
            if (score >= scoreToWin)
            {
                signalBus.AbstractFire(new WinGame());
            }
        }


        [Serializable]
        public class Settings
        {
            [field: SerializeField] public int BaseHealth { get; private set; } = 100;
            [field: SerializeField] public Range<int> ScoreToWin { get; private set; } = new() { min = 50, max = 100 };
        }
    }
}
