using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
   
    [SerializeField] private Transform WeaponPoint;
    [SerializeField] private GameObject SelectedWeapon_Prefab;
    [SerializeField] private PlayerStats _PlayerStats;
    [SerializeField] private List<Weapon> Weapons = new List<Weapon>();
    [SerializeField] private GameObject SelectedBullet;
    float Weapon_distanceX=0;
    float Weapon_distanceZ=0;
    float time = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        changeWeapon();
       
       
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Space))
        {
          changeWeapon();
        }

       
    }

  
    
  public void changeWeapon()
    {
        foreach (var item in Weapons)
        {
            if (_PlayerStats.Player_Year >= item.weaponYear)
            {

                WeaponPoint.GetComponent<MeshFilter>().mesh = item.weaponMesh;
                Weapon_distanceX = item.weaponPosition.x;
                Weapon_distanceZ = item.weaponPosition.z;
                WeaponPoint.localScale=item.weaponScale;
                SelectedBullet = item.Bullet_prefab;
               
                

            }
           
        }
        
    }
   
   
    
}
