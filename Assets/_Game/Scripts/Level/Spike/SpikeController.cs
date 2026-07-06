using UnityEngine;

public class SpikeController: MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            Debug.Log("Hit player!");
        }
    }
}