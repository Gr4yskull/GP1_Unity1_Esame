using UnityEngine;

public class Player : MonoBehaviour
{
   [SerializeField] float maxHP;
   float currentHP;

    private void Start()
    {
        currentHP=maxHP;
    }
}
