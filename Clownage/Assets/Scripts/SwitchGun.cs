using UnityEngine;
using UnityEngine.InputSystem;

public class SwitchGun : MonoBehaviour
{
    public int SelectedWeapon = 0;
    private StarterAssets.StarterAssetsInputs _input;
    // Start is called before the first frame update
    void Start()
    {
        _input = GetComponentInParent<StarterAssets.StarterAssetsInputs>();
        Select();
    }

    // Update is called once per frame
    void Update()
    {
        if (_input.switchWeapon && !_input.reload)
        {
            SelectedWeapon++;
            if (SelectedWeapon >= transform.childCount)
            {
                SelectedWeapon = 0;
            }
        }
        _input.switchWeapon = false;
        Select();
    }
    
    void Select()
    {   
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == SelectedWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }
}
