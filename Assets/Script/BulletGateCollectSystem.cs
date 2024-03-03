using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BulletGateCollectSystem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI txt_YearCount;
    [SerializeField] private PlayerStats _PlayerStats;
    [SerializeField] private int YearCount;
    [SerializeField] private GameObject BulletGate;
    [SerializeField] private List<GameObject> BulletGateBullets = new List<GameObject>();
    bool isCollect = false;
    [SerializeField] private TextMeshProUGUI txt_PlayerYearCount;
    [SerializeField] private WeaponSystem _WeaponSystem;
    private void Start()
    {
        _WeaponSystem= GameObject.FindGameObjectWithTag("Player").GetComponent<WeaponSystem>();
        _PlayerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        txt_YearCount.text ="+ "+YearCount.ToString();
        
    }
    private void Update()
    {
        if (isCollect == true)
        {
           BulletGateDown();
            
        }
    }
    void BulletGateDown() 
    {
        for (int i = 0; i <= BulletGateBullets.Count-1; i++)
        {
            BulletGateBullets[i].transform.position = Vector3.Lerp(BulletGateBullets[i].transform.position,new Vector3(BulletGateBullets[i].transform.position.x, BulletGateBullets[i].transform.position.y-6f, BulletGateBullets[i].transform.position.z),5 * Time.deltaTime);
        }

    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _PlayerStats.Player_Year += YearCount;
            isCollect = true;
            txt_PlayerYearCount.text = _PlayerStats.Player_Year.ToString();
            _WeaponSystem.changeWeapon();


        }
       
        if (other.CompareTag("BulletGateBullet"))
        {

            BulletGateBullets.Add(other.gameObject);
          
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("BulletGateBullet"))
        {

           
            BulletGateBullets.Remove(other.gameObject);
        }
    }

}
