using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOffForSecund : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(Off());
        }
    }

    IEnumerator Off()
        {
        GetComponent<CapsuleCollider2D>().enabled =false;
        yield return new WaitForSeconds(1.5f);
        GetComponent<CapsuleCollider2D>().enabled = true;
        yield break;
    }
}
