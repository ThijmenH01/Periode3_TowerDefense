using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    public Text playerHealthPointsText;

    void Update() => playerHealthPointsText.text = GameManager.Instance.playerHealth.ToString();
}
