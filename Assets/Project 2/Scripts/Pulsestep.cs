using UnityEngine;

using UnityEngine;

namespace StarterAssets
{
    public class PulseStep : MonoBehaviour
    {
        public StarterAssetsInputs input;
        public CharacterController controller;

        [Header("Pulse")]
        public SphereCollider pulseCollider;
        public float minRadius = 0.1f;
        public float maxRadius = 1.5f;
        public float expandSpeed = 8f;

        private bool _wasMoving;

        private void Start()
        {
            pulseCollider.radius = minRadius;
        }

        private void Update()
        {
            bool isMoving = input.move != Vector2.zero && controller.isGrounded;

            if (isMoving)
            {
                pulseCollider.radius = Mathf.Lerp(
                    pulseCollider.radius,
                    maxRadius,
                    Time.deltaTime * expandSpeed
                );

                _wasMoving = true;
            }
            else if (_wasMoving)
            {
                // reset after stopping
                pulseCollider.radius = Mathf.Lerp(
                    pulseCollider.radius,
                    minRadius,
                    Time.deltaTime * expandSpeed * 2f
                );

                if (pulseCollider.radius <= minRadius + 0.05f)
                {
                    _wasMoving = false;
                }
            }
        }
    }
}
