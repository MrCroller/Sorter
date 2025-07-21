using Sorter.Draggable;
using Sorter.Figure;
using Sorter.Player;
using UnityEngine;
using Zenject;

namespace Sorter
{
    [CreateAssetMenu(fileName = "GameSetting", menuName = "Scriptable Objects/GameSetting")]
    public partial class GameSetting : ScriptableObjectInstaller
    {
        [Header("Base")]
        [SerializeField] private PlayerData.Settings player;
        [Header("Spawn")]
        [SerializeField] private Spawner.Settings spawner;
        [SerializeField] private StarFactory.Setting starFactory;
        [SerializeField] private CircleFactory.Setting circleFactory;
        [SerializeField] private TriangleFactory.Setting triFactory;
        [SerializeField] private SquareFactory.Setting squareFactory;
        [Header("VFX")]
        [SerializeField] private DraggableObject.Setting draggableObject;

        public override void InstallBindings()
        {
            Container.BindInstance(spawner);
            Container.BindInstance(player);
            BindFactories();
            BindVFX();
        }

        private void BindFactories()
        {
            Container.BindInstance(starFactory).WhenInjectedInto<StarFactory>();
            Container.BindInstance(circleFactory).WhenInjectedInto<CircleFactory>();
            Container.BindInstance(triFactory).WhenInjectedInto<TriangleFactory>();
            Container.BindInstance(squareFactory).WhenInjectedInto<SquareFactory>();
        }

        private void BindVFX()
        {
            Container.BindInstance(draggableObject);
        }

        private void OnValidate()
        {
            spawner.Validate();
        }
    }
}
