using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public static class PieceSpawnConfigurations
    {
        public static List<string> Configurations;
        public static Dictionary<SpawnPosition, Vector2> Positions;

        public const char NonBlockSpace = 'X';
        public const char BlockSpace = 'O';

        static PieceSpawnConfigurations()
        {
            Configurations = new List<string>()
            {
                // Line
                "XOX" +
                "XOX" +
                "XOX",

                // Square
                "XXX" +
                "XOO" +
                "XOO",

                // T
                "OXX" +
                "OOX" +
                "OXX",

                // Z
                "XXX" +
                "OOX" +
                "XOO",

                // Flipped Z
                "XXX" +
                "XOO" +
                "OOX",
            };

            Positions = new Dictionary<SpawnPosition, Vector2>()
            {
                { SpawnPosition.TopLeft, new Vector2(
                    Config.SpawnBoxLocation.x - Config.SpawnBoxLength / 2, 
                    Config.SpawnBoxLocation.y + Config.SpawnBoxHeight / 2) },
                { SpawnPosition.TopCenter, new Vector2(
                    Config.SpawnBoxLocation.x,
                    Config.SpawnBoxLocation.y + Config.SpawnBoxHeight / 2) },
                { SpawnPosition.TopRight, new Vector2(
                    Config.SpawnBoxLocation.x + Config.SpawnBoxLength / 2,
                    Config.SpawnBoxLocation.y + Config.SpawnBoxHeight / 2) },
                { SpawnPosition.MiddleLeft, new Vector2(
                    Config.SpawnBoxLocation.x - Config.SpawnBoxLength / 2,
                    Config.SpawnBoxLocation.y) },
                { SpawnPosition.MiddleCenter, new Vector2(
                    Config.SpawnBoxLocation.x,
                    Config.SpawnBoxLocation.y) },
                { SpawnPosition.MiddleRight, new Vector2(
                    Config.SpawnBoxLocation.x + Config.SpawnBoxLength / 2,
                    Config.SpawnBoxLocation.y) },
                { SpawnPosition.BottomLeft, new Vector2(
                    Config.SpawnBoxLocation.x - Config.SpawnBoxLength / 2,
                    Config.SpawnBoxLocation.y - Config.SpawnBoxHeight / 2) },
                { SpawnPosition.BottomCenter, new Vector2(
                    Config.SpawnBoxLocation.x,
                    Config.SpawnBoxLocation.y - Config.SpawnBoxHeight / 2) },
                { SpawnPosition.BottomRight, new Vector2(
                    Config.SpawnBoxLocation.x + Config.SpawnBoxLength / 2,
                    Config.SpawnBoxLocation.y - Config.SpawnBoxHeight / 2) }
            };
        }
    }

    public enum SpawnPosition
    {
        TopLeft,
        TopCenter,
        TopRight,
        MiddleLeft,
        MiddleCenter,
        MiddleRight,
        BottomLeft,
        BottomCenter,
        BottomRight
    }
}
