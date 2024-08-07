using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHealth : MonoBehaviour
{
    public GameObject _healthPrefab;
    private List<GameObject> _healthIcons = new List<GameObject>();
    
    public void Setup(int countMaxHealth)
    {
        for (int i = 0; i < countMaxHealth; i++)
        {
            _healthIcons.Add(Instantiate(_healthPrefab, transform));
        }
    }

    public void DisplayHealth(int health)
    {
        for (int i = 0; i < _healthIcons.Count; i++)
        {
            if (i < health)
            {
                _healthIcons[i].SetActive(true);
            }
            else
            {
                _healthIcons[i].SetActive(false);
            }
        }
    }
}
