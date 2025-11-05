using System.Collections.Generic;
using UnityEngine;

public class portal : MonoBehaviour
{
    private HashSet<GameObject> PortalObjects = new HashSet<GameObject>();

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
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PortalObjects.Remove(collision.gameObject);
    }
}
