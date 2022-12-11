using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotificationController : MonoBehaviour
{   

    Canvas canvas;

    Image img;

    TMPro.TextMeshProUGUI text;

    TMPro.TextMeshProUGUI title;

    // Start is called before the first frame update
    void Awake()
    {

        canvas = this.GetComponent<Canvas>();

        text = this.transform.GetChild(0).Find("Notification Text").GetComponent<TMPro.TextMeshProUGUI>();

        if (this.name.Contains("Thin")) {

            img = this.transform.GetChild(0).Find("Icon").GetComponent<Image>();

        }

        if (!this.name.Contains("Thin"))
        {

            title = this.transform.GetChild(0).Find("Notification Title").GetComponent<TMPro.TextMeshProUGUI>();
          
        }
           
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

    public void setImage(Sprite image)
    {

        img.sprite = image;

    }

    public void setTitle(string msg)
    {

        title.text = msg;

    }
}
