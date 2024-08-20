using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateLogic : MonoBehaviour
{
    // Fields
    [SerializeField] private bool usesButton;
    [SerializeField] private ButtonLogic button;
    [SerializeField] private LightLogic[] indicatorLights;
    private readonly float amountToMove = 2;
    private Vector3 startingPosition;
    [SerializeField] private float gateSpeed = 10;
    
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
            transform.localPosition = startingPosition + (gameObject.transform.up * _amountMoved);
        }
    }

    // Monobehavior Methods
    private void Start()
    {
        startingPosition = transform.localPosition;
    }
    private void Update()
    {
        if (usesButton)
        {
            if (AmountMoved < amountToMove && button.ButtonPushed)
            {
                AmountMoved += Time.deltaTime * gateSpeed;
            }
            else if (AmountMoved > 0 && !button.ButtonPushed)
            {
                AmountMoved -= Time.deltaTime * gateSpeed;
            }
        }
        else
        {
            bool allLightsOn = true;
            foreach(LightLogic each in indicatorLights)
            {
                if(each.LightOn == false)
                {
                    allLightsOn = false;
                }
            }
            if (AmountMoved < amountToMove && allLightsOn)
            {
                AmountMoved += Time.deltaTime * gateSpeed;
            }
            else if (AmountMoved > 0 && !allLightsOn)
            {
                AmountMoved -= Time.deltaTime * gateSpeed;
            }
        }
    }
}
