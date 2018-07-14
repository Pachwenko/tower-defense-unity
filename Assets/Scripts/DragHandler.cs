using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler {

    public GameObject prefab;
    public static GameObject itemBeingDragged;
    private Vector3 startPosition;
    private GameController gameController;

    public void OnBeginDrag(PointerEventData eventData) {
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        gameController = gameControllerObject.GetComponent<GameController>();
        if (gameController == null) {
            Debug.Log("Could not find 'GameController' scipt");
        }

        itemBeingDragged = gameObject;
        startPosition = transform.position;
        //GetComponent<CanvasGroup>().blocksRaycasts = false;

    }
    public void OnDrag(PointerEventData eventData) {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData) {
        itemBeingDragged = null;
        // GetComponent<CanvasGroup>().blocksRaycasts = true;
        transform.position = startPosition;
        if (gameController.MoneyWithdrawlOrDeposit(-1 * prefab.GetComponent<TowerBehavior>().getCost())) {
            GameObject clone = Instantiate(prefab);
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(eventData.position);
            clone.transform.position = new Vector3(newPosition.x, newPosition.y);
        } else {
            //do nothing because you can't afford a new tower
        }
    }
}
