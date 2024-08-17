using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    [SerializeField] private float parallaxSpeed;
    [SerializeField] private GameObject mainCam;

    private void Update()
    {
        transform.position = new(mainCam.transform.position.x * (1 + parallaxSpeed), mainCam.transform.position.y, transform.position.z);
    }
}