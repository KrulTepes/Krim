using KrimLibrary.Core;
using KrimLibrary.Resource;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;

namespace KrimWPF.Models
{
    class ImageManager
    {
        private List<TileType> oldTileTypesList;
        private System.Drawing.Point OldPositionPlayer;
        
        public ObservableCollection<Image> UpdateCollection(ObservableCollection<Image> collection, List<Tile> tiles, int playerPosX = -1, int playerPosY = -1, int fieldWidth = -1)
        {
            bool isFirst = false;
            if (collection == null)
            {
                OldPositionPlayer = new System.Drawing.Point(playerPosX, playerPosY);
                collection = new ObservableCollection<Image>();
                isFirst = true;
            }

            for (int i = 0; i < tiles.Count; i++)
            {
                if (isFirst)
                {
                    Image image = new Image() {
                        Source = Resources.LoadTile(tiles[i].TileType)
                    };

                    collection.Add(image);
                }
                else if (tiles[i].TileType != oldTileTypesList[i])
                {
                    Image image = new Image() {
                        Source = Resources.LoadTile(tiles[i].TileType)
                    };

                    collection[i] = image;
                }
            }

            // set player 
            if (fieldWidth >= 0 && playerPosY >= 0 && playerPosX >= 0 &&
                playerPosY * fieldWidth + playerPosX < collection.Count)
            {
                // замена старого тайла плеера
                if (OldPositionPlayer.X >= 0 && OldPositionPlayer.Y >= 0)
                {
                    Image tempImage = new Image()
                    {
                        Source = Resources.LoadTile(tiles[OldPositionPlayer.Y * fieldWidth + OldPositionPlayer.X].TileType)
                    };

                    collection[OldPositionPlayer.Y * fieldWidth + OldPositionPlayer.X] = tempImage;
                }

                Image image = new Image()
                {
                    Source = Resources.LoadTile(TileType.Player)
                };

                collection[playerPosY * fieldWidth + playerPosX] = image;

                OldPositionPlayer = new System.Drawing.Point(playerPosX, playerPosY);
            }

            oldTileTypesList = tiles.Select(tile => tile.TileType).ToList();

            return collection;
        }
    }
}
