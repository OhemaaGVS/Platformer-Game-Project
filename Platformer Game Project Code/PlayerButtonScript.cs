
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;


public class PlayerButtonScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    // Start is called before the first frame update
    private bool pointerDown;
    //    private float pointerDownTime;
    // public float heldtime;
    public UnityEvent onLongClick;
    public void OnPointerDown(PointerEventData eventData)
    {
        pointerDown = true;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        pointerDown = false;

    }
    // Update is called once per frame
    void Update()
    {
        if (pointerDown == true)
        {
            //pointerDownTime += Time.deltaTime;
            //if(pointerDownTime>=heldtime)
            // {
            // if (onLongClick!= null)
            // {
            onLongClick.Invoke();
            //  }
            //  Reset();
            //}
        }
        else if (pointerDown == false)
        {
            Stop();
        }
    }
    }
}
public void Stop()
{
    PlayerScripts.GetPlayerInstance().SetAttackingFalse();
}
}
