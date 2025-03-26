using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UserInfo : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI cashText;
    public TextMeshProUGUI balanceText;
    public TextMeshProUGUI idInputText;
    public TextMeshProUGUI passwordInputText;
    
    void Start()
    {
        Refresh();
    }

    // 유저 데이터를 UI에 표시
    public void Refresh()
    {
        UserData userData = GameManager.Instance.userData;
        
        nameText.text = userData.name;
        cashText.text = userData.cash.ToString("N0");
        balanceText.text = userData.balance.ToString("N0");
        idInputText.text = userData.id;
        passwordInputText.text = userData.password;
    }
}