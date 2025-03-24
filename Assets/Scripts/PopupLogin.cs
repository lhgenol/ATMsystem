using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopupLogin : MonoBehaviour
{
    public TMP_InputField inputID;
    public TMP_InputField inputPS;

    public GameObject PopupLoginPanel;
    public GameObject PopupBank;

    public void Login()
    {
        UserData userData = GameManager.Instance.userData;

        if (inputID.text == userData.id && inputPS.text == userData.password)
        {
            Debug.Log("로그인 성공");
            PopupLoginPanel.SetActive(false);
            PopupBank.SetActive(true);
        }
        else
        {
            Debug.Log("로그인 실패");
            inputID.text = "";
            inputPS.text = "";
        }
    }
}
