using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public static class Config
    {
        public const int QUEUE_LENGTH = 1;

        public const float SpawnBoxLength = 2f;
        public const float SpawnBoxHeight = 2f;
        public static readonly Vector2 SpawnBoxLocation = new Vector2(0, 10f);

        public const float FALL_SPEED = 0.01f; // Float moved per frame
    }
}
