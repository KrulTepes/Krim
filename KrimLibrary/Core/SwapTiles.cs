using KrimLibrary.Core.Objects;
using System.Collections.Generic;

namespace KrimLibrary.Core
{
    public static class SwapTiles
    {
        public static List<Tile> tiles;

        public static void Swap(Tile tileFirst, Tile tileSecond)
        {
            Tile temp = tiles.Find(tile => tile.Equals(tileFirst));
            int indexSecond = tiles.FindIndex(tile => tile.Equals(tileSecond));
            tiles[tiles.FindIndex(tile => tile.Equals(tileFirst))] = tiles.Find(tile => tile.Equals(tileSecond));
            tiles[indexSecond] = temp;
        }
    }
}
