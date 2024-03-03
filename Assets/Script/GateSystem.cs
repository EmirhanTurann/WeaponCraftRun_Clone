using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class GateSystem : MonoBehaviour
{
    [SerializeField] private GameObject GateFrame;
    [SerializeField] private GameObject GateCounterBackground;
    [SerializeField] private GameObject GateColor;
    [SerializeField] private Material mat_Green;
    [SerializeField] private Material mat_Red;
    [SerializeField] private Sprite GreenFrameSprite;
    [SerializeField] private Sprite RedFrameSprite;
    [SerializeField] private Sprite GreenCounterBackgrounSprite;
    [SerializeField] private Sprite RedCounterBackgrounSprite;

    [SerializeField] private TextMeshProUGUI txt_PlayerYearCount;
    [SerializeField] private TextMeshProUGUI txt_Counter;
    [SerializeField] private TextMeshProUGUI txt_Count;
    [SerializeField] private TextMeshProUGUI txt_Head;
    [SerializeField] private int Counter;
    [SerializeField] private int Count;
    [SerializeField] private PlayerStats _PlayerStats;
    [SerializeField] private WeaponSystem _WeaponSystem;

    [SerializeField] private Animator GateAnimator;
    private GameObject Player;
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        GateFrame = this.gameObject.transform.GetChild(0).GetChild(0).GetChild(0).gameObject;
        GateCounterBackground = this.gameObject.transform.GetChild(0).GetChild(1).GetChild(1).gameObject;
        GateColor = this.gameObject.transform.GetChild(0).GetChild(3).gameObject;
        txt_Count = this.gameObject.transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>();
        txt_Counter = this.gameObject.transform.GetChild(0).GetChild(2).GetChild(1).GetComponent<TextMeshProUGUI>();
        txt_Head = this.gameObject.transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>();
        txt_Count.text = Count.ToString();
        txt_Counter.text = Counter.ToString();
        txt_PlayerYearCount= GameObject.FindGameObjectWithTag("Player").transform.GetChild(1).GetChild(2).GetComponent<TextMeshProUGUI>();
        _PlayerStats = Player.GetComponent<PlayerStats>();
        _WeaponSystem = Player.GetComponent<WeaponSystem>();
        txt_PlayerYearCount.text = _PlayerStats.Player_Year.ToString();
        ChangeGateColor();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            other.gameObject.SetActive(false);
            GateAnimator.SetTrigger("GateHit");
            ChangeGateColor();
            Count += Counter;

            if (Count > 0 || Count == 0)
            {
                txt_Count.text = "+" + Count;
            }
            else if (Count < 0)
            {
                txt_Count.text = Count.ToString();
            }
            
            
         }
      
        if (other.CompareTag("Player"))
        {
            if (txt_Head.text == "Fire Range")
            {
                _PlayerStats.Player_fireRange += Count;
                Player.GetComponent<BulletPoolingSystem>().updateStats();

            }
            if (txt_Head.text=="Fire Rate")
            {
                _PlayerStats.Player_fireRate += Count;
                Player.GetComponent<BulletPoolingSystem>().updateStats();

            }
           
            if (txt_Head.text =="Year")
            {
                _PlayerStats.Player_Year += Count;
                txt_PlayerYearCount.text = _PlayerStats.Player_Year.ToString();
                _WeaponSystem.changeWeapon();

            }
            if (txt_Head.text =="Money")
            {
                _PlayerStats.Player_Money += Count;
                Player.GetComponent<CollectMoney>().UpdateUI_MoneyCount();

            }

            Destroy(this.gameObject);
        }
    }

    void ChangeGateColor() 
    {
        if (Count < 0)
        {
            GateFrame.GetComponent<Image>().sprite = RedFrameSprite;
            GateCounterBackground.GetComponent<Image>().sprite = RedCounterBackgrounSprite;
            GateColor.GetComponent<Renderer>().material = mat_Red;
        }
        else if (Count > 0 || Count == 0)
        {
            GateFrame.GetComponent<Image>().sprite = GreenFrameSprite;
            GateCounterBackground.GetComponent<Image>().sprite = GreenCounterBackgrounSprite;
            GateColor.GetComponent<Renderer>().material = mat_Green;
        }

    }
}
