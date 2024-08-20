using UnityEngine;
public class MenuParallax : MonoBehaviour
{
    [SerializeField] private float speed;
    void Update()
    {
        transform.position += speed * Time.deltaTime * Vector3.right;
    }
}