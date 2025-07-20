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
        }

        public void BindSignals()
        {
            Container.DeclareSignal<DropSignal>();
            Container.DeclareSignal<EndLineSignal>();
            Container.DeclareSignal<DragSignal>();
        }
    }
}
