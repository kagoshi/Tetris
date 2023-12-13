using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Controllers
{
    internal class SaveContoller
    {
        private const string savePath = @"./save";
        private static FileStream fs;

        public static Dictionary<string, List<Dictionary<string, int>>> gameData = new Dictionary<string, List<Dictionary<string, int>>>();

        public static void AddUpdatePlayer(string mode, string playerName, int score)
        {
            var playerData = gameData[mode].FirstOrDefault(p => p.ContainsKey(playerName));

            if (playerData != null)
            {
                playerData[playerName] = score;
            }
            else
            {
                var newPlayer = new Dictionary<string, int> { { playerName, score } };
                gameData[mode].Add(newPlayer);
            }

            gameData[mode] = gameData[mode].OrderBy(player => player.First().Key).ToList();
        }

        public static void Load()
        {
            if (!File.Exists(savePath))
            {
                fs = new FileStream(savePath, FileMode.CreateNew);
                fs.Close();
                gameData["goose"] = new List<Dictionary<string, int>>();
                Save();
            }
            fs = new FileStream(savePath, FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();
            gameData = (Dictionary<string, List<Dictionary<string, int>>>)formatter.Deserialize(fs);
            fs.Close();
        }

        public static void Save()
        {
            fs = new FileStream(savePath, FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fs, gameData);
            fs.Close();
        }
    }
}