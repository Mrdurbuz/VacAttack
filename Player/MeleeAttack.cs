using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public GameObject bat;

    //bool timeToHit;

    public float wait;

    //public ParticleSystem stars;

    private void Start()
    {
        bat.SetActive(false);
        //timeToHit = true;
    }

    public void BatAttack()
    {
        GetComponentInChildren<BatHit>();
        StartCoroutine(StopToHit());
    }

    IEnumerator StopToHit()
    {
        //timeToHit = false;
        yield return new WaitForSeconds(0.2f);
        bat.SetActive(true);
        //GetComponentInChildren<BatHit>();
        yield return new WaitForSeconds(0.1f);
        bat.SetActive(false);
        yield return new WaitForSeconds(wait);
        //timeToHit = true;
    }
}
