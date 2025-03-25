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
        // UserDataList loadUserData = GameManager.Instance.LoadUserData();
        
        GameManager.Instance.LoadUserData();

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
        
        UserData loginUser = GameManager.Instance.FindUserID(inputID.text); // ID로 유저 찾기

        if (loginUser == null)
        {
            errorText.text = "해당 ID의 유저가 없습니다.";
            OpenErrorPanel();
            inputID.text = "";
            inputPS.text = "";
            return;
        }

        if (inputID.text == loginUser.id && inputPS.text == loginUser.password)
        {
            GameManager.Instance.SetUserData(loginUser); // 로그인한 유저 설정
            
            PopupLoginPanel.SetActive(false);
            PopupBank.SetActive(true);
            
            Debug.Log($"로그인 성공: {loginUser.name}");
            
            inputID.text = "";
            inputPS.text = "";
        }
        else
        {
            errorText.text = "ID 또는 Password가\n일치하지 않습니다.";
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
