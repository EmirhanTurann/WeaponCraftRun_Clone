using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectMoney : MonoBehaviour
{
    private PlayerStats _playerStats;
    [SerializeField] private TextMeshProUGUI txt_MoneyCount;
    // Start is called before the first frame update
    void Start()
    {
        _playerStats = GetComponent<PlayerStats>();
        txt_MoneyCount.text = _playerStats.Player_Money.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Money")) 
        {
            _playerStats.Player_Money += 50;
            UpdateUI_MoneyCount();
            other.gameObject.SetActive(false);
        }
        
    }

    public void UpdateUI_MoneyCount()
    {
        txt_MoneyCount.text = _playerStats.Player_Money.ToString();

    }
}
