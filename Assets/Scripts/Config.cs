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
        public const float SpawnBoxLength = 2f;
        public const float SpawnBoxHeight = 2f;
        public static readonly Vector2 SpawnBoxLocation = new Vector2(0, 10f);

        public const float FALL_SPEED = 0.01f; // Float moved per frame

        public const float HORIZONTAL_SPEED = 0.05f; // Float moved per frame while moving

        public const int ROTATION_SPEED = 200;
    }
}
