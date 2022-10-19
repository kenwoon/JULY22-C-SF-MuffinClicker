using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField]
    private GameManager _gameManager;

    [SerializeField]
    private TextMeshProUGUI _levelText;
    [SerializeField]
    private TextMeshProUGUI _costText;
    [SerializeField]
    private float _costPowerScale = 1.5f;

    [SerializeField]
    private UpgradeType _upgradeType;

    //[SerializeField]
    //private int[] _costPerLevel;

    private int _level;

    private int Level
    {
        get
        {
            return _level;
        }
        set
        {
            _level = value;
            _levelText.text = _level.ToString();
            _costText.text = CurrentCost.ToString();
        }
    }

    private int CurrentCost
    {
        get
        {
            return 5 + Mathf.RoundToInt(Mathf.Pow(_level, _costPowerScale));

            //int length = _costPerLevel.Length;

            //if (length == 0)
            //{
            //    return 0;
            //}

            //int index = Mathf.Clamp(_level, 0, length - 1);
            //return _costPerLevel[index];
        }
    }

    private void Start()
    {
        Level = 0;
        GetComponent<Button>().onClick.AddListener(OnUpgradeClicked);
        _gameManager.OnTotalMuffinsChanged.AddListener(TotalMuffinsChanged);
    }

    public void TotalMuffinsChanged(int totalMuffins)
    {
        bool canAfford = totalMuffins >= CurrentCost;
        _costText.color = canAfford ? Color.green : Color.red;

        //if (canAfford)
        //{
        //    _costText.color = Color.green;
        //}
        //else
        //{
        //    _costText.color = Color.red;
        //}
    }

    public void OnUpgradeClicked()
    {
        int currentCost = CurrentCost;
        bool purchasedUpgrade = _gameManager.TryPurchaseUpgrade(currentCost, Level, _upgradeType);
        if (purchasedUpgrade)
        {
            Level++;
        }
    }

    private void UpdateUI()
    {
        _levelText.text = _level.ToString();
        _costText.text = CurrentCost.ToString();
    }
}
