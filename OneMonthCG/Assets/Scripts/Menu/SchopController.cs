using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class SchopController : MonoBehaviour
{
    [SerializeField] private List<CardButton> _cardButtons;
    [SerializeField] private List<CardInfo> _cardInfo;
    [SerializeField] private Text _timer;

    private void Start()
    {
        StartCoroutine(Timer());

        int level = PlayerPrefs.GetInt("Level");
        if (level != 0)
        {
            foreach (CardButton card in _cardButtons)
            {
                int i = Random.Range(0, _cardInfo.Count);
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
        else
        {
            CardButton card = _cardButtons[0];
            int i = Random.Range(3, 6);
            card.Icon = _cardInfo[i].icon;
            card.CardValue = i;
            i -= 1;
            card.Cost = ((i / 3) * 50) * 3;
            card.Cost = card.Cost == 0 ? 50 : card.Cost;
            card.StartShop();
        }
    }

    public void Redresh()
    {
        int money = PlayerPrefs.GetInt("Money");

        if (money >= 10)
        {
            GetComponent<ButtonAnim>().AudioClick();
            PlayerPrefs.SetInt("Money",money-10);
            Start();
        }
    }

    private IEnumerator Timer()
    {
        int f = 180;
        while (true)
        {
            yield return new WaitForSeconds(1f);
            f--;
            if (f%60 >=10)
            {
                _timer.text = "(До обновления : " + (f / 60).ToString() + ":" + (f % 60).ToString() + ")";
            }
            else
            {
                _timer.text = "(До обновления : " + (f / 60).ToString() + ":" + "0"+(f % 60).ToString() + ")";
            }
            if (f == 0)
            {
                Start();
                f = 180;
            }
        }
    }
}
