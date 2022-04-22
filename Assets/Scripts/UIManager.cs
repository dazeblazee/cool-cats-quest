using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI HPText;
    private int HP;

    void Start()
    {
        HPText.text = "HP: " + 9999 + " / 9999";
    }

    public void UpdateHP(int damage)
    {
        HP -= damage;
        HPText.text = "HP: " + HP.ToString() + "/ 9999"; 
    }
}
