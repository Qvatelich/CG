using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoPanel : MonoBehaviour
{
    [SerializeField] private List<Text> _hp;
    [SerializeField] private List<Text> _damage;
    [SerializeField] private CardInfo _info;
    [SerializeField] private Text _HP;

    private void Start()
    {
        _HP.text = _info.hp.ToString();
        for (int i = 0; i < _hp.Count; i++)
        {
            if (_info.hpPlus[i] > 0)
            {
                _hp[i].text = "+" + _info.hpPlus[i].ToString();
            }
            else if (_info.hpPlus[i] == 0)     
            {
                Transform transform = _hp[i].transform.parent;
                transform.gameObject.SetActive(false);
            }
            else
            {
                _hp[i].text = "-" + _info.hpPlus[i].ToString();
            }
        }
        for (int i = 0; i < _damage.Count; i++)
        {
            if (_info.damage[i] > 0)
            {
                _damage[i].text = _info.damage[i].ToString();
            }
            else if (_info.damage[i] == 0)
            {
                Transform transform = _damage[i].transform.parent;
                transform.gameObject.SetActive(false);
            }
        }
    }

    public void ExitPanel()
    {
        gameObject.SetActive(false);
    }
}
