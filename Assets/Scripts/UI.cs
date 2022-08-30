using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    [SerializeField] private GameObject winDisplay;
    [SerializeField] private TextMeshProUGUI coinText;

    public static UI Instance {get; private set;}

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There is more than one UI");
            Destroy(this);
        }

        Instance = this;

        winDisplay.SetActive(false);
        coinText.gameObject.SetActive(true);
    }

    public void ShowWin()
    {
        winDisplay.SetActive(true);
    }

    public void UpdateCoinCount(int coinCount)
    {
        coinText.text = "Coins: " + coinCount;
    }
}
