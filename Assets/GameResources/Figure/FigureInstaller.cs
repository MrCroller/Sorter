using Sorter;
using Sorter.Figure;
using Sorter.Figure.View;
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
            Container.Bind<MonoPool<FigureView>>()
                .AsSingle()
                .WithArguments(figurePrefab, 30, figureParent);
        }
    }
}
