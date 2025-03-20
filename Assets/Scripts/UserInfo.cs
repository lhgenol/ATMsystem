using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UserInfo : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI cashText;
    public TextMeshProUGUI balanceText;
    
    void Start()
    {
        Refresh();
    }

    public void Refresh()
    {
        UserData userData = GameManager.Instance.userData;
        
        nameText.text = userData.name;
        cashText.text = userData.cash.ToString("N0");
        balanceText.text = userData.balance.ToString("N0");
    }
}