using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLights : MonoBehaviour
{
        public Animator anim;

        void Start(){

        AnimatorStateInfo state = anim.GetCurrentAnimatorStateInfo(0);
        anim.Play(state.fullPathHash, -1, Random.Range(0f,1f));
        }
}
