using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class SpellCardManager : MonoBehaviour
{
    public SpellCardCutin cutin;

    public int successBonusScore = 50000;

    public void PlaySuccess(string spellName)
    {
        cutin.ShowCutin(spellName, true);
        ScoreManager.Instance.AddScore(successBonusScore);
    }

    public void PlayFail(string spellName)
    {
        cutin.ShowCutin(spellName, false);
    }
}
