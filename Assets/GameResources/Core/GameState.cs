using System;
using UnityEngine;

namespace Sorter
{
    public class GameState : IGameStateHandler, IChangeGameState
    {
        public enum State
        {
            Menu,
            Play,
            Pause,
            Load
        }

        public event Action<State> OnChangeState;

        public State CurrentState { get; private set; } = State.Menu;

        public void ChangeState(State state)
        {
            Debug.Log($"{nameof(GameState)}.Change GameState {CurrentState} => {state}");
            CurrentState = state;
            OnChangeState?.Invoke(CurrentState);
        }
    }

    public interface IGameStateHandler
    {
        event Action<GameState.State> OnChangeState;
        GameState.State CurrentState { get; }
    }

    public interface IChangeGameState
    {
        GameState.State CurrentState { get; }
        void ChangeState(GameState.State state);
    }
}
