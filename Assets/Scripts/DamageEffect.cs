using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DamageEffect : MonoBehaviour
{
    public Image _DamageImage;

    public void ShowEffect() => StartCoroutine(Effect());

    private IEnumerator Effect()
    {
        _DamageImage.enabled = true;

        for (float t = 1; t > 0; t -= Time.deltaTime)
        {
            _DamageImage.color = new Color(1, 0, 0, t);
            yield return null;
        }

        _DamageImage.enabled = false;
    }
}