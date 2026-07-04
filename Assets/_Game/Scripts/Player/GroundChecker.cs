using UnityEngine;

public class GroundChecker: MonoBehaviour
{
    public bool IsOnGround { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CheckColliderAndSet(collision, true);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        CheckColliderAndSet(collision, true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        CheckColliderAndSet(collision, false);
    }

    private void CheckColliderAndSet(Collider2D other, bool state)
    {
        if (other.CompareTag("Ground"))
        {
            IsOnGround = state;
        }
    }
}