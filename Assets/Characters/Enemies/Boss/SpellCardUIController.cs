using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpellCardUIController : MonoBehaviour
{
    public TMP_Text spellNameText;
    public Slider timerSlider;

    private float maxTime;
    private float currentTime;
    private bool isActive = false;

    public void Activate(string spellName, float duration)
    {
        spellNameText.text = spellName;
        maxTime = duration;
        currentTime = duration;
        timerSlider.maxValue = maxTime;
        timerSlider.value = maxTime;
        isActive = true;

        gameObject.SetActive(true);
    }


    public void Deactivate()
    {
        isActive = false;
        gameObject.SetActive(false);
    }

    void Update()
    {
        if (!isActive) return;

        currentTime -= Time.deltaTime;
        timerSlider.value = currentTime;

        if (currentTime <= 0)
        {
            Deactivate();
        }
    }

    public float GetRemainingTime()
    {
        return currentTime;
    }
}
