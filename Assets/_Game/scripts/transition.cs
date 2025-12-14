using System.Collections;
using UnityEngine;

public class transition : MonoBehaviour
{
    public Animator transitions;
   
  
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            loadtransition();
        }
    }

    public void loadtransition()
    {
        transitions.SetTrigger("Start");
    }

    


   


}
