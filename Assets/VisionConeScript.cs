using StarterAssets;
using UnityEngine;

public class VisionConeScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is create
    private bool crouchCheck; // Variable to store the crouch state of the player
    [SerializeField] private GameObject messenger;
    [SerializeField] private GameObject cone;
    // && other.gameObject == player
    void Start()

    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (messenger.name == "On")
        {
            crouchCheck = true;
            //Debug.Log("Player is crouching, vision cone reduced.");
        }
        else
        {
            crouchCheck = false;
            //Debug.Log("Player is not crouching, vision cone normal.");
        }

    }

    private void OnTriggerStay(Collider other)
    {
       // Debug.Log("in cone");

        if (crouchCheck == true)
        {
            // Reduce the size of the vision cone
            //transform.localScale = new Vector3(0.5f, 0.5f, 1f);
            Debug.Log("Passed without Detection");

        }
        else
        {
            //Debug.Log("Player ");
            Debug.Log("You have been spotted");

        }

    }

   

}
