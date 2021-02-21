using Assets.Scripts;
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
        if (ActivePiece?.Tiles == null
                || ActivePiece.Tiles.All(x => x.gameObject == null)
                || ActivePiece.IsPlaced)
            ActivePiece = new Piece(GetRandomTile(), GetRandomPieceShape());
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
