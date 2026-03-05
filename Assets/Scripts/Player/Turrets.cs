using UnityEngine;

public class Turrets : MonoBehaviour
{
    [SerializeField] public GameObject bullet;
    [SerializeField] public float bulletRate;
    [SerializeField] public int cost;
    public float timer;
}
