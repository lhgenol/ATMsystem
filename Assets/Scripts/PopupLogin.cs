using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class PopupLogin : MonoBehaviour
{
    public TMP_InputField inputID;
    public TMP_InputField inputPS;

    public GameObject PopupLoginPanel;
    public GameObject PopupBank;
    public GameObject errorPanel;
    public TextMeshProUGUI errorText;

    private string savePath;

    private void Awake()
    {
        savePath = Path.Combine(Application.persistentDataPath, "userData.json");
        Debug.Log($"파일 경로: {savePath}");
    }

    public void Login()
    {
        // UserData userData = GameManager.Instance.userData;
        
        // if (inputID.text == userData.id && inputPS.text == userData.password)
        // {
        //     Debug.Log("로그인 성공");
        //     PopupLoginPanel.SetActive(false);
        //     PopupBank.SetActive(true);
        // }
        // else
        // {
        //     Debug.Log("로그인 실패");
        //     inputID.text = "";
        //     inputPS.text = "";
        // }

        UserData loadUserData = GameManager.Instance.LoadUserData();

        if (string.IsNullOrWhiteSpace(inputID.text))
        {
            errorText.text = "ID를 입력해주세요.";
            OpenErrorPanel();
            return;
        }

        if (string.IsNullOrWhiteSpace(inputPS.text))
        {
            errorText.text = "Password를 입력해주세요.";
            OpenErrorPanel();
            return;
        }

        if (loadUserData == null)
        {
            errorText.text = "해당 데이터가 없습니다.";
            OpenErrorPanel();
            inputID.text = "";
            inputPS.text = "";
            return;
        }

        if (inputID.text == loadUserData.id && inputPS.text == loadUserData.password)
        {
            PopupLoginPanel.SetActive(false);
            PopupBank.SetActive(true);
            
            Debug.Log("로그인 성공");
        }
        else
        {
            errorText.text = "ID 또는 Password가 일치하지 않습니다.";
            OpenErrorPanel();
            inputID.text = "";
            inputPS.text = "";
        }
    }

    public void OpenErrorPanel()
    {
        errorPanel.SetActive(true);
    }

    public void CloseErrorPanel()
    {
        errorPanel.SetActive(false);
    }
}
