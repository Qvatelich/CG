using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "card")]
public class CardInfo : ScriptableObject
{
    public int hp;
    public Sprite icon;

    public List<int> damage;
    public List<int> hpPlus;
}