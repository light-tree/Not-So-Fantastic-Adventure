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
    private VisualElement _currenHealth;
    private VisualElement _pauseLayout;
    private UIDocument _document;
    private Button _continueButton;
    private Button _quitButton;
    private float timeRun = 0;
    private float timeupdate = 0;
    private float cureentHp = 100;
    private int pointHp = 100;
    // Start is called before the first frame update
    void Start()
    {
        _document = GetComponent<UIDocument>();
        _time = _document.rootVisualElement.Q<Label>("Time");
        _currenHealth = _document.rootVisualElement.Q<VisualElement>("CurrentHealth");
        _healthDetail = _document.rootVisualElement.Q<Label>("HealthDetail");
        _pauseLayout = _document.rootVisualElement.Q<VisualElement>("PauseScreen");
        //_pauseLayout = _pauseScreen.Q<VisualElement>("PauseLayout");
        _continueButton = _document.rootVisualElement.Q<Button>("ContinueButton");
        _quitButton = _document.rootVisualElement.Q<Button>("QuitGameButton");

        _currenHealth.style.width = 800;
        _healthDetail.text = $"{cureentHp}/100";
        _continueButton.clicked += ContinueButtonClick;
        _quitButton.clicked += QuitButtonOnClick;

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

        _time.text = result;
    }

    public void UpdateHealth(int hp)
    {
        pointHp = hp;
    }

}
