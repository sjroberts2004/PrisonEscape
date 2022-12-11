using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationController : MonoBehaviour
{

    TMPro.TextMeshProUGUI text;

    Canvas canvas;
    // Start is called before the first frame update
    void Awake()
    {
        canvas = this.GetComponent<Canvas>();

        text = this.transform.GetChild(0).GetChild(0).GetComponent<TMPro.TextMeshProUGUI>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Show() {

        canvas.enabled = true;

    }

    public void Hide() {

        canvas.enabled = false;

    }

    public void setText(string msg) {

        text.text = msg;
    
    }


}
