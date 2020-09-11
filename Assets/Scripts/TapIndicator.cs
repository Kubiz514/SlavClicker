using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapIndicator : MonoBehaviour
{
    [SerializeField]
    AnimationClip animation;

    void Start()
    {
        StartCoroutine(DestroyAfter(animation.length));
    }

    void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * 300f);  
    }

    IEnumerator DestroyAfter(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
