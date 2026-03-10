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

    //when you click on the platform it activates the function place
    public void OnPointerClick(PointerEventData eventData)
    {
        Place();    
        //after you place it select automatically no turret
        turretSelected=turret.none;
    }

    //on the button to select the normal turret
    public void SelectNormal()
    {
        turretSelected=turret.normal;
    }

    //on the button to select the machinne gun turret
    public void SelectMachineGun()
    {
        turretSelected=turret.machineGun;
    }

    public void SelectArea()
    {
        turretSelected=turret.area;
    }

    //on the button to select the area turret
    private void Place()
    {

        switch (turretSelected)
        {
            //if the type is normal, you have enough money and it's not occupied places turret and sets the bool to true
            case turret.normal:
            if(GameManager.Instance.coins<5)
                return;
            if(occupied)
                return;
            Instantiate(type[0], transform.position, Quaternion.Euler(0,yRotation,0));
            occupied=true;
            GameManager.Instance.RemoveCoins(5);
            break;

            //if the type is machine gun, you have enough money and it's not occupied places turret and sets the bool to true
            case turret.machineGun:
            if(GameManager.Instance.coins<10)
                return;
            if(occupied)
                return;
            Instantiate(type[1], transform.position, Quaternion.Euler(0,yRotation,0));
            occupied=true;
            GameManager.Instance.RemoveCoins(10);
            break;

            //if the type is area, you have enough money and it's not occupied places turret and sets the bool to true
            case turret.area:
            if(GameManager.Instance.coins<15)
                return;
            if(occupied)
                return;
            Instantiate(type[2], transform.position, Quaternion.Euler(0,yRotation,0));
            occupied=true;
            GameManager.Instance.RemoveCoins(15);
            break;

            //if you have no turret selected nothing happens
            case turret.none:
            break;
            
            default:
            Debug.Log("You shouldn't end up here");
            break;
        }
    }
}
