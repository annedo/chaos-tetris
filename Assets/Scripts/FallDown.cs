using UnityEngine;

namespace Assets.Scripts
{
    public class FallDown : MonoBehaviour
    {
        public bool IsFalling = true;

        private void Start()
        {
            
        }

        private void Update()
        {
            if (IsFalling)
            {
                // Fall down
                transform.position = new Vector2(
                    transform.position.x,
                    transform.position.y - Config.FALL_SPEED
                    );
            }
        }
    }
}
