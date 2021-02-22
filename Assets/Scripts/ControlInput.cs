using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
    public class ControlInput : MonoBehaviour
    {
        public static KeyCode[] leftMoveKeys = new KeyCode[] { KeyCode.A, KeyCode.P };
        public static KeyCode[] rightMoveKeys = new KeyCode[] { KeyCode.X, KeyCode.Alpha8 };

        private PieceGenerator _pieceGenerator;
        private Rigidbody2D _rigidBody;

        private bool CanControl = true;

        private void Start()
        {
            _pieceGenerator = FindObjectOfType<PieceGenerator>();
            _rigidBody = gameObject.GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (!CanControl)
                return;

            if (_rigidBody.velocity.magnitude == 0
                && transform.position.y < Config.SpawnBoxLocation.y - 3f)
            {
                // Set tiles in this piece to not be controlled
                foreach (var tile in _pieceGenerator.ActivePiece.Tiles)
                {
                    tile.GetComponent<ControlInput>().CanControl = false;
                }
                return;
            }
            
            foreach (var keyCode in leftMoveKeys)
            {
                if (Input.GetKey(keyCode) && !rightMoveKeys.Contains(keyCode))
                {
                    transform.position = new Vector2(
                        transform.position.x - Config.HORIZONTAL_SPEED, transform.position.y
                        );
                    return;
                }
            }

            foreach (var keyCode in rightMoveKeys)
            {
                if (Input.GetKey(keyCode) && !leftMoveKeys.Contains(keyCode))
                {
                    transform.position = new Vector2(
                        transform.position.x + Config.HORIZONTAL_SPEED, transform.position.y
                        );
                    return;
                }
            }

        }
    }
}
