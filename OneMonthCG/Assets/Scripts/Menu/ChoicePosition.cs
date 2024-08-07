using UnityEngine;

public class ChoicePosition : MonoBehaviour
{
    [SerializeField] private int _value;
    [SerializeField] private GameObject _warning;
    [SerializeField] private CardButton _main;

    public int Cardvalue;
    public int Cost;

    public void SavePosition() 
    {
        int cardValue = PlayerPrefs.GetInt(_value.ToString() + "C");
        GameObject[] warnings = GameObject.FindGameObjectsWithTag("Warning");

        foreach (GameObject obj in warnings)
        {
            obj.SetActive(false);
        }
        
        if (cardValue != 0)
        {
            _warning.SetActive(true);
        }
        else
        {
            Buy();
        }
    }

    public void Buy()
    {
        int money = PlayerPrefs.GetInt("Money");
        if (money >= Cost)
        {
            GetComponent<ButtonAnim>().AudioClick();
            money -=Cost;
            PlayerPrefs.SetInt("Money",money);
            PlayerPrefs.SetInt(_value.ToString() + "C", Cardvalue);
            _warning.SetActive(false);
            GameObject.FindGameObjectWithTag("ShopCardPanel").SetActive(false);
            _main.Buy();
        }
    }
}
