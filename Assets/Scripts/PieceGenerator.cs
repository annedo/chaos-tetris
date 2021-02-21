using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Creates pre-configurations of pieces that the player will be able to control.
/// </summary>
public class PieceGenerator : MonoBehaviour
{
    public GameObject[] _tiles;
    public Piece ActivePiece;

    private Queue<Piece> _pieceQueue = new Queue<Piece>(Config.QUEUE_LENGTH);
    private readonly System.Random _random = new System.Random();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Check queue, produce pieces for empty queue spots
        if (_pieceQueue.Count < Config.QUEUE_LENGTH)
            FillQueue(_pieceQueue);        

        if (ActivePiece?.Tiles == null || ActivePiece.Tiles.All(x => x.gameObject == null))
            ActivePiece = _pieceQueue.Dequeue();

        // TODO - Update visible queue pieces
    }

    private void FillQueue(Queue<Piece> queue)
    {
        while (queue.Count < Config.QUEUE_LENGTH)
        {
            queue.Enqueue(new Piece(GetRandomTile(), GetRandomPieceShape()));
        }
    }

    /// <summary>
    /// Generate a tile from a random prefab.
    /// </summary>
    /// <returns></returns>
    private GameObject GetRandomTile()
        => Instantiate(_tiles[_random.Next(0, _tiles.Length)]);

    /// <summary>
    /// Grabs a random spawn configuration.
    /// </summary>
    /// <returns></returns>
    private string GetRandomPieceShape()
        => PieceSpawnConfigurations.Configurations
            [_random.Next(0, PieceSpawnConfigurations.Configurations.Count)];
}
