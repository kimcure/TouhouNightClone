using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpellCardCutin : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public TextMeshProUGUI spellNameText;
    public Image resultImage;
    public Sprite successSprite;
    public Sprite failSprite;

    public float displayDuration = 2f;

    public void ShowCutin(string spellName, bool success)
    {
        StopAllCoroutines();
        StartCoroutine(PlayCutin(spellName, success));
    }

    private IEnumerator PlayCutin(string name, bool success)
    {
        spellNameText.text = name;
        resultImage.sprite = success ? successSprite : failSprite;

        canvasGroup.alpha = 0;
        canvasGroup.gameObject.SetActive(true);

        for (float t = 0; t < 0.5f; t += Time.deltaTime)
        {
            canvasGroup.alpha = t / 0.5f;
            yield return null;
        }
        canvasGroup.alpha = 1f;

        yield return new WaitForSeconds(displayDuration);


        for (float t = 0; t < 0.5f; t += Time.deltaTime)
        {
            canvasGroup.alpha = 1f - t / 0.5f;
            yield return null;
        }

        canvasGroup.alpha = 0f;
        canvasGroup.gameObject.SetActive(false);
    }
}
