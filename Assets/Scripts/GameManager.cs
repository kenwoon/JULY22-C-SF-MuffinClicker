using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public UnityEvent<int> OnTotalMuffinsChanged;
    public UnityEvent<int> OnMuffinsPerSecondChanged;

    [Range(0f, 1f)]
    [SerializeField]
    private float _critChance = 0.01f;
    
    private int _muffinsPerClick = 1;
    private int _totalMuffins = 0;
    private int _muffinsPerSecond = 0;
    private float _muffinsPerSecondTimer;

    private int TotalMuffins
    {
        get
        {
            return _totalMuffins;
        }
        set
        {
            _totalMuffins = value;
            OnTotalMuffinsChanged.Invoke(_totalMuffins);
        }
    }

    /// <summary>
    /// Adds muffins to the total muffins.
    /// </summary>
    /// <returns>Returns the added muffins.</returns>

    public int AddMuffins()
    {
        int addedMuffins;
        if (Random.value <= _critChance)
        {
            // Crit
            addedMuffins = _muffinsPerClick * 10;
        }
        else
        {
            // Normal
            addedMuffins = _muffinsPerClick;
        }

        TotalMuffins += addedMuffins;

        return addedMuffins;
    }

    public bool TryPurchaseUpgrade(int currentCost, int level, UpgradeType upgradeType)
    {
        if (TotalMuffins >= currentCost)
        {
            TotalMuffins -= currentCost;
            level++;

            //if (upgradeType == UpgradeType.MuffinUpgrade)
            //{
            //    _muffinsPerClick = 1 + level * 2;
            //}
            //else if (upgradeType == UpgradeType.SugarRushUpgrade)
            //{
            //    _muffinsPerSecond = level;
            //    OnMuffinsPerSecondChanged.Invoke(_muffinsPerSecond);
            //}
            //else if (upgradeType == UpgradeType.FancyMuffinUpgrade)
            //{
            //    // Fancy muffins
            //}

            // Switch
            switch (upgradeType)
            {
                case UpgradeType.MuffinUpgrade:
                    _muffinsPerClick = 1 + level * 2;
                    break;
                case UpgradeType.SugarRushUpgrade:
                    _muffinsPerSecond = level;
                    OnMuffinsPerSecondChanged.Invoke(_muffinsPerSecond);
                    break;
                case UpgradeType.FancyMuffinUpgrade:
                    break;
            }


            return true;
        }

        return false;
    }

    private void Start()
    {
        TotalMuffins = 0;
    }

    private void Update()
    {
        _muffinsPerSecondTimer += Time.deltaTime;

        if (_muffinsPerSecondTimer >= 1)
        {
            _muffinsPerSecondTimer--;
            TotalMuffins += _muffinsPerSecond;
        }
    }
}
