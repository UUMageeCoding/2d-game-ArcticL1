using System.Collections.Generic;
using UnityEngine;

public class portal : MonoBehaviour
{
    private HashSet<GameObject> PortalObjects = new HashSet<GameObject>();
    audiomanager audiomanager;
    private void Awake()
    {
        audiomanager = GameObject.FindGameObjectWithTag("audio").GetComponent<audiomanager>();
    }

    [SerializeField] private Transform destination;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (PortalObjects.Contains(collision.gameObject))
        { 
    
            return;
            
        }

        if (destination.TryGetComponent(out portal destinationPortal))
        {        
      
            destinationPortal.PortalObjects.Add(collision.gameObject);

        }
        collision.transform.position = destination.position;
        audiomanager.PlaySFX(audiomanager.portal);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
         
        PortalObjects.Remove(collision.gameObject);
        
    }
}
