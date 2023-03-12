using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoBar : MonoBehaviour
{
    [SerializeField] Image _ammoBar;
    [SerializeField] Text _ammoMax;

    public void UpdateAmmoBar(float ammo, float currentAmmo, float maxAmmo)
    {
        _ammoBar.fillAmount = currentAmmo / ammo;
        _ammoMax.text = maxAmmo + "";
    }
}
