using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Media;

namespace KrimLibrary.Core
{
    public class Map
    {
        public List<List<char>> CellList { get; set; }

        public int Height { get; set; }
        public int Width { get; set; }

        public Map(string path)
        {
            Load(path);
        }

        private void Load(string path)
        {
            bool isFirstLine = true;
            try
            {
                using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
                {
                    string line = string.Empty;
                    if (isFirstLine)
                    {
                        if ((line = sr.ReadLine()) != null)
                        {
                            Height = int.Parse(line.Split(' ')[0]);
                            Width = int.Parse(line.Split(' ')[1]);
                            CellList = new List<List<char>>(Height);
                            for (int i = 0; i < Height; i++)
                            {
                                CellList.Add(new List<char>(Width));
                            }
                        }
                        isFirstLine = false;
                    }

                    for (int h = 0; h < Height; h++)
                    {
                        line = sr.ReadLine();
                        int w = 0;
                        while (w < line.Length)
                        {
                            if (line[w] != ' ')
                            {
                                CellList[h].Add(line[w]);
                            }
                            w++;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Clear();
                Logger.Log($"Exception: произошла ошибка при загрузке map - {e.Message}");
                return;
            }
        }

        private void Clear()
        {
            Height = 0;
            Width = 0;
            CellList = null;
        }
    }
}
