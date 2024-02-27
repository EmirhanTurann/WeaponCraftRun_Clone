using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private Transform WeaponPoint;
    [SerializeField] private Weapon SelectedWeapon;
    [SerializeField] private GameObject SelectedWeapon_Prefab;
    [SerializeField] private PlayerStats _PlayerStats;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float bulletSpawnTime;
    bool isShoot = false;
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
        Debug.Log((float)1 / (_PlayerStats.Player_fireRate / 50));
        bulletSpawnTime = (float)1 / (_PlayerStats.Player_fireRate/50);
        if (time >= bulletSpawnTime)
        {
           GameObject Bullet = Instantiate(SelectedWeapon.Bullet_prefab, SelectedWeapon_Prefab.transform.GetChild(0).transform);
            Bullet.GetComponent<Rigidbody>().AddForce(new Vector3(-bulletSpeed, 0,0));
            StartCoroutine(DestroyGameObject(Bullet,2)); 
            time = 0;
        }
       
       

    }


    void changeWeapon()
    {
        SelectedWeapon_Prefab=Instantiate(SelectedWeapon.Prefab,WeaponPoint);
      //  SelectedWeapon.Prefab
    }
   
    IEnumerator DestroyGameObject(GameObject gameobject,float destroyTime) 
    {
        yield return new WaitForSeconds(destroyTime);
        Destroy(gameobject);

    }
}
