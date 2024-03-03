using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPoolingSystem : MonoBehaviour
{
    [SerializeField] private GameObject BulletPrefab;
    [SerializeField] private GameObject BulletSpawnPoint;
    [SerializeField] private List<GameObject> Bullets = new List<GameObject>();
    [SerializeField] private int MaxBulletCount;
    [SerializeField] private bool isFire = false;
    private float time = 0;
    [SerializeField] private float FireTime = 0;
    [SerializeField] private PlayerStats _PlayerStats;
    [SerializeField] private GameObject BulletWall;


    private void Start()
    {
        _PlayerStats = GetComponent<PlayerStats>();

        updateStats();


    }
    private void Update()
    {
        
        time += Time.deltaTime;

        if (time > FireTime)
        {
            isFire = true;
            time = 0;
        }
        if (Bullets.Count < MaxBulletCount)
        {
            GameObject spawnBullet;
            spawnBullet = Instantiate(BulletPrefab, BulletSpawnPoint.transform);
            Bullets.Add(spawnBullet);

            spawnBullet.SetActive(false);


        }
        if (isFire)
        {
            for (int i = 0; i <= Bullets.Count - 1; i++)
            {
                if (!Bullets[i].activeInHierarchy)
                {
                    Bullets[i].transform.position = BulletSpawnPoint.transform.position;
                    Bullets[i].SetActive(true);
                  

                    break;
                }

            }
            isFire = false;

        }
        



    }

    public void updateStats() 
    {

        FireTime -= (float)_PlayerStats.Player_fireRate / 1000;
        BulletWall.transform.position = new Vector3(BulletWall.transform.position.x - (float)_PlayerStats.Player_fireRange / 10, BulletWall.transform.position.y, BulletWall.transform.position.z);
    }
}
 


