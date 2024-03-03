using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGateSystem : MonoBehaviour
{
    public int bulletsinbasket_Count = 0;
    public bool isBulletAdd = false;
    [SerializeField] private Animator PushMechanismAnimator;
    [SerializeField] private Animator RevolverMagAnimator;
    public int PushCount = 0;
    public GameObject BulletMachine_Bullet;
    public GameObject EnableRevolver;
    public GameObject BulletCorners;
    public Material BulletMachineCornerGreen_Mat;
    [SerializeField] private List<GameObject> Gates = new List<GameObject>();
    private void Update()
    {
       
        if (isBulletAdd == true)
        {
            if (PushCount <= 15 && PushCount < bulletsinbasket_Count / 3)
            {
              
                PushMechanismAnimator.SetTrigger("isPush");

            }



            BulletAdd(PushCount);
        }

        if (PushCount>=5)
        {
            Gates[0].transform.GetChild(0).gameObject.SetActive(true);
            BulletCorners.transform.GetChild(0).GetComponent<Renderer>().material = BulletMachineCornerGreen_Mat;
            BulletCorners.transform.GetChild(1).GetComponent<Renderer>().material = BulletMachineCornerGreen_Mat;
            Gates[0].GetComponent<BoxCollider>().enabled=true;
            
           
        }
         if (PushCount>=10)
        {
            Gates[1].transform.GetChild(0).gameObject.SetActive(true);
            BulletCorners.transform.GetChild(2).GetComponent<Renderer>().material = BulletMachineCornerGreen_Mat;
            Gates[1].GetComponent<BoxCollider>().enabled = true;
        }
         if (PushCount == 15)
        {
            Gates[2].transform.GetChild(0).gameObject.SetActive(true);
            BulletCorners.transform.GetChild(3).GetComponent<Renderer>().material = BulletMachineCornerGreen_Mat;
            Gates[2].GetComponent<BoxCollider>().enabled = true;
        }

    }
    void BulletAdd(int bulletCount) 
    {
        for (int i = 0; i < bulletCount; i++)
        {
            GameObject bullet = transform.GetChild(i).gameObject;
            bullet.SetActive(true);
            bullet.transform.position = Vector3.Lerp(bullet.transform.position, new Vector3(bullet.transform.position.x, bullet.transform.position.y,  transform.position.z + ((bulletsinbasket_Count / 3 - i) * bullet.transform.localScale.z) ), 2 * Time.deltaTime);
        }
    }

  
    IEnumerator DropBullet(Collider other) 
    {

        yield return new WaitForSeconds(1f);
        for (int i = 1; i <= other.GetComponent<CollectingBulletsSystem>().BulletCount; i++)
        {
            other.transform.GetChild(i).GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            other.transform.GetChild(i).GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            other.transform.GetChild(i).GetComponent<Rigidbody>().drag = 5;
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RevolverMag"))
        {
            bulletsinbasket_Count += other.GetComponent<CollectingBulletsSystem>().BulletCount;
            RevolverMagAnimator = other.GetComponent<Animator>();
            isBulletAdd = true;
            if (RevolverMagAnimator != null)
            {
                RevolverMagAnimator.enabled = true;
                RevolverMagAnimator.SetBool("DropBullet", true);
                StartCoroutine( DropBullet(other));


            }
        }
            if (other.CompareTag("PushMechanism"))
        {
            if (PushCount <= 15)
            {
                PushCount++;
                
                //BulletMachine_Bullet.SetActive(true);
            }
          
        }
    }
}
