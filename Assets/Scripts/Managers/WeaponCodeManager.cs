using Nightmare;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WeaponCodeManager : MonoBehaviour
{
    int weapon;
    int currentWeapon;
    WeaponManager weaponManager;
    Animator anim;
    public TMP_Text weaponText;

    void Awake()
    {
        Debug.Log(weaponText.text);
        weaponManager = FindObjectOfType<WeaponManager>();
        weapon = weaponManager.selectedWeapon;
        anim = GameObject.Find("HUDCanvas").GetComponent<Animator>();
        Debug.Log(weapon.ToString());
    }

    void Update()
    {
        currentWeapon = weaponManager.selectedWeapon;
        if (currentWeapon != weapon)
        {
            weapon = currentWeapon;
            PlayClip();
        }
    }

    void PlayClip()
    {
        if (weapon == 0)
        {
            weaponText.text = "Burst Gun";
        }
        else if (weapon == 1)
        {
            weaponText.text = "Shot Gun";
        }
        else if (weapon == 2)
        {
            weaponText.text = "Sword";
        }
        anim.SetTrigger("Weapon");
    }
}
