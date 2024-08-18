using UnityEngine;

public class HitboxLogic : MonoBehaviour
{
    private readonly int playerLayer = 6;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == playerLayer)
        {
            collision.gameObject.GetComponent<CharacterControls>().Kill();
        }
    }
}
