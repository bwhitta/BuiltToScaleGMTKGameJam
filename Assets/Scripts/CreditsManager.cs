using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsManager : MonoBehaviour
{
    [SerializeField] private float totalDistance;
    [SerializeField] private float speed;
    [SerializeField] private string menuScene;

    void Update()
    {
        transform.position += speed * Time.deltaTime * Vector3.right;
        if(transform.position.x > totalDistance)
        {
            Debug.Log($"finished credits");
            SceneManager.LoadScene(menuScene);
        }
    }
}
