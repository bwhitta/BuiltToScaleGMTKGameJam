using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorLogic : MonoBehaviour
{
    [SerializeField] private string nextLevel;
    private readonly int playerLayer = 6;
    private float timeInTrigger;
    private readonly float timeToEnter = 0.5f;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == playerLayer)
        {
            timeInTrigger += Time.deltaTime;
            if (timeInTrigger >= timeToEnter)
            {
                SceneManager.LoadScene(nextLevel);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == playerLayer)
        {
            timeInTrigger = 0;
        }
    }
}