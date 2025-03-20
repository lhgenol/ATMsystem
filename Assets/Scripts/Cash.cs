using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Cash : MonoBehaviour
{
    public TextMeshProUGUI cashText;
    public int cash;
    
    void Start()
    {
        // cashText.text = cash.ToString("N0");
        cashText.text = string.Format("{0:N0}", cash);
    }
    
    void Update()
    {
        
    }
}
