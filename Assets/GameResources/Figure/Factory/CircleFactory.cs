namespace Sorter.Figure
{
    public class CircleFactory : BaseFactory
    {
        protected override FigureType Type { get => FigureType.Circle;}

        public CircleFactory(Setting setting, Spawner.Settings spawnSetting, MonoPool<FigureView> pool) : base(setting, spawnSetting, pool)
        {

        }
    }
}
