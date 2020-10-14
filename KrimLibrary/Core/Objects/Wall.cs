namespace KrimLibrary.Core.Objects
{
    public class Wall : Tile
    {
        public Wall(int x, int y)
        {
            Init(x, y, TileType.Wall);
        }
    }
}
