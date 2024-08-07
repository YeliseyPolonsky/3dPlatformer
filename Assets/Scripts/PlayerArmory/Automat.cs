using TMPro;
using UnityEngine;

public class Automat : Gun
{
    [Header("Automat")]
    [SerializeField] private PlayerArmory _playerArmory;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private int _countBullet;

    public override void Shot()
    {
        base.Shot();
        _countBullet--;
        UpdateText();
        
        if(_countBullet <= 0)
            _playerArmory.SetGun(0);
    }

    public override void Activate()
    {
        base.Activate();
        _text.enabled = true;
        UpdateText();
    }

    public override void DisActivate()
    {
        base.DisActivate();
        _text.enabled = false;
    }

    private void UpdateText()
    {
        _text.text = _countBullet.ToString();
    }

    public override void AddBullets(int count)
    {
        _countBullet += count;
        UpdateText();
        
        _playerArmory.SetGun(1);
    }
}