using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardsPanel : MonoBehaviour
{
    [SerializeField] List<Sprite> _cardsVar;
    [SerializeField] List<Image> _cards;

    public void Start()
    {
        for (int i = 0; i < _cards.Count; i++)
        {
            Debug.Log((i + 1).ToString() + "C");
            int value = PlayerPrefs.GetInt((i+1).ToString()+"C");
            _cards[i].sprite = _cardsVar[value];
        }
    }
}
