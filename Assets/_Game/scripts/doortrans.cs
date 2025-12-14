using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class doortrans : MonoBehaviour
{
   [SerializeField] Animator transition;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
          StartCoroutine(transitions());
        }
    }

    IEnumerator transitions()
    {
    transition.SetTrigger("End");
    yield return new WaitForSeconds(1);
    transition.SetTrigger("Start");
    }
}