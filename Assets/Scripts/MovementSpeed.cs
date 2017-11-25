using System;
using UnityEngine;

namespace DefaultNamespace
{
    [Serializable]
    public class MovementSpeed
    {
        [SerializeField]
        private float easy = 0.5f;
        public float Easy
        {
            get { return easy; }
        }

        [SerializeField]
        private float medium = 0.7f;
        public float Medium
        {
            get { return medium; }
        }

        [SerializeField]
        private float hard = 1f;
        public float Hard
        {
            get { return hard; }
        }
    }
}