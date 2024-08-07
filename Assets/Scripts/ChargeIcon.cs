using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChargeIcon : MonoBehaviour
{
    [SerializeField] private Image _foregroundImage;
    [SerializeField] private Image _backgroundImage;
    [SerializeField] private TMP_Text _text;

    public void StartCharge()
    {
        _backgroundImage.color = new Color(1, 1, 1, 0.1f);
        _foregroundImage.enabled = true;
        _text.enabled = true;
    }

    public void StopCharge()
    {
        _backgroundImage.color = Color.white;
        _foregroundImage.enabled = false;
        _text.enabled = false;
    }

    public void ChangeIcon(float currentCharge,float maxCharge)
    {
        _text.text = Mathf.Ceil(currentCharge / maxCharge * 3).ToString();
        _foregroundImage.fillAmount = currentCharge / maxCharge;
    }
}
