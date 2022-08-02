using TMPro;
using UnityEngine;
using System.Collections;

public class notificationItme : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI text;

    public string NotificationText
    {
        set
        {
            if (value == string.Empty)
                value = "Default";
            
            Add(value);
        }
    }
    /// <summary>
    /// Add notfication in to text 
    /// </summary>
    public void Add(string notification)
    {
        text.text = notification;
        StartCoroutine(enumerator());
    }
    /// <summary>
    /// Time to veniszt 
    /// </summary>
     
    private IEnumerator enumerator()
    {
        yield return new WaitForSeconds(1.8F);
        text.text = string.Empty;
        StopAllCoroutines();
    }
}