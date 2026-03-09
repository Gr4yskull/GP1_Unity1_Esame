using System;
using UnityEngine;
using UnityEngine.EventSystems;

public enum turret
{
    normal,
    machineGun,
    area,
    none
}
public class TurretPlacer : MonoBehaviour,IPointerClickHandler
{
    [SerializeField] GameObject [] type;
    public static turret turretSelected;
    public float yRotation;
    public bool occupied=false;

    public void Start()
    {
        turretSelected=turret.none;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Place();    
        turretSelected=turret.none;
    }


    public void SelectNormal()
    {
        turretSelected=turret.normal;
    }

    public void SelectMachineGun()
    {
        turretSelected=turret.machineGun;
    }

    public void SelectArea()
    {
        turretSelected=turret.area;
    }

    private void Place()
    {
        switch (turretSelected)
        {
            case turret.normal:
            if(GameManager.Instance.coins<5)
                return;
            if(occupied)
                return;
            Instantiate(type[0], transform.position, Quaternion.Euler(0,yRotation,0));
            occupied=true;
            GameManager.Instance.RemoveCoins(5);
            break;

            case turret.machineGun:
            if(GameManager.Instance.coins<10)
                return;
            if(occupied)
                return;
            Instantiate(type[1], transform.position, Quaternion.Euler(0,yRotation,0));
            occupied=true;
            GameManager.Instance.RemoveCoins(10);
            break;

            case turret.area:
            if(GameManager.Instance.coins<15)
                return;
            if(occupied)
                return;
            Instantiate(type[2], transform.position, Quaternion.Euler(0,yRotation,0));
            occupied=true;
            GameManager.Instance.RemoveCoins(15);
            break;

            default:
            Debug.Log("You shouldn't end up here");
            break;
        }
    }
}
