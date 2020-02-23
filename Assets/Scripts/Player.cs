using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string coinName;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == coinName)
        {
            StartCoroutine(CollectCoin(other.gameObject));
        }
    }

    private IEnumerator CollectCoin(GameObject coin)
    {
        coin.GetComponent<AudioSource>().Play();
        coin.GetComponent<MeshRenderer>().enabled = false;
        coin.GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(1.0f);

        Destroy(coin);
    }
}
