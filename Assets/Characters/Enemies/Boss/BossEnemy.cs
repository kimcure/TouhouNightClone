using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class BossEnemy : MonoBehaviour
{
    [Header("SpellCard 정보")]
    public SpellCard[] spellCards;

    [Header("탄막 발사 위치")]
    public Transform firePoint;

    [Header("UI 및 사운드")]
    public SpellCardUIController spellCardUI;
    public AudioSource audioSource;

    private int currentIndex = 0;
    private float currentHP;
    private float timer = 0f;
    private float fireTimer = 0f;

    private PatternSlot[] slots;
    private int slotIndex = 0;

    private float spellTimeLimit;
    private float spellTimeElapsed;
    private bool spellActivate = false;

    void Start()
    {
        if (spellCards.Length > 0)
        {
            LoadSpellCard(currentIndex);
        }
    }

    void Update()
    {
        if (!spellActivate || spellCards.Length == 0) return;

        timer += Time.deltaTime;
        fireTimer += Time.deltaTime;
        spellTimeElapsed += Time.deltaTime;

        if (spellTimeElapsed >= spellTimeLimit)
        {
            Debug.Log($"[Boss] {spellCards[currentIndex].spellName} 시간 초과로 스팰 실패");
            EndCurrentSpell();
            return;
        }

        if (slotIndex < slots.Length)
        {
            PatternSlot current = slots[slotIndex];

            if (fireTimer >= current.pattern.fireInterval)
            {
                current.pattern.Fire(firePoint);
                fireTimer = 0f;
            }

            if (timer >= current.startTime + current.duration)
            {
                slotIndex++;
                fireTimer = 0f;
            } else { }
        }
    }

    public void TakeDamage(float damage)
    {
        if (!spellActivate) return;

        currentHP -= damage;
        if (currentHP <= 0)
        {
            Debug.Log($"[Boss] {spellCards[currentIndex].spellName} 클리어");
            EndCurrentSpell();
        }
    }

    private void LoadSpellCard(int index)
    {
        if (index >= spellCards.Length) return;

        SpellCard currentSpell = spellCards[index];

        currentHP = currentSpell.maxHP;
        timer = 0f;
        slotIndex = 0;
        fireTimer = 0f;
        spellTimeElapsed = 0f;

        slots = currentSpell.patternTimeline.slots;
        spellTimeLimit = currentSpell.timeLimit;
        spellActivate = true;

        if (spellCardUI != null)
        {
            spellCardUI.Activate(currentSpell.spellName, currentSpell.timeLimit);
        }

        if (currentSpell.spellBGM != null && audioSource != null)
        {
            audioSource.clip = currentSpell.spellBGM;
            audioSource.Play();
        }

        Debug.Log($"[Boss] {currentSpell.spellName} 시작");
    }

    private void EndCurrentSpell()
    {
        spellActivate = false;

        if (spellCardUI != null)
        {
            spellCardUI.Deactivate();
        }

        currentIndex++;
        if (currentIndex < spellCards.Length)
        {
            LoadSpellCard(currentIndex);
        } else
        {
            Die();
        }
    }

    private void NextSpellCard()
    {
        currentIndex++;
        if (currentIndex < spellCards.Length)
        {
            LoadSpellCard(currentIndex);
        } else
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("[Boss] 사망");
        Destroy(gameObject);
    }
}
