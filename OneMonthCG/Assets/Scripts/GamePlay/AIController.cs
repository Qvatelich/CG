using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AIController : MonoBehaviour
{

    [SerializeField] private PlayerController _player;
    [SerializeField] private List<Sprite> _cubVar;
    [SerializeField] private Image _cubImage;
    [SerializeField] List<CardInfo> _cardsInfo;

    public bool isMotion = true;
    public List<Card> currentEnemy;
    public List<Card> cards;
    public int cubValue;
    public int currentEnemyValue = 0;
    public void StartAi()
    {
        _cubVar = _player._cubVar;
        foreach (var card in cards)
        {
            int i = Random.Range(0, _cardsInfo.Count);
            card.info = _cardsInfo[i];
            card.CardStart();
        }
        currentEnemy = _player.cards;
        CurrentEnemyCheck();
        _player.currentEnemy = cards;
        _player.CurrentEnemyCheck();
    }

    public void Motion()
    {
        if (isMotion)
        {
            cubValue = Random.Range(1, 7);
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
            SceneManager.LoadScene(1);
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
