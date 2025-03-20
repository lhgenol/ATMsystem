using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UserInfo : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI cashText;
    public TextMeshProUGUI balanceText;
    
    public UserData lhData;
    
    void Start()
    {
        nameText.text = lhData.userName;
        cashText.text = lhData.cash.ToString("N0");
        balanceText.text = lhData.balance.ToString("N0");
    }
    
    void Update()
    {
        
    }
}
