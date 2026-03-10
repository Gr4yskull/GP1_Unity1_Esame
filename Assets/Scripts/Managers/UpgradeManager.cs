using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class UpgradeManager : MonoBehaviour,IPointerClickHandler
{
    turret turretType;
    public int upgradeCost;
    public void OnPointerClick(PointerEventData eventData)
    {
        if(GameManager.Instance.coins>=upgradeCost){
            Upgrade();
            GameManager.Instance.RemoveCoins(upgradeCost);
            upgradeCost*=2;
        }
    }

    public virtual void Upgrade()
    {
    }
}
