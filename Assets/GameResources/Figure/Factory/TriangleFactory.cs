namespace Sorter.Figure
{
    internal class TriangleFactory : BaseFactory
    {
        protected override FigureType Type => FigureType.Triangle;

        public TriangleFactory(Setting setting, Spawner.Settings spawnSetting, MonoPool<FigureView> pool) : base(setting, spawnSetting, pool)
        {

        }
    }
}
