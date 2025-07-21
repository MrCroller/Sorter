using Sorter.Signals;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Sorter
{
    internal class GameStateHandler : MonoBehaviour
    {
        [SerializeField] private UnityEvent unityEvent;
        private SignalBus signalBus;
        private IChangeGameState state;

        [Inject]
        public void Construct(SignalBus signalBus, IChangeGameState state)
        {
            this.signalBus = signalBus;
            this.state = state;
        }

        private void Start()
        {
            signalBus.Subscribe<IEndGame>(OnGameStateChanged);
        }

        private void OnGameStateChanged()
        {
            if (state.CurrentState != GameState.State.Play) return;
            state.ChangeState(GameState.State.Menu);
            unityEvent.Invoke();
        }
    }
}
