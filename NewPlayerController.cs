using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animator;
    private bool isHopping;

    private void Start()
    {
        animator = GetComponent<Animator> ();
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.W) && !isHopping)
        {
            float zDiff = 0;
            if(transform.position.z%1!=0)
            {
                zDiff = Mathf.Round(transform.position.z) - transform.position.z;
            }
            MoveCharacter(new Vector3(1, 0, zDiff));

        }
        else if(Input.GetKeyDown(KeyCode.A) && !isHopping)
        {
            MoveCharacter(new Vector3(0, 0, 1));
        }
        else if (Input.GetKeyDown(KeyCode.D) && !isHopping)
        {
            MoveCharacter(new Vector3(0, 0, -1));
        }
    }

    private void MoveCharacter(Vector3 difference)
    {
        animator.SetTrigger("hop");
        isHopping = true;
        transform.position = (transform.position + difference);
    }

    public void FinishHop()
    {
        isHopping = false;
    }
}
