using UnityEngine;

public class Bomb : MonoBehaviour
{   
    private void OnTriggerEnter(Collider other)
    {  
        if (other.TryGetComponent(out Player player))
        {
            player.TakeHit();
            gameObject.SetActive(false);
        }
    }   
}
