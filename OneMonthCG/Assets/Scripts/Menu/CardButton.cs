using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardButton : MonoBehaviour
{
    [SerializeField] private GameObject _cardPanel;
    [SerializeField] private GameObject _costObj;
    [SerializeField] private List<ChoicePosition> _cards;
    [SerializeField] private int _cardValue;
    [SerializeField] private int _cost;
    [SerializeField] private Sprite _icon;

    [SerializeField] Image _image;

    private void Start()
    {
        _costObj.GetComponent<Text>().text = _cost.ToString();
        _image.sprite = _icon;
        if (_icon == null)
        {
            _image.enabled = false;
        }
    }

    public void BuyCard()
    {
        if (_image.sprite != null)
        {
            foreach (ChoicePosition card in _cards)
            {
                card.Cardvalue = _cardValue;
                card.Cost = _cost;
            }

            GameObject[] activePanels = GameObject.FindGameObjectsWithTag("ShopCardPanel");

            foreach (GameObject panel in activePanels)
            {
                panel.SetActive(false);
            }

            _cardPanel.SetActive(true);
        }
    }

    public void Buy()
    {
        _costObj.SetActive(false);
        _image.sprite = null;
        _image.enabled = false;
    }
}
