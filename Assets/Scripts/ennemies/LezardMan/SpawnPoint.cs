using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public bool isInCollision;

    private void OnTriggerEnter2D(Collider2D other)
    {
        isInCollision = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isInCollision = false;
    }
}
