using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VerifyExit : MonoBehaviour
{

    [SerializeField] private Collider2D col2D;
    [SerializeField] private LayerMask playerHitbox;
    [SerializeField] private string n;

    // Update is called once per frame
    void Update()
    {
        if (IsDetected())
        {
            SceneManager.LoadScene(n, LoadSceneMode.Single);
        }
    }
    private bool IsDetected()
    {
        return Physics2D.IsTouchingLayers(col2D, playerHitbox);
    }
}