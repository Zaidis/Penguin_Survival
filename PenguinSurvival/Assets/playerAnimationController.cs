using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnimationController : MonoBehaviour
{
    [SerializeField] Animator anim;
   
    // Update is called once per frame
    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        anim.SetFloat("MovementX", input.x);
        anim.SetFloat("MovementY", input.y);
        anim.SetBool("ultUsed", transform.parent.gameObject.GetComponent<SpellManager>().ultimateUsed);
        
    }
}
