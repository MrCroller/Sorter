using Sorter;
using UnityEngine;
using Zenject;

namespace Assets.GameResources.Helpers
{
    internal class GameStartHandler : MonoBehaviour
    {
        [Inject] private IChangeGameState gameState;

        public void GameStart()
        {
            gameState.ChangeState(GameState.State.Play);
        }
    }
}
