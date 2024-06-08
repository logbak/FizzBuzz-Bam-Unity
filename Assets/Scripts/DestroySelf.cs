using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    //this script taken from: http://answers.unity.com/answers/1166318/view.html
    public float delay = 0f;

    void Start()
    {
        Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay);
    }

    //alternatively a more simple solution used in the original tutorial doesn't mess with animation components and just sets a delay:
    //public float lifetime;

    //void Start()
    //{
        //Destroy(gameObject, lifetime);
    //}
}
