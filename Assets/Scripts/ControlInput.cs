using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
    public class ControlInput : MonoBehaviour
    {
        public static KeyCode[] leftMoveKeys = new KeyCode[] { KeyCode.A, KeyCode.P };
        public static KeyCode[] rightMoveKeys = new KeyCode[] { KeyCode.X, KeyCode.Alpha8 };

        private FallDown _fallDown;

        private void Start()
        {
            _fallDown = gameObject.GetComponent<FallDown>();
        }

        private void Update()
        {
            if (!_fallDown.IsFalling)
                return;

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
