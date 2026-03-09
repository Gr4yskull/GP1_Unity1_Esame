using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class UpgradeManager : MonoBehaviour,IPointerClickHandler
{
    turret turretType;
    public int normalCost=5,machineGunCost=10,areaCost=15;
    public void OnPointerClick(PointerEventData eventData)
    {
        Upgrade();
    }

    public void Upgrade()
    {
            switch (turretType)
        {
            case turret.normal:
                if(GameManager.Instance.coins<=normalCost)
                    return;

                Projectiles.damage*=2;
                GameManager.Instance.RemoveCoins(normalCost);
                normalCost*=2;
                break;

            // case turret.machineGun:
            //      if(GameManager.Instance.coins<=machineGunCost)
            //         return;
            //     GameObject machineGun=GameObject.FindWithTag("MG");
            //     Shooter Rate=machineGun.GetComponent<Shooter>();
            //     if(Rate.bulletRate<=1)
            //         Rate.bulletRate-=0.5f;
                
            //     GameManager.Instance.RemoveCoins(machineGunCost);
            //     machineGunCost*=2;
            //     break;

            // case turret.area:
            //      if(GameManager.Instance.coins<=areaCost)
            //         return;
            //     //AreaProjectiles.radius*=1.25f;
            //     GameManager.Instance.RemoveCoins(areaCost);
            //     areaCost*=2;
            //     break;

            case turret.none:
                break;

            default:
                Debug.Log("How Are You Here?");
                break;
        }
    }
}
