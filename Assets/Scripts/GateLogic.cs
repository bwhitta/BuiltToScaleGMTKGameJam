using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateLogic : MonoBehaviour
{
    // Fields
    [SerializeField] private ButtonLogic button;
    private readonly float amountToMove = 2;
    private Vector3 startingPosition;
    private readonly float gateSpeed = 10;
    
    // Properties
    private float _amountMoved;
    private float AmountMoved
    {
        get
        {
            return _amountMoved;
        }
        set
        {
            _amountMoved = Mathf.Clamp(value, 0, amountToMove);
            transform.localPosition = new Vector3(startingPosition.x, startingPosition.y + _amountMoved, startingPosition.z);
        }
    }

    // Monobehavior Methods
    private void Start()
    {
        startingPosition = transform.localPosition;
    }
    private void Update()
    {
        if (AmountMoved < amountToMove && button.ButtonPushed)
        {
            AmountMoved += Time.deltaTime * gateSpeed;
        }
        if (AmountMoved > 0 && !button.ButtonPushed)
        {
            AmountMoved -= Time.deltaTime * gateSpeed;
        }
    }
}
