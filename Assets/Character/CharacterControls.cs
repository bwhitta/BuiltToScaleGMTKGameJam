using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControls : MonoBehaviour
{
    [SerializeField] private float speed, jumpVelocity;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    private Rigidbody2D _playerRigidbody;
    private Rigidbody2D PlayerRigidbody
    {
        get
        {
            if (_playerRigidbody == null)
            {
                _playerRigidbody = GetComponent<Rigidbody2D>();
            }
            return _playerRigidbody;
        }
    }

    private bool Grounded => Physics2D.OverlapCircle(groundCheck.position, 0.01f, groundLayer) != null;

    void FixedUpdate()
    {
        // Reset velocity
        PlayerRigidbody.velocity *= new Vector2(0, 1);
        
        // Check inputs
        if (Input.GetKey(KeyCode.A))
        {
            PlayerRigidbody.velocity += Vector2.left * speed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
             PlayerRigidbody.velocity += Vector2.right * speed;
        }
        if (Input.GetKey(KeyCode.W) && Grounded)
        {
            PlayerRigidbody.velocity *= new Vector2(1, 0);
            PlayerRigidbody.velocity += jumpVelocity * Screen.currentResolution.height * Vector2.up/Screen.height;
        }
    }
}
