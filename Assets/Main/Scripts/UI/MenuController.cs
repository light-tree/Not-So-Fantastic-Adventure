using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MenuController : MonoBehaviour
{
    private UIDocument _doc;
    private Button _playButton;
    private Button _settingButton;
    private Button _exitButton;
    private Button _muteButton;
    private Button _backButton;
    private Button _saveButton;
    private Slider _lightSlider;
    private Slider _soundSlider;
    private VisualElement _buttonsContainer;
    private VisualElement _addjustSetting;

    [SerializeField]
    VisualTreeAsset _settingsTemplate;
    [SerializeField]
    private Sprite _mutedSprite;
    [SerializeField]
    private Sprite _unmutedSprite;
    [SerializeField]
    bool _mute = false;

    private void Awake()
    {
        _doc = GetComponent<UIDocument>();
        //_addjustSetting = _settingsTemplate.CloneTree();
        _buttonsContainer = _doc.rootVisualElement.Q<VisualElement>("ButtonContainer");
        _playButton = _doc.rootVisualElement.Q<Button>("PlayButton");
        _settingButton = _doc.rootVisualElement.Q<Button>("SettingButton");
        _exitButton = _doc.rootVisualElement.Q<Button>("ExitButton");
        //_backButton = _addjustSetting.Q<Button>("BackButton");
        //_saveButton = _addjustSetting.Q<Button>("SaveButton");
        //_soundSlider = _addjustSetting.Q<Slider>("SoundSetting");
        //_lightSlider = _addjustSetting.Q<Slider>("LightSetting");
        //_muteButton = _doc.rootVisualElement.Q<Button>("MuteButton");

        _playButton.clicked += PlayButtonOnClicked;
        _exitButton.clicked += ExitButtonOnClicked;
        _settingButton.clicked += SettingsButtonOnClick;
        //_backButton.clicked += BackButtonOnClick;
        //_saveButton.clicked += SaveButtonOnClick;
        //_muteButton.clicked += MuteButtonOnClick;
    }

    private void PlayButtonOnClicked()
    {
        SceneManager.LoadScene("Game");
    }

    private void ExitButtonOnClicked()
    {
        Application.Quit();
    }

    private void MuteButtonOnClick()
    {
        _mute = !_mute;

        var bg = _muteButton.style.backgroundImage;
        bg.value = Background.FromSprite(_mute ? _mutedSprite : _unmutedSprite);
        _muteButton.style.backgroundImage = bg;

        AudioListener.volume = _mute ? 0 : 1;
    }

    private void SettingsButtonOnClick()
    {
        _buttonsContainer.Clear();
        _buttonsContainer.Add(_addjustSetting);
    }

    private void BackButtonOnClick()
    {
        _buttonsContainer.Clear();
        _buttonsContainer.Add(_playButton);
        _buttonsContainer.Add(_settingButton);
        _buttonsContainer.Add(_exitButton);
    }

    private void SaveButtonOnClick()
    {
        AudioListener.volume = _mute ? 0 : _soundSlider.value / 100;

        _buttonsContainer.Clear();
        _buttonsContainer.Add(_playButton);
        _buttonsContainer.Add(_settingButton);
        _buttonsContainer.Add(_exitButton);
    }
}
