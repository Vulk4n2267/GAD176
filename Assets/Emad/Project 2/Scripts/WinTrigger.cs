using UnityEngine;

public class WinTrigger : MonoBehaviour
{
   
    public GameObject winUI;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Win();
        }
    }

    void Win()
    {
       
        Time.timeScale = 0f;

        if (winUI != null)
            winUI.SetActive(true);

        Debug.Log("You Win!");
    }
}