using Sorter.Conveyor;
using Sorter.Signals;
using UnityEngine;
using Zenject;

namespace Sorter.Figure
{
    internal class FigureInstaller : MonoInstaller
    {
        [SerializeField] private SpawnPointView[] spawnPoints;
        [SerializeField] private FigureView figurePrefab;
        [SerializeField] private Transform figureParent;


        public override void InstallBindings()
        {
            Container.BindInterfacesTo<Spawner>().AsSingle();
            BinFactories();
            BindMemoryPool();
            BindSignals();
        }

        private void BinFactories()
        {
            Container.BindInterfacesAndSelfTo<StarFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<TriangleFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<CircleFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<SquareFactory>().AsSingle();
        }

        private void BindMemoryPool()
        {
            Container.BindInterfacesAndSelfTo<MonoPool<FigureView>>()
                .AsSingle()
                .WithArguments(figurePrefab, 30, figureParent);
        }

        private void BindSignals()
        {
            Container.BindSignal<EndLineSignal>()
                .ToMethod(signal => Container.Resolve<MonoPool<FigureView>>().Return(signal.view));

            Container.BindSignal<DropSignal>()
                .ToMethod(signal => Container.Resolve<MonoPool<FigureView>>().Return(signal.view));
        }
    }
}
