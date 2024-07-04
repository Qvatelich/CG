using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private GameObject _deck;
    [SerializeField] private GameObject _shop;
    [SerializeField] private ButtonAnim _deckButton;
    [SerializeField] private ButtonAnim _shopButton;
    [SerializeField] private GameObject _settingsPanel;
    [SerializeField] private Sprite _speebNormalsprite;
    [SerializeField] private Sprite _speebUpsprite;
    [SerializeField] private Image _speedUp;
    [SerializeField] private CardsPanel _cardPanel;

    public void StartFreeGame()
    {
        SceneManager.LoadScene(1);
    }

    public void EndFreeGame()
    {
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
}
