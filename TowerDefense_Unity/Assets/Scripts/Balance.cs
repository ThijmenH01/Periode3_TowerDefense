using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Balance : MonoBehaviour
{
    public static Balance Instance { get; private set; }

    public int balance;
    public int balanceAddon;

    void Start()
    {
        Instance = this;
        balance = 500;
    }

    [HideInInspector] public float startTimer = 2f;
    private float _endTimer = 0f;

    private void Update()
    {
        if (startTimer <= _endTimer)
        {
            balance += balanceAddon;
            startTimer = 2f;
        }
        else
        {
            startTimer -= Time.deltaTime;
        }
    }
}
