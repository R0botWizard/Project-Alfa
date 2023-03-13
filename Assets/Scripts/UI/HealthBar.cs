using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Image _healthBar;
    public void UpdateHealthBar(float maxHP, float currentHP)
    {
        _healthBar.fillAmount = currentHP / maxHP;
    }
}
