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
    [SerializeField] private GameObject BulletSpawnPoint;
    [SerializeField] private List<Weapon> Weapons = new List<Weapon>();

    [SerializeField] private GameObject SelectedBullet;
    [SerializeField] private GameObject revolverMagPrefab;
    GameObject Bullet;
    float Weapon_distanceX;
    float Weapon_distanceZ;
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
        WeaponPoint.transform.position = new Vector3(this.gameObject.transform.position.x - Weapon_distanceX, WeaponPoint.transform.position.y, this.gameObject.transform.position.z - Weapon_distanceZ);

        if (time >= bulletSpawnTime)
        {
            Bullet = Instantiate(SelectedBullet, BulletSpawnPoint.transform);

            Bullet.GetComponent<Rigidbody>().AddForce(new Vector3(-bulletSpeed, 0, 0));

            StartCoroutine(DestroyGameObject(Bullet, 2));

            time = 0;
        }



        if (Input.GetKey(KeyCode.Space))
        {
          changeWeapon();
        }

       
    }

    void change›ndex(int changeIndex1,int changeIndex2, List<GameObject> collection)
    {
        GameObject temp1 = collection[changeIndex1];
        GameObject temp2 = collection[changeIndex2];

        collection[changeIndex1] = temp2;
        collection[changeIndex2] = temp1;


    }
  public void changeWeapon()
    {
        foreach (var item in Weapons)
        {
            if (_PlayerStats.Player_Year >= item.weaponYear)
            {
               // SelectedWeapon_Prefab = item.Prefab;
                WeaponPoint.GetComponent<MeshFilter>().mesh = item.weaponMesh;
                Weapon_distanceX = item.weaponPosition.x;
                Weapon_distanceZ = item.weaponPosition.z;
                WeaponPoint.localScale=item.weaponScale;
                //   WeaponPoint.transform.position= item.spawnPoint;
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
