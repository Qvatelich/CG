using System.Collections.Generic;
using UnityEngine;

public class CardButton : MonoBehaviour
{
    [SerializeField] private GameObject _cardPanel;
    [SerializeField] private List<�hoicePosition> _cards;

    [SerializeField] private int _cardValue;
    [SerializeField] private int _cost;


    public void BuyCard()
    {
        foreach (�hoicePosition card in _cards)
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
