using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class FallDown : MonoBehaviour
    {
        private void Start()
        {
            
        }

        private int FrameCount = 0;

        private void Update()
        {
            // Fall down
            transform.position = new Vector2(
                transform.position.x, 
                transform.position.y - Config.FALL_SPEED
                );

            FrameCount++;

            // Die every X frames for testing
            if (FrameCount % 2000 == 0)
                Destroy(gameObject);            
        }
    }
}
