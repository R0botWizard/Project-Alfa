using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoBar : MonoBehaviour
{
    [SerializeField] Image _ammoBar;
    [SerializeField] Text _ammoMax;
    private Color color;

    public void UpdateAmmoBar(float ammo, float currentAmmo, float maxAmmo, Weapon.Energy type)
    {
        if(type == Weapon.Energy.Blu)
        {
            ColorUtility.TryParseHtmlString("#2A8DEB", out color);
        }
        if(type == Weapon.Energy.Red)
        {
            ColorUtility.TryParseHtmlString("#781212", out color);
        }
        _ammoBar.color = color;
        _ammoBar.fillAmount = currentAmmo / ammo;
        _ammoMax.text = maxAmmo + "";
    }

    public void UpdateReloadStatus(bool status)
    {
        if (status)
        {
            _ammoMax.text = "...";
        }
    }
}
