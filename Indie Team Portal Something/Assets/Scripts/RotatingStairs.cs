using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingStairs : MonoBehaviour
{
    [SerializeField]
    private float pauseSeconds = 3;

    [SerializeField]
    private float animationSeconds = 2.0f;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        StartCoroutine(RotateStairs());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    IEnumerator RotateStairs()
    {
        while(true)
        {
            for (int i = 0; i < 3; i++)
            {
                yield return new WaitForSeconds(pauseSeconds);
                animator.SetBool("Rotating", true);
                if (i < 2)
                    yield return new WaitForSeconds(animationSeconds);
                else
                    yield return new WaitForSeconds(animationSeconds * 2);
                animator.SetBool("Rotating", false);
            }
        }
    }
}
