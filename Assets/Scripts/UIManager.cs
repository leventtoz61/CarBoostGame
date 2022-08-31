using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _moneyText;
    private static UIManager _Instance;
    [SerializeField] private Transform _mainMenü;
    [SerializeField] private Transform _credits;
    [SerializeField] private GameObject _endGamePanel;
    [SerializeField] private Image _healthBarImage;
    [SerializeField] private TextMeshProUGUI _healthBarScore;
    [SerializeField] private TextMeshProUGUI _speedTextScore;
    [SerializeField] private GameObject _gameOverPanel;
    
    public static UIManager Instance => _Instance;
    private int moneyValue;

    public int MoneyValueProp
    {
        get
        {
            return moneyValue;
        }
        set
        {
            moneyValue = value;
            _moneyText.text = value.ToString();
            
        }
    }

    
    
    private void Awake()
    {
        _Instance = this;
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
        _mainMenü.gameObject.SetActive(false);

    }
    public void QuitGame()
    {
    
        Application.Quit();
        Debug.Log("exit game");
    
    }
    
    public void NextLevelButton( )
    {
        var NextLevel = SceneManager.GetActiveScene().buildIndex + 1;
        Debug.Log("çalışıyor mu");
        SceneManager.LoadScene(NextLevel);
        _endGamePanel.SetActive(false);
        
    }

    public void CreditsButtonClick()
    {
        _mainMenü.gameObject.SetActive(false);
        _credits.gameObject.SetActive(true);
        
    }

    public void OpenMainMenu()
    {
        
        _credits.gameObject.SetActive(false);
        _mainMenü.gameObject.SetActive(true);
    }

    public void OpenEndGamePanel()
    {
        _endGamePanel.SetActive(true);
    }

    public void SetHealthBar(float value)
    {
        _healthBarImage.fillAmount = value;
        _healthBarScore.text = (value * 100).ToString();
    }

    public void SpeedText(float speed)
    {
        _speedTextScore.text = speed.ToString();
    }

    public void GameOver()
    {
        
        _gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        var Restart = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(Restart);
    }
    
    
}
