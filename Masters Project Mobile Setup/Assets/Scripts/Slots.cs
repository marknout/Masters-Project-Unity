using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class Slots : MonoBehaviour, IDropHandler
{
    public GameObject item
    {
        get
        {
            if (transform.childCount > 0)
            {
                return transform.GetChild(0).gameObject;
            }

            return null;
        }
    }

   
    public void OnDrop(PointerEventData eventData)
    {
        if (!item)
        {
            DragHandler.item.transform.SetParent(transform);
        }
        else
        {
            Transform aux = DragHandler.item.transform.parent;
            DragHandler.item.transform.SetParent(transform);
            item.transform.SetParent(aux);

        }
    }

}
