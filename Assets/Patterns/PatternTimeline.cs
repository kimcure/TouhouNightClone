using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PatternSlot
{
    public BulletPattern pattern;
    public float startTime;
    public float duration;
}

[CreateAssetMenu(fileName = "PatternTimeline", menuName = "BulletPattern/Timeline")]
public class PatternTimeline : ScriptableObject
{
    public PatternSlot[] slots;
}