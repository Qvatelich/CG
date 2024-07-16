using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "card")]
public class CardInfo : ScriptableObject
{
    public int hp;
    public Sprite icon;
    public AudioClip damageAudio;
    public AudioClip healingAudio;

    public List<int> damage;
    public List<int> hpPlus;
}