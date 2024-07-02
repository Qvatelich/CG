using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField] private GameObject _hpPlusEfect;
    [SerializeField] private GameObject _hpMinusEfect;

    public Text _hpText;
    private int _maxHp;
    private Image _sprite;

    public CardInfo info;
    public int _hp;
    private int _armor;
    public Card CurrentEnemy;
    public PlayerController Pcontroller;
    public AIController Acontroller;

    public void CardStart()
    {
        _maxHp = info == null ? 0 : info.hp;
        if (info == null)
        {
            gameObject.SetActive(false);
        }
        else
        {
            _hp = info.hp;
            _hpText = GetComponentInChildren<Text>();
            _sprite = GetComponent<Image>();
            _sprite.sprite = info.icon;
            _hpText.text = _hp.ToString();
        }
    }

    public void HpChange(int value)
    {
        _hp+= value;
    }

    public void Motion(int value) 
    {
        if (info.hpPlus[value] != 0 && _hp + info.hpPlus[value] <= _maxHp)
        {
            _hp += info.hpPlus[value];
            Instantiate(_hpPlusEfect, new Vector2(transform.position.x, transform.position.y + 2.25f), Quaternion.identity);
        }
        if (info.damage[value] != 0) 
        {
            CurrentEnemy._hp -= info.damage[value];
            Instantiate(_hpMinusEfect, new Vector2(CurrentEnemy.transform.position.x, CurrentEnemy.transform.position.y + 2.25f), Quaternion.identity);
        }
        _hpText.text = _hp.ToString();
        CurrentEnemy._hpText.text = CurrentEnemy._hp.ToString();
        HpCheck();
    }

    private void HpCheck()
    {
        if (CurrentEnemy._hp <= 0)
        {
            CurrentEnemy.gameObject.SetActive(false);
            CurrentEnemy.info = null;
            if (Acontroller == null)
            {
                Pcontroller.CurrentEnemyCheck();
            }
            else
            {
                Acontroller.CurrentEnemyCheck();
            }
        }
    }
}
