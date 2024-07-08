using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private GameObject _deck;
    [SerializeField] private GameObject _shop;
    [SerializeField] private GameObject _settingsPanel;
    [SerializeField] private GameObject _nonCardWarning;
    [SerializeField] private ButtonAnim _deckButton;
    [SerializeField] private ButtonAnim _shopButton;
    [SerializeField] private Sprite _speebNormalsprite;
    [SerializeField] private Sprite _speebUpsprite;
    [SerializeField] private Image _speedUp;
    [SerializeField] private CardsPanel _cardPanel;

    public void StartFreeGame()
    {
        StopAllCoroutines();
        int sum = 0;
        for (int i = 0; i < 4; i++)
        {
            int value = PlayerPrefs.GetInt((i + 1).ToString() + "C");
            if (value == 0)
            {
                sum++;
            }
        }

        if (sum == 4)
        {
            StartCoroutine(Warning());
            _nonCardWarning.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }

    public void EndFreeGame()
    {
        PlayerPrefs.SetInt("Money",PlayerPrefs.GetInt("MoneyInLevel") + PlayerPrefs.GetInt("Money"));
        PlayerPrefs.SetInt("MoneyInLevel",0);
        SceneManager.LoadScene(0);
    }

    public void Deck()
    {
        _cardPanel.Start();
        _deck.SetActive(!_deck.activeSelf);
        _deckButton.Exit();
    }

    public void Shop()
    {
        _shop.SetActive(!_shop.activeSelf);
        _shopButton.Exit();
    }

    public void Settings()
    {
        _settingsPanel.SetActive(!_settingsPanel.activeSelf);
    }

    public void SpeedUp()
    {
        _speedUp.sprite = _speedUp.sprite == _speebNormalsprite ? _speebUpsprite : _speebNormalsprite;
    }

    private IEnumerator Warning()
    {
        yield return  new WaitForSeconds(2f);
        _nonCardWarning.SetActive(false);
    }
}
