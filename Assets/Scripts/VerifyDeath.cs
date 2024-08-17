using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerifyDeath : MonoBehaviour
{

    [SerializeField] private Collider2D c2D;
    [SerializeField] private LayerMask cameraLayer;

    // Update is called once per frame
    void Update()
    {
        if (IsDetected())
        {
            Destroy(gameObject);
        }
    }
    private bool IsDetected()
    {
        return Physics2D.IsTouchingLayers(c2D, cameraLayer);
    }
}
