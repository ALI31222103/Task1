using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    [SerializeField] private GameObject deathParticles;
    [SerializeField] private string playerTag = "Player";

    public UnityEvent onCollected;

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == playerTag)
        {
            Instantiate(deathParticles, transform.position, transform.rotation);
            Destroy(gameObject);
            onCollected.Invoke();
        }
    }
}
