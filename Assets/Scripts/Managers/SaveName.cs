using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SaveName : MonoBehaviour
{
    public TMP_Text Name;
    public TMP_Text EditName;

    public void SaveText()
    {
        Name.text = EditName.text;
    }
}
