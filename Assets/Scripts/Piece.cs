using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    using Object = UnityEngine.Object;

    /// <summary>
    /// A collection of Tiles that are placed based off a set configuration.
    /// </summary>
    public class Piece
    {
        public List<GameObject> Tiles = new List<GameObject>();
        public bool IsPlaced = false;

        public Piece(GameObject tile, string spawnConfig)
        {
            // Generate new tiles
            for (int i = 0; i < spawnConfig.Length; i++)
            {
                if (spawnConfig[i] == PieceSpawnConfigurations.BlockSpace)
                {
                    var newTile = Object.Instantiate(tile);

                    // Set tile positions based off i
                    newTile.transform.position = SetTilePosition(i);
                    Tiles.Add(newTile);
                }
            }

            // Destroy the copied prefab
            Object.Destroy(tile);
        }

        /// <summary>
        /// Rotates the piece 90d CW by setting the new tile positions accordingly.
        /// </summary>
        public void Rotate()
        {
            foreach (var tile in Tiles)
            {
                tile.transform.RotateAround(Tiles[0].transform.position, Vector3.forward, Config.ROTATION_SPEED * Time.deltaTime);
            }
        }

        public void StopRotation()
        {
            foreach (var tile in Tiles)
            {
                tile.transform.Rotate(0, 0, 0);
            }
        }

        private Vector2 SetTilePosition(int i)
            => i switch
            {
                0 => PieceSpawnConfigurations.Positions[SpawnPosition.TopLeft],
                1 => PieceSpawnConfigurations.Positions[SpawnPosition.TopCenter],
                2 => PieceSpawnConfigurations.Positions[SpawnPosition.TopRight],
                3 => PieceSpawnConfigurations.Positions[SpawnPosition.MiddleLeft],
                4 => PieceSpawnConfigurations.Positions[SpawnPosition.MiddleCenter],
                5 => PieceSpawnConfigurations.Positions[SpawnPosition.MiddleRight],
                6 => PieceSpawnConfigurations.Positions[SpawnPosition.BottomLeft],
                7 => PieceSpawnConfigurations.Positions[SpawnPosition.BottomCenter],
                8 => PieceSpawnConfigurations.Positions[SpawnPosition.BottomRight],
                _ => throw new Exception("Invalid configuration."),
            };
    }
}