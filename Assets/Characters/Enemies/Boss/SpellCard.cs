using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpellCard", menuName = "Boss/SpellCard")]
public class SpellCard : ScriptableObject
{
    public string spellName;
    public float maxHP;
    public float duration;
    public PatternTimeline patternTimeline;
    public float timeLimit = 30f;
    public AudioClip spellBGM;
}
