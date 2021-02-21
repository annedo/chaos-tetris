using UnityEngine;

public class PieceRotator : MonoBehaviour
{
    private PieceGenerator _pieceGenerator;

    // Start is called before the first frame update
    void Start()
    {
        _pieceGenerator = FindObjectOfType<PieceGenerator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
            _pieceGenerator.ActivePiece.Rotate();
        else if (Input.GetKeyUp(KeyCode.Space))
            _pieceGenerator.ActivePiece.StopRotation();
    }
}
