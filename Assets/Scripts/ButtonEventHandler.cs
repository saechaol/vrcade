using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonEventHandler : MonoBehaviour, ISelectHandler, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        gameObject.transform.position += new Vector3(0, 0.1f, -0.2f);
        gameObject.transform.localScale *= 1.3f; 
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        gameObject.transform.position += new Vector3(0, -0.1f, 0.2f);
        gameObject.transform.localScale /= 1.3f;
    }

    public void OnSelect(BaseEventData eventData)
    {
        Debug.Log("Button Select");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
