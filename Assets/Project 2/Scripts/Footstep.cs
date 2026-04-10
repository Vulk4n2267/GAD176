using UnityEngine;

namespace StarterAssets
{
    public class Footstep : MonoBehaviour
    {
        public StarterAssetsInputs input;
        public AudioSource audioSource;
        public AudioClip footstepSound;

        private void Update()
        {
            // If any movement key is pressed
            if (input.move != Vector2.zero)
            {
                // Only play if not already playing
                if (!audioSource.isPlaying)
                {
                    audioSource.PlayOneShot(footstepSound);
                }
            }
        }
    }
}