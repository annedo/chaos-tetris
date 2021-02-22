using Assets.Scripts;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    private PieceGenerator _pieceGenerator;
    private Rigidbody2D _rigidBody;

    private bool TilePlaced = false;

    // Start is called before the first frame update
    void Start()
    {
        _pieceGenerator = FindObjectOfType<PieceGenerator>();
        _rigidBody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (TilePlaced)
            return;

        // Skip collision detection at spawn box
        if (transform.position.y >= Config.SpawnBoxLocation.y - 3f)
            return;        

        if (_rigidBody.velocity.magnitude > 0)
            return;        

        _pieceGenerator.ActivePiece.IsPlaced = true;

        // Set tiles in this piece to placed
        foreach (var tile in _pieceGenerator.ActivePiece.Tiles)
        {
            tile.GetComponent<CollisionDetection>().TilePlaced = true;
        }
    }
}