using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameController : MonoBehaviour
{
    private Label _time;
    private Label _healthDetail;
    private Label _normalScore;
    private Label _bossScore;
    private Label _totalTime;
    private VisualElement _currenHealth;
    private VisualElement _pauseLayout;
    private VisualElement _loseLayout;
    private UIDocument _document;
    private Button _continueButton;
    private Button _quitButton;
    private Button _playAgainButton;
    private Button _mainMenuButton;
    private float timeRun = 0;
    private float timeupdate = 0;
    private float cureentHp = 100;
    private int pointHp = 100;
    private string totalTime = "";
    // Start is called before the first frame update
    void Start()
    {
        _document = GetComponent<UIDocument>();
        _time = _document.rootVisualElement.Q<Label>("Time");
        _currenHealth = _document.rootVisualElement.Q<VisualElement>("CurrentHealth");
        _healthDetail = _document.rootVisualElement.Q<Label>("HealthDetail");
        _normalScore = _document.rootVisualElement.Q<Label>("ScoreNormal");
        _totalTime = _document.rootVisualElement.Q<Label>("TotalTime");
        _bossScore = _document.rootVisualElement.Q<Label>("ScoreBoss");
        _pauseLayout = _document.rootVisualElement.Q<VisualElement>("PauseScreen");
        //_pauseLayout = _pauseScreen.Q<VisualElement>("PauseLayout");
        _continueButton = _document.rootVisualElement.Q<Button>("ContinueButton");
        _quitButton = _document.rootVisualElement.Q<Button>("QuitGameButton");
        _loseLayout = _document.rootVisualElement.Q<VisualElement>("LoseScreen");
        _playAgainButton = _document.rootVisualElement.Q<Button>("PlayAgainButton");
        _mainMenuButton = _document.rootVisualElement.Q<Button>("MainMenuButton");

        _currenHealth.style.width = 800;
        _healthDetail.text = $"{cureentHp}/100";
        _continueButton.clicked += ContinueButtonClick;
        _quitButton.clicked += QuitButtonOnClick;
        _playAgainButton.clicked += PlayAgainButtonClick;
        _mainMenuButton.clicked += MainMenuButtonOnClick;

        Time.timeScale = 1;
    }

    private void QuitButtonOnClick()
    {
        SceneManager.LoadScene("Menu");
    }

    // Update is called once per frame
    void Update()
    {
        if(cureentHp > pointHp && cureentHp >= 0)
        {
            cureentHp -= (cureentHp) * Time.deltaTime;
            _currenHealth.style.width = cureentHp * 8;
            _healthDetail.text = $"{Math.Round(cureentHp, 0)}/100";
            timeupdate = 0;
        }

        PauseGame();
        SetTime();
    }

    private void PauseGame()
    {
        if (Input.GetMouseButtonUp(1))
        {
            _pauseLayout.style.display = DisplayStyle.Flex;
            //_document.rootVisualElement.Add(_pauseLayout);
            Time.timeScale = 0;
        }
    }

    private void ContinueButtonClick()
    {
        Time.timeScale = 1;
        _pauseLayout.style.display = DisplayStyle.None;
        //_document.rootVisualElement.Remove(_pauseLayout);
    }

    private void SetTime()
    {
        string result = "";
        timeRun += Time.deltaTime;
        double minute = Math.Round(timeRun / 60, 0);
        double second = Math.Round(timeRun % 60, 0);
        if(minute < 10)
        {
            result += $"0{minute} : ";
        } else
        {
            result += $"{minute} : ";
        }

        if (second < 10)
        {
            result += $"0{second}";
        }
        else
        {
            result += $"{second}";
        }
        totalTime = result;
        _time.text = result;
    }

    public void UpdateHealth(int hp)
    {
        pointHp = hp;
    }

    public void SetLoseScreen(int normalScore,int bossScore)
    {
        _bossScore.text = $"x{bossScore}";
        _normalScore.text = $"x{normalScore}";
        _totalTime.text = totalTime;
        _loseLayout.style.display = DisplayStyle.Flex;
        Time.timeScale = 0;
    }

    private void PlayAgainButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void MainMenuButtonOnClick()
    {
        SceneManager.LoadScene("Menu");
    }

}
