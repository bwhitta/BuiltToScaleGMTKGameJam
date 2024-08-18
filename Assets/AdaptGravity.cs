using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdaptGravity : MonoBehaviour
{
    private readonly float gravityPower = 1;

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
    
    void Update()
    {
        PlayerRigidbody.gravityScale = (ResolutionManager.height / Screen.height) * gravityPower;
    }
}
