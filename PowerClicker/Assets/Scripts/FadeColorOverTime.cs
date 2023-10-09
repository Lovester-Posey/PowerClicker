using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FadeColorOverTime : MonoBehaviour
{

    private Color textColor;

    private TMP_Text floatingText;

    private float age = 0;
    public float lifetime = 5;

    // Start is called before the first frame update
    void Start()
    {
        floatingText = GetComponent<TMP_Text>();
        textColor = floatingText.color;
    }

    // Update is called once per frame
    void Update()
    {
        age += Time.deltaTime;
        floatingText.color = Color.Lerp(textColor, Color.clear, age / lifetime);
        Destroy(gameObject, 6);
    }
}
