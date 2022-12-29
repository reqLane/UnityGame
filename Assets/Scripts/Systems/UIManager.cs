using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI playerHP;
    [SerializeField]
    private TextMeshProUGUI hint;

    private void Update()
    {
        if(SceneManager.GetActiveScene().name != "Intro")
        {
            playerHP.text = GameManager.Instance.Player.StatsSO.HP.ToString();
        }
    }

    public void ShowHint(string text)
    {
        hint.text = text;
    }
}
