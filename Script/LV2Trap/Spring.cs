using UnityEngine;

public class Spring : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Rigidbody PlayerRigid = other.rigidbody;
            PlayerRigid.AddForce(0, 10, 0, ForceMode.Impulse);
        }
    }
}

