using Assets.Scripts;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Creates pre-configurations of pieces that the player will be able to control.
/// </summary>
public class PieceGenerator : MonoBehaviour
{
    public GameObject[] _tilePrefabs;
    public Piece ActivePiece;

    private readonly System.Random Random = new System.Random();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (ActivePiece?.Tiles == null || ActivePiece.IsPlaced)
        {
            // Perform stack check
            StackCheck();

            // Spawn new piece
            ActivePiece = new Piece(GetRandomTile(), GetRandomPieceShape());
        }
    }

    private static readonly List<float> RowClearLines = new List<float>()
    {
        -10f
        -9f,
        -8f,
        -7f,
        -6f,
        -5f,
        -4f,
        -3f,
        -2f,
        -1f,
        0f,
        1f,
        2f,
        3f,
        4f,
        5f,
        6f,
        7f,
        8f,
        9f
    };

    private void StackCheck()
    {
        var tiles = GameObject.FindGameObjectsWithTag(Constants.Tile);

        int counter = 0;
        foreach (var height in RowClearLines)
        {
            counter = 0;

            List<GameObject> tilesToDestroy = new List<GameObject>();
            foreach (var tile in tiles)
            {
                if (FloatsAreCloseEnough(tile.transform.position.y, height))
                {
                    tilesToDestroy.Add(tile);
                    counter++;
                }
            }

            if (counter > 8)
                tilesToDestroy.ForEach(Destroy);
        }
    }

    /// <summary>
    /// Returns true if float1 is within a certain range of float2.
    /// </summary>
    /// <param name="float1"></param>
    /// <param name="float2"></param>
    /// <returns></returns>
    private bool FloatsAreCloseEnough(float float1, float float2, float difference = 1f)
    {
        if (float1 < float2 + difference
            && float1 > float2 - difference)
            return true;

        return false;
    }

    /// <summary>
    /// Generate a tile from a random prefab.
    /// </summary>
    /// <returns></returns>
    private GameObject GetRandomTile()
        => Instantiate(_tilePrefabs[Random.Next(0, _tilePrefabs.Length)]);

    /// <summary>
    /// Grabs a random spawn configuration.
    /// </summary>
    /// <returns></returns>
    private string GetRandomPieceShape()
        => PieceSpawnConfigurations.Configurations
            [Random.Next(0, PieceSpawnConfigurations.Configurations.Count)];
}
