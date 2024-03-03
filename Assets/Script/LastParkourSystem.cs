using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LastParkourSystem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI txt_Count;
    [SerializeField] private int Count;
    [SerializeField] private Animator _Animator;
    private void Start()
    {
        _Animator = GetComponent<Animator>();
        txt_Count = this.gameObject.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        txt_Count.text = Count.ToString();
        

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            other.gameObject.SetActive(false);
            Count--;
            txt_Count.text= Count.ToString();
            _Animator.SetTrigger("LastParkourHit");

            if (Count<=0)
            {
                this.gameObject.SetActive(false);
            }
        }
        if (other.CompareTag("Player"))
        {
            other.transform.GetChild(0).gameObject.GetComponent<Animator>().SetTrigger("isDead");
            other.gameObject.GetComponent<PlayerMovement>().enabled = false;
        }
    }
}
