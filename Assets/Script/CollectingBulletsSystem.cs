using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectingBulletsSystem : MonoBehaviour
{
    public int BulletCount = 0;
    private int BulletCountMax = 6;
    private float offsety;
    [SerializeField] private Material BandPath_Mat;
    [SerializeField] private Transform Band;
    [SerializeField] private Transform Basket;
    [SerializeField] private bool isHitPlayer = false;
    [SerializeField]  private Transform MagParent;
    bool OnBand = false;


    private void Update()
    {
        offsety += Time.deltaTime;
        BandPath_Mat.mainTextureOffset = new Vector2(0, -offsety);

        if (BulletCount == BulletCountMax || isHitPlayer==true)
        {
            PutMagazineOnBand();
            
        }
        if (OnBand == true)
        {
            GoMagOnBand();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            other.gameObject.SetActive(false);
            //Destroy(other.gameObject);
            if (BulletCount < BulletCountMax)
            {
              BulletCount++;
                this.gameObject.transform.GetChild(BulletCount).gameObject.SetActive(true);
                this.gameObject.transform.GetChild(BulletCount).GetComponent<MeshFilter>().mesh=other.GetComponent<MeshFilter>().mesh;
            }
        }
        if (other.CompareTag("Player"))
        {
            isHitPlayer = true;
        }
        if (other.CompareTag("BackCollider"))
        {
            isHitPlayer = true;
        }
        if (other.CompareTag("Band"))
        {
            OnBand = true;
        }
        
    }

    void PutMagazineOnBand()
    {
        MagParent = transform.parent;
        MagParent.position = Vector3.Lerp(MagParent.position,new Vector3(MagParent.position.x,0.75f, Band.position.z),3*Time.deltaTime);
        //GetComponent<Animator>().SetBool("RotateMag", false);
        GetComponent<Animator>().SetBool("RotateMag",false);
        

    }

    void GoMagOnBand()
    {
        if (MagParent!=null)
        {
          
            MagParent.transform.position = Vector3.Lerp(MagParent.position, new Vector3(Basket.position.x, MagParent.position.y, MagParent.position.z), 1f * Time.deltaTime); 
        }
    
    }
}
