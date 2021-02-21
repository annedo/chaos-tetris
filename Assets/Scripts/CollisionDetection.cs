using Assets.Scripts;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    private PieceGenerator _pieceGenerator;
    private FallDown _fallDown;

    // Start is called before the first frame update
    void Start()
    {
        _pieceGenerator = FindObjectOfType<PieceGenerator>();
        _fallDown = GetComponent<FallDown>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!_fallDown.IsFalling)
            return;

        if (collision.collider.CompareTag(Constants.GridBottom)
            || !collision.collider.gameObject.GetComponent<FallDown>().IsFalling)
        {
            // Set tiles in this piece to no longer fall
            foreach (var tile in _pieceGenerator.ActivePiece.Tiles)
            {
                tile.GetComponent<FallDown>().IsFalling = false;
            }

            _pieceGenerator.ActivePiece.IsPlaced = true;
        }

        // TODO - Side collision ignore

        // TODO - Trigger stack check
    }
}
