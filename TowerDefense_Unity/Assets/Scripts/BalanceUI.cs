using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BalanceUI : MonoBehaviour
{
    public Text balanceText;
    private Balance balance;

    void Start() => balance = FindObjectOfType<Balance>();
    void Update() => balanceText.text = balance.balance.ToString();
}
