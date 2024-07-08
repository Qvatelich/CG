using UnityEngine;
using System.Collections.Generic;

public class SchopController : MonoBehaviour
{
    [SerializeField] private List<CardButton> _cardButtons;
    [SerializeField] private List<CardInfo> _cardInfo;

    public void Start()
    {
        foreach (CardButton card in _cardButtons)
        {
            int i = Random.Range(0,_cardInfo.Count);
            if (i != 0)
            {
                card.Icon = _cardInfo[i].icon;
                card.CardValue = i;
                i -= 1;
                card.Cost = ((i / 3) * 50) * 3;
                card.Cost = card.Cost == 0 ? 50 : card.Cost;
                card.StartShop();
            }
            else
            {
                card.Icon = null;
            }
        }
    }
}
