using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] private int _money;
    [SerializeField] private Text _moneyText;
    [SerializeField] private Slider _audioVolume;

    private void Start()
    {
       // PlayerPrefs.DeleteAll();

        _money = PlayerPrefs.GetInt("Money");

        if (_money == 0 && PlayerPrefs.GetInt("FirstStart") == 0)
        {
            PlayerPrefs.SetInt("FirstStart",1);
            _money = 150;
            PlayerPrefs.SetInt("Money",_money);
        }
    }

    private void Update()
    {
        AudioListener.volume = _audioVolume.value;
        _money = PlayerPrefs.GetInt("Money");
        _moneyText.text = _money.ToString();
    }
}
