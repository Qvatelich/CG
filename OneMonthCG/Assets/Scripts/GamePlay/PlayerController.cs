using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private AIController _AI;
    [SerializeField] private Image _cubImage;
    [SerializeField] private Text _levelCount;
    [SerializeField] private Text _moneyInLevel;
    [SerializeField] private GameObject _yourMotionObject;
    [SerializeField] private GameObject _notYourMotionObject;
    [SerializeField] private GameObject _win;
    [SerializeField] private GameObject _cubAudio;
    [SerializeField] private Animator _cubAnim;
    [SerializeField] private GameObject _winAudio;

    private const float _time = 2.5f;
    private bool _isUpSpeed;

    public List<CardInfo> CardsInfo;
    public List<Sprite> _cubVar;
    public List<Card> currentEnemy;
    public List<Card> cards;
    public int cubValue;
    public int currentEnemyValue = 0;
    public bool isMotion = true;

    public void Start()
    {
        int level = PlayerPrefs.GetInt("Level");
        level = level == 0 ? 1 : level;
        PlayerPrefs.SetInt("Level",level);
        _levelCount.text = "Уровень: " + PlayerPrefs.GetInt("Level").ToString();
        for (int i = 0; i < cards.Count; i++)
        {
            int id = PlayerPrefs.GetInt((i+1).ToString() + "C");
            cards[cards.Count-1 - i].info = CardsInfo[id];
            cards[cards.Count-1 - i].CardStart();
        }
        _AI.StartAi();
    }

    public void CurrentEnemyCheck()
    {
        if (currentEnemyValue >= cards.Count)
        {
            Instantiate(_winAudio);
            PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level")+1);
            StopAllCoroutines();

            int money = PlayerPrefs.GetInt("MoneyInLevel");
            int newMoney = Random.Range(PlayerPrefs.GetInt("Level")+1,PlayerPrefs.GetInt("Level")+11 );

            _moneyInLevel.text = "полученные монеты: " + money.ToString() + "+" + newMoney.ToString();

            PlayerPrefs.SetInt("MoneyInLevel",money + newMoney);
            _win.SetActive(true);
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

    public void CubClick()
    {
        if (isMotion && !_win.activeSelf)
        {
            Motion();
            StartCoroutine(Ai());
        }
        if (_win.activeSelf)
        {
            _cubAnim.GetComponent<Animator>().enabled = false;
        }
    }

    private void Motion()
    {
        if (isMotion)
        {
            GameObject _audio = Instantiate(_cubAudio);
            Destroy(_audio,2f);

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
                item.Motion(cubValue-1);
                break;
            }
        }
    }

    public IEnumerator Ai()
    {
        if (_isUpSpeed&&!_win.activeSelf)
        {
            float speed = 0.35f;
            ChekMotion(true);
            yield return new WaitForSeconds(_time* speed);
            ChekMotion(false);
            _AI.isMotion = true;
            _AI.Motion();
            yield return new WaitForSeconds(_time * speed);
            isMotion = true;
            ChekMotion(true);
            CubClick();
        }
        else
        {
            ChekMotion(true);
            yield return new WaitForSeconds(_time);
            ChekMotion(false);
            _AI.isMotion = true;
            _AI.Motion();
            yield return new WaitForSeconds(_time);
            isMotion = true;
            ChekMotion(true);
        }
    }
    private void ChekMotion(bool f)
    {
        if (_yourMotionObject != null && _cubAnim != null && !_win.activeSelf)
        {
            _cubAnim.GetComponent<Animator>().enabled = isMotion;
            _yourMotionObject.SetActive(f);
            _notYourMotionObject.SetActive(!f);
        }
    }

    public void SpeedUpClick()
    {
        _isUpSpeed = !_isUpSpeed;
    }
}
