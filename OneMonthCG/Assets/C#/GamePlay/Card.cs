using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField] private GameObject _hpPlusEfect;
    [SerializeField] private GameObject _hpMinusEfect;

    private Text _hpText;
    private Image _sprite;

    public CardInfo info;
    public int hp;
    public int armor;
    public Card CurrentEnemy;
    public PlayerController controller;

    private void Awake()
    {
        if (info == null)
        {
            gameObject.SetActive(false);
        }
        else
        {
            hp = info.hp;
            _hpText = GetComponentInChildren<Text>();
            _sprite = GetComponent<Image>();
            _sprite.sprite = info.icon;
        }
    }

    public void Motion(int value) 
    {
        if (info.hpPlus[value] != 0)
        {
            hp += info.hpPlus[value];
            Instantiate(_hpPlusEfect, new Vector2(transform.position.x, transform.position.y + 2.25f), Quaternion.identity);
        }
        if (info.damage[value] != 0) 
        {
            CurrentEnemy.hp -= info.damage[value];
            Instantiate(_hpMinusEfect, new Vector2(CurrentEnemy.transform.position.x, CurrentEnemy.transform.position.y + 2.25f), Quaternion.identity);
        }
        HpCheck();
    }

    private void HpCheck()
    {
        if (CurrentEnemy.hp <= 0)
        {
            CurrentEnemy.gameObject.SetActive(false);
            for(int i = 0; i < controller.currentEnemy.Count;i++)
            {
                if (controller.currentEnemy[i] == CurrentEnemy)
                {
                    if (i +1 < controller.currentEnemy.Count)
                    {
                        controller.currentEnemyValue = i + 1;
                    }
                    else
                    {
                        SceneManager.LoadScene(1);
                    }
                }
            }
        }
    }

    private void Update()
    {
        _hpText.text = hp.ToString();
    }
}
