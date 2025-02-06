using System.Data;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class WeaponManager : MonoBehaviour
{
    // Este Script se encarga de manejar las armas del jugador y de activarlas
    [Header("Weapon Settings")]
    public GameObject weapon;
    public Transform weaponParent;

    [Header("Ammo Settings")]
    public int maxAmmoGun;
    public int currentAmmoGun = 10;
    public int maxAmmoShotgun;
    public int currentAmmoShotgun = 0;

    [Header("Weapon UI")]
    public TextMeshProUGUI ammoText; // Texto que muestra la cantidad de municion del arma actual

    private int currentWeapon = 0; // Indice del arma actual
    

    /*
    === Lista de armas y sus indices ===
        0 - Ninguna
        1 - Pistola
        2 - Escopeta
    */


    void Start(){
        if(weapon != null){
            weapon = Instantiate(weapon, weaponParent);
            currentWeapon = weapon.GetComponent<Gun>().typeGun;
        }

        UpdateUI();
    }


    private void UpdateUI(){
        switch(currentWeapon){
            case 1:
                ammoText.text = currentAmmoGun + " / " + maxAmmoGun;
                break;
            case 2:
                ammoText.text = currentAmmoShotgun + " / " + maxAmmoShotgun;
                break;
            default:
                ammoText.text = "Infinite";
                break;
        }
    }

    public void ChangeCurrentWeapon(GameObject newWeapon){
        Destroy(weapon);
        weapon = Instantiate(newWeapon, weaponParent);
        currentWeapon = weapon.GetComponent<Gun>().typeGun;

        UpdateUI();
    }


    public void OnAttack(InputAction.CallbackContext context){
        if(context.performed && currentAmmoGun > 0){
            if(weapon.GetComponent<Gun>().Shot()){
                Debug.Log("Disparo");
                ReduceCurrentAmmo(1);
                UpdateUI();
            }
        }
    }

    private void ReduceCurrentAmmo(int changedAmmo){
        switch(currentWeapon){
            case 1:
                currentAmmoGun -= changedAmmo;
                break;
            case 2:
                currentAmmoShotgun -= changedAmmo;
                break;
            default:
                return;
        }
        UpdateUI();
    }


    



}
