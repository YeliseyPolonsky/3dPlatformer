using UnityEngine;

public class PlayerArmory : MonoBehaviour
{
    [SerializeField] private AudioSource _pickUpBulletLoot;
    
    [SerializeField] private Gun[] _guns;
    [SerializeField] private int _currentIndex;
    
    void Start()
    {
        SetGun(_currentIndex);
    }

    public void SetGun(int index)
    {
        _currentIndex = index;
        
        for (int i = 0; i < _guns.Length; i++)
        {
            if (i == index)
            {
                _guns[i].Activate();
            }
            else
            {
                _guns[i].DisActivate();
            }    
        }
    }

    public void AddBullets(int indexOfGun, int bulletsCount)
    {
        _guns[indexOfGun].AddBullets(bulletsCount);
        _pickUpBulletLoot.Play();
    }
}
