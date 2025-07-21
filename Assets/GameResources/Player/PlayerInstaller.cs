using Sorter.Signals;
using TMPro;
using UnityEngine;
using Zenject;

namespace Sorter.Player
{
    internal class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private TMP_Text score;
        [SerializeField] private TMP_Text life;
        [SerializeField] private Animator endScreen;

        public override void InstallBindings()
        {
            Container.Bind<PlayerData>()
                .AsSingle()
                .NonLazy();

            BindSignals();
        }

        private void Awake()
        {
            Subscribe();
        }

        private void BindSignals()
        {
            Container.BindSignal<DropSignal>()
                .ToMethod<PlayerData>((pd, signal) => pd.AddScore(1))
                .FromResolve();

            Container.BindSignal<EndOfBeltSignal>()
                .ToMethod<PlayerData>((pd, signal) => pd.Damage(1))
                .FromResolve();
        }

        private void Subscribe()
        {
            var data = Container.Resolve<PlayerData>();
            data.Score.OnChanged += (score) =>
            {
                if (this.score != null)
                {
                    this.score.text = score.ToString();
                }
            };
            if (this.score != null)
            {
                this.score.text = data.Score.ToString();
            }

            data.Health.OnChanged += (health) =>
            {
                if (this.life != null)
                {
                    this.life.text = health.ToString();
                }
            };
            if (this.life != null)
            {
                this.life.text = data.Health.ToString();
            }
        }
    }
}
