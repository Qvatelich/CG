using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AIController : MonoBehaviour
{

    [SerializeField] private PlayerController _player;
    [SerializeField] private List<Sprite> _cubVar;
    [SerializeField] private Image _cubImage;
    [SerializeField] private List<CardInfo> _cardsInfo;
    [SerializeField] private GameObject _endGame;
    [SerializeField] private GameObject _cubAudio;

    private int _level;

    public bool isMotion = true;
    public List<Card> currentEnemy;
    public List<Card> cards;
    public int cubValue;
    public int currentEnemyValue = 0;
    public void StartAi()
    {
        _cubVar = _player._cubVar;
        _cardsInfo = _player.CardsInfo;

        _level = PlayerPrefs.GetInt("Level");

        CreateDeck();

        currentEnemy = _player.cards;
        CurrentEnemyCheck();
        _player.currentEnemy = cards;
        _player.CurrentEnemyCheck();
    }

    private void CreateDeck()
    {
        if (_level <= 10)
        {
            int value = 0;
            foreach (var card in cards)
            {
                int i = Random.Range(0, 4);
                card.info = _cardsInfo[i];
                if (i != 0)
                {
                    value++;
                }
                card.CardStart();
            }
            if (value == 4 || value == 0)
            {
                CreateDeck();
            }
        }
        else if (_level > 10 && _level <= 15)
        {
            int r = Random.Range(0, 2);
            if (r == 0)
            {
                int c2 = Random.Range(0, cards.Count);
                for (int i = 0; i < cards.Count; i++)
                {
                    if (i == c2)
                    {
                        int e = Random.Range(4, 7);
                        cards[i].info = _cardsInfo[e];
                    }
                    else
                    {
                        cards[i].info = _cardsInfo[Random.Range(0, 4)];
                    }
                    cards[i].CardStart();
                }
            }
            if (r == 1)
            {
                for (int i = 0; i < cards.Count; i++)
                {
                    cards[i].info = _cardsInfo[Random.Range(1, 4)];
                    cards[i].CardStart();
                }
            }
        }
        else if (_level > 15 && _level <= 20)
        {
            int c2One = Random.Range(0, cards.Count);
            int c2Two = Random.Range(0, cards.Count);
            for (int i = 0; i < cards.Count; i++)
            {
                if (i == c2One || i == c2Two)
                {
                    int e = Random.Range(4, 7);
                    cards[i].info = _cardsInfo[e];
                }
                else
                {
                    cards[i].info = _cardsInfo[Random.Range(0, 4)];
                }
                cards[i].CardStart();
            }
        }
    }

    public void Motion()
    {
        if (isMotion)
        {
            GameObject _audio = Instantiate(_cubAudio);
            Destroy(_audio, 2f);

            cubValue = UnityEngine.Random.Range(1, 7);
            _cubImage.sprite = _cubVar[cubValue - 1];
            isMotion = false;

            CardMotion();
        }

        foreach (Card item in cards)
        {
            if (currentEnemyValue < cards.Count && currentEnemyValue >= 0)
            {
                item.CurrentEnemy = currentEnemy[currentEnemyValue];
            }
        }
    }

    private void CardMotion()
    {
        foreach (Card item in cards)
        {
            if (item._hp > 0)
            {
                item.Motion(cubValue - 1);
                break;
            }
        }
    }

    public void CurrentEnemyCheck()
    {
        if (currentEnemyValue >= cards.Count)
        {
            PlayerPrefs.SetInt("MoneyInLevel",0);
            _endGame.SetActive(true);
            _player.StopAllCoroutines();
            return;
        }
        else if (currentEnemyValue >= 0)
        {
            foreach (Card item in cards)
            {
                if (item.info != null)
                {
                    if (currentEnemy[currentEnemyValue].info != null)
                    {
                        item.CurrentEnemy = currentEnemy[currentEnemyValue];
                    }
                    else
                    {
                        currentEnemyValue++;
                        CurrentEnemyCheck();
                        break;
                    }
                }
            }
        }
    }
}
