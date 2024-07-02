using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private AIController _AI;
    [SerializeField] private Image _cubImage;
    [SerializeField] private GameObject _yourMotionObject;
    [SerializeField] private GameObject _notYourMotionObject;
    [SerializeField] private Animator _cubAnim;
    [SerializeField] List<CardInfo> _cardsInfo;

    private const float _time = 2.5f;
    private bool _isUpSpeed;

    public List<Sprite> _cubVar;
    public List<Card> currentEnemy;
    public List<Card> cards;
    public int cubValue;
    public int currentEnemyValue = 0;
    public bool isMotion = true;

    public void Start()
    {
        int oneCard = PlayerPrefs.GetInt("OneC");
        int twoCard = PlayerPrefs.GetInt("TwoC");
        int threeCard = PlayerPrefs.GetInt("ThreeC");
        int fourCard = PlayerPrefs.GetInt("FourC");

        int[] cardValues = new int[4] { oneCard, twoCard, threeCard, fourCard };
        for(int i = 0; i < cards.Count; i++)
        {
            cards[i].info = _cardsInfo[cardValues[i]];
            cards[i].CardStart();
        }
        _AI.StartAi();
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

    public void CubClick()
    {
        if (isMotion)
        {
            Motion();
            StartCoroutine(Ai());
        }

        /*foreach (Card item in cards)
        {
            if (currentEnemyValue < cards.Count && currentEnemyValue >= 0)
            {
                item.CurrentEnemy = currentEnemy[currentEnemyValue];
            }
        }*/
    }

    private void Motion()
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
                item.Motion(cubValue-1);
                break;
            }
        }
    }

    public IEnumerator Ai()
    {
        if (_isUpSpeed)
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
        if (_yourMotionObject != null && _cubAnim != null)
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
