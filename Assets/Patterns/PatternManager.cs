using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PatternManager : MonoBehaviour
{
    public PatternTimeline patternTimeline;
    public Transform firePoint;

    private int currentIndex = 0;
    private float globalTimer = 0f;
    private float localTimer = 0f;

    private BulletPattern currentPattern;
    private float nextFireTime;

    private void Start()
    {
        if (patternTimeline == null || patternTimeline.slots.Length == 0 || firePoint == null)
        {
            return;
        }

        currentIndex = 0;
        currentPattern = patternTimeline.slots[0].pattern;
        nextFireTime = patternTimeline.slots[0].startTime;
    }

    private void Update()
    {
        if (patternTimeline == null || patternTimeline.slots.Length == 0 || firePoint == null)
        {
            return;
        }

        globalTimer += Time.deltaTime;
        localTimer += Time.deltaTime;

        if (currentIndex >= patternTimeline.slots.Length)
        {
            return;
        }

        PatternSlot slot = patternTimeline.slots[currentIndex];

        if (globalTimer >= slot.startTime + slot.duration)
        {
            currentIndex++;
            localTimer = 0f;

            if (currentIndex < patternTimeline.slots.Length)
            {
                currentPattern = patternTimeline.slots[currentIndex].pattern;
                nextFireTime = globalTimer + currentPattern.fireInterval;
            }

            return;
        }

        if (globalTimer >= nextFireTime && currentPattern != null)
        {
            currentPattern.Fire(firePoint);
            nextFireTime = globalTimer + currentPattern.fireInterval;
        }
    }
}
