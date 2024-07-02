using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] private int _money;
    [SerializeField] private Text _moneyText;

    private void Start()
    {
        _money = PlayerPrefs.GetInt("Money");

        if (_money == 0 && PlayerPrefs.GetInt("FirstStart") == 0)
        {
            _money = 150;
            PlayerPrefs.SetInt("Money",_money);
        }

        _moneyText.text = _money.ToString();
    }

    public void BuyCard()
    {

    }

    private void CheckPosition()
    {

    }
}
