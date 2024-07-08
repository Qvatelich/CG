using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardButton : MonoBehaviour
{
    [SerializeField] private GameObject _cardPanel;
    [SerializeField] private GameObject _costObj;
    [SerializeField] private List<ChoicePosition> _cards;

    public int CardValue; 
    public int Cost;
    public Sprite Icon;

    [SerializeField] Image _image;

    public void StartShop()
    {
        _image.enabled = true;
        _costObj.SetActive(true);

        _costObj.GetComponent<Text>().text = Cost.ToString();
        _image.sprite = Icon;
        if (Icon == null)
        {
            _image.enabled = false;
            _costObj.SetActive(false);
            _image.sprite = null;
        }
    }

    public void BuyCard()
    {
        if (_image.sprite != null)
        {
            foreach (ChoicePosition card in _cards)
            {
                card.Cardvalue = CardValue;
                card.Cost = Cost;
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
