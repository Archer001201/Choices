using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Choices.Transition
{
    public class Teleport : MonoBehaviour
    {
        public string targetScene;
        public Vector3 targetPosition;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                EventHandler.CallTransitionEvent(targetScene, targetPosition);
            }
        }
    }
}

