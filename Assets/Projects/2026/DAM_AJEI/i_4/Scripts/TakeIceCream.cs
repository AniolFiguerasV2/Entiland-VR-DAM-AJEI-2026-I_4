using UnityEngine;

public class TakeIceCream : MonoBehaviour
{
    public GameObject iceCream;
    public Transform spawnPoint;

    private GameObject currentIceCream;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle") && !currentIceCream)
        {
            currentIceCream = Instantiate(iceCream, spawnPoint.position, spawnPoint.rotation);
            currentIceCream.transform.SetParent(this.transform);
        }
    }

    public void RemoveIceCream()
    {
            Destroy(currentIceCream);
            currentIceCream = null;
    }
}
