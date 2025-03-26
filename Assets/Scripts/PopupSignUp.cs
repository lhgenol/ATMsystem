using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopupSignUp : MonoBehaviour
{
    public TMP_InputField inputId;
    public TMP_InputField inputName;
    public TMP_InputField inputPassword;
    public TMP_InputField inputPasswordConfirm;

    public GameObject popupSignUp;
    public GameObject errorPanel;
    public TextMeshProUGUI errorText;

    public void SignUp()
    {
        if (string.IsNullOrWhiteSpace(inputId.text))
        {
            errorText.text = "ID를 확인해주세요.";
            OpenErrorPanel();
            return;
        }

        if (string.IsNullOrWhiteSpace(inputName.text))
        {
            errorText.text = "Name을 확인해주세요.";
            OpenErrorPanel();
            return;
        }

        if (string.IsNullOrWhiteSpace(inputPassword.text))
        {
            errorText.text = "Password를 확인해주세요.";
            OpenErrorPanel();
            return;
        }
        
        if (string.IsNullOrEmpty(inputPasswordConfirm.text))
        {
            errorText.text = "Password Confirm을 확인해주세요.";
            OpenErrorPanel();
            return;
        }

        if (inputPassword.text != inputPasswordConfirm.text)
        {
            errorText.text = "Password가 같지 않습니다.";
            OpenErrorPanel();
            return;
        }

        if (GameManager.Instance != null)
        {
            // UserData 객체 생성. 입력한 정보와 기본 금액을 반영
            UserData newUser = new UserData(inputName.text, 100000, 50000, inputId.text, inputPassword.text);
        
            GameManager.Instance.SetUserData(newUser);  // 데이터를 GameManager에 저장
        }

        inputId.text = "";
        inputName.text = "";
        inputPassword.text = "";
        inputPasswordConfirm.text = "";
        
        ClosePopupSignUp();
        
    }
    
    public void OpenPopupSignUp()
    {
        popupSignUp.SetActive(true);
    }
    
    public void ClosePopupSignUp()
    {
        popupSignUp.SetActive(false);
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
