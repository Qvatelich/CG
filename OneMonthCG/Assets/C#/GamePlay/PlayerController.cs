using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerController _AI;
    [SerializeField] private List<Sprite> _cubVar;
    [SerializeField] private Image _cubImage;
    [SerializeField] private GameObject _yourMotionObject;
    [SerializeField] private GameObject _notYourMotionObject;
    [SerializeField] private Animator _cubAnim;

    public List<Card> currentEnemy;
    public List<Card> cards;
    public int cubValue;
    public int currentEnemyValue;
    public bool isMotion = true;

    private void Start()
    {       
        currentEnemy = _AI.cards;
        CurrentEnemyCheck();
    }

    private void CurrentEnemyCheck()
    {
        foreach (Card item in cards)
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

    public void CubClick()
    {
        if (isMotion)
        {
            Motion();
            StartCoroutine(Ai());
        }

        foreach (Card item in cards)
        {
            item.CurrentEnemy = currentEnemy[currentEnemyValue];
        }
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
            item.CurrentEnemy = currentEnemy[currentEnemyValue];
        }
    }

    private void CardMotion()
    {
        foreach (Card item in cards)
        {
            if (item.hp > 0)
            {
                item.Motion(cubValue-1);
                break;
            }
        }
    }

    public IEnumerator Ai()
    {
        ChekMotion(true);
        yield return new WaitForSeconds(2.5f);
        ChekMotion(false);
        _AI.isMotion = true;
        _AI.Motion();
        yield return new WaitForSeconds(2.5f);
        isMotion = true;
        ChekMotion(true);
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
}
