using UnityEngine;

public class BulletLoot : MonoBehaviour
{
    [SerializeField] private int _bulletsCount;
    [SerializeField] private int _gunIndex;
    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody)
        {
            PlayerArmory playerArmory = other.attachedRigidbody.GetComponent<PlayerArmory>();
            
            if (playerArmory)
            {
                playerArmory.AddBullets(_gunIndex,_bulletsCount);
                Destroy(gameObject);
            }
        }
    }
}
