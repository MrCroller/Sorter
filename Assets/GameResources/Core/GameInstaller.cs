using Sorter.Signals;
using Zenject;

namespace Sorter
{
    internal class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<GameState>()
                     .AsSingle()
                     .NonLazy();

            SignalBusInstaller.Install(Container);
            BindSignals();

            Container.BindInterfacesTo<Spawner>().AsSingle();
        }

        public void BindSignals()
        {
            Container.DeclareSignal<IClearSignal>();
            Container.DeclareSignal<IEndGame>();
            Container.DeclareSignal<DropSignal>();
            Container.DeclareSignal<ClearSignal>();
            Container.DeclareSignal<DragSignal>();
            Container.DeclareSignal<LoseGame>();
            Container.DeclareSignal<WinGame>();
            Container.DeclareSignal<EndOfBeltSignal>();
        }
    }
}
