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
            //if (IsValidPlacement())
            //{
                GameObject clone = Instantiate(prefab);
                Vector3 newPosition = Camera.main.ScreenToWorldPoint(eventData.position);
                clone.transform.position = new Vector3(newPosition.x, newPosition.y);
            //}
        } else {
            //do nothing because you can't afford a new tower
        }
    }

    public bool IsValidPlacement()
    {
        //sprites are 256x256, adjust from the middle
        int adjust = 256 / 2;
        Vector2 pointA = transform.position + new Vector3(-1 * adjust, adjust, 0);
        Vector2 pointB = transform.position + new Vector3(adjust, -1 * adjust, 0);
        Collider2D overlaps = Physics2D.OverlapArea(pointA, pointB);
        if (overlaps == gameObject.GetComponent<Collider2D>())
        {
            Debug.Log("invalid tower placement");
            return false;
        }
        Debug.Log("valid tower placement");
        return true;
    }
}
