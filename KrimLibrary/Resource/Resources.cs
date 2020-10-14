using KrimLibrary.Core.Objects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Media.Imaging;

namespace KrimLibrary.Resource
{
    public static class Resources
    {
        private static Dictionary<TileType, BitmapSource> LoadedResources = new Dictionary<TileType, BitmapSource>();

        public static BitmapSource LoadTile(TileType tileType)
        {
            if (LoadedResources.ContainsKey(tileType))
                return LoadedResources[tileType];

            string path = $"images/{Enum.GetName(typeof(TileType), tileType)}.jpg";
            if (ExistsFile(path))
            {
                LoadedResources.Add(tileType, LoadImage(path));
                return LoadedResources[tileType];
            }
            return null;
        }

        public static void ClearСache()
        {
            LoadedResources.Clear();
        }

        private static BitmapSource LoadImage(string path)
        {
            return new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + path, UriKind.Absolute));
        }

        private static bool ExistsFile(string path)
        {
            return File.Exists(AppDomain.CurrentDomain.BaseDirectory + path);
        }
    }
}
