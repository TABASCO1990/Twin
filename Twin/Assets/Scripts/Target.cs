using UnityEngine;

public class Target : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            print("Ты нашел меня");       
        }
    }
}
