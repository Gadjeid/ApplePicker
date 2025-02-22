using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    [Header("Dynamic")]
    public int score = 0;
    private TMP_Text uiText;
    void Start()
    {
        uiText = GetComponent<TMP_Text>();
    }

    void Update()
    {
        if (uiText != null)
        {
            uiText.text = score.ToString("#,0");
        }
    }
}
