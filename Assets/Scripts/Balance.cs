using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Balance : MonoBehaviour
{
    public TextMeshProUGUI balanceText;
    public int balance;
    
    void Start()
    {
        balanceText.text = balance.ToString("N0");
    }
    
    void Update()
    {
        
    }
}
