using Sorter.Figure;
using Sorter.Types;
using UnityEngine;
using Zenject;

namespace Sorter
{
    [CreateAssetMenu(fileName = "GameSetting", menuName = "Scriptable Objects/GameSetting")]
    public partial class GameSetting : ScriptableObjectInstaller
    {
        [Header("Base")]
        [SerializeField] private Range<int> figureCount = new() { min = 50, max = 100 };
        [SerializeField] private int healthCount = 100;
        [Header("Spawn")]
        [SerializeField] private Spawner.Settings spawner;
        [SerializeField] private StarFactory.Setting starFactory;
        [SerializeField] private CircleFactory.Setting circleFactory;
        [SerializeField] private TriangleFactory.Setting triFactory;
        [SerializeField] private SquareFactory.Setting squareFactory;

        public override void InstallBindings()
        {
            Container.BindInstances(spawner);
            BindFactories();
        }

        private void BindFactories()
        {
            Container.BindInstance(starFactory).WhenInjectedInto<StarFactory>();
            Container.BindInstance(circleFactory).WhenInjectedInto<CircleFactory>();
            Container.BindInstance(triFactory).WhenInjectedInto<TriangleFactory>();
            Container.BindInstance(squareFactory).WhenInjectedInto<SquareFactory>();
        }

        private void OnValidate()
        {
            spawner.Validate();
        }
    }
}
