using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
   
    [SerializeField] private Transform WeaponPoint;
    [SerializeField] private Weapon SelectedWeapon;
    [SerializeField] private GameObject SelectedWeapon_Prefab;
    [SerializeField] private PlayerStats _PlayerStats;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float bulletSpawnTime;
    [SerializeField] private List<Weapon> Weapons = new List<Weapon>();
    [SerializeField] private GameObject SelectedBullet;

    float time = 0;

    // Start is called before the first frame update
    void Start()
    {
        changeWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        bulletSpeed = _PlayerStats.Player_fireRate;
        bulletSpawnTime = (float)1 / (_PlayerStats.Player_fireRate/50);
        if (time >= bulletSpawnTime)
        {
           GameObject Bullet = Instantiate(SelectedBullet, WeaponPoint.transform.GetChild(0).transform);
            Bullet.GetComponent<Rigidbody>().AddForce(new Vector3(-bulletSpeed, 0,0));
            StartCoroutine(DestroyGameObject(Bullet,2)); 
            time = 0;
        }
       
       

    }

    void changeWeapon()
    {
        foreach (var item in Weapons)
        {
            if (_PlayerStats.Player_Year >= item.weaponYear)
            {
               // SelectedWeapon_Prefab = item.Prefab;
                WeaponPoint.GetComponent<MeshFilter>().mesh = item.weaponMesh;
                WeaponPoint.transform.position= item.spawnPoint;
                SelectedBullet = item.Bullet_prefab;
            }
           
        }
    }
   
    IEnumerator DestroyGameObject(GameObject gameobject,float destroyTime) 
    {
        yield return new WaitForSeconds(destroyTime);
        Destroy(gameobject);

    }
}
