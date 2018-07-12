using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler {

    public GameObject prefab;
    public static GameObject itemBeingDragged;
    private Vector3 startPosition;
    private Transform startParent;


    public void OnBeginDrag(PointerEventData eventData) {
        itemBeingDragged = gameObject;
        startPosition = transform.position;
        startParent = transform.parent;
        //GetComponent<CanvasGroup>().blocksRaycasts = false;

    }
    public void OnDrag(PointerEventData eventData) {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData) {
        itemBeingDragged = null;
        // GetComponent<CanvasGroup>().blocksRaycasts = true;
        transform.position = startPosition;
        GameObject clone = Instantiate(prefab);
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(eventData.position);
        clone.transform.position = new Vector3(newPosition.x, newPosition.y);


    }
}
