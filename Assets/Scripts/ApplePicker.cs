using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class ApplePicker : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject basketPrefab;
    public int numBaskets = 4;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;

    [Header("Game Over UI")]
    public GameObject gameOverPanel;
    public TMP_Text gameOverText;
    public Button restartButton;
    public TMP_Text roundText;

    private int currentRound = 1;

    void Start()
    {
        basketList = new List<GameObject>();
        for (int i=0; i<numBaskets; i++) {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }

        gameOverPanel.SetActive(false);
        restartButton.onClick.AddListener(RestartGame);

        roundText.text = "Round " + currentRound;
    }

    public void AppleMissed()
    {
        GameObject[] fallingObjects = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject tempGO in fallingObjects)
        {
            Destroy(tempGO);
        }

        fallingObjects = GameObject.FindGameObjectsWithTag("GoldenApple");
        foreach (GameObject tempGO in fallingObjects)
        {
            Destroy(tempGO);
        }

        fallingObjects = GameObject.FindGameObjectsWithTag("Branch");
        foreach (GameObject tempGO in fallingObjects)
        {
            Destroy(tempGO);
        }

        if (basketList.Count == 0) 
        {
            ShowGameOver();
            return;
        }

        // Destroy one of the baskets
        int basketIndex = basketList.Count - 1;
        
        if (basketIndex >= 0)
        {
            // Get a reference to that Basket GameObject
            GameObject basketGO = basketList[basketIndex];
            basketList.RemoveAt(basketIndex);
            Destroy(basketGO);
        }
        

        // If there are no baskets left, restart the game
        if (basketList.Count == 0) 
        {
            ShowGameOver();
        }

        UpdateRound();
    }
    
    void UpdateRound()
    {
        currentRound = Mathf.Clamp(numBaskets - basketList.Count + 1, 1, 4);
        roundText.text = "Round " + currentRound;
    }
    
    public void ShowGameOver()
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
    }

    void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
