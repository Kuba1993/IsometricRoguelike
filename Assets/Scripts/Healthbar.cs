using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    private int currHealth;
    private int maxHealth;
    public float offsetX = 0f;
    public float offsetY = 1f;

    public GameObject target;
    private Enemy enemy;
    public Text text;
    public RectTransform progressBar;

    // Start is called before the first frame update
    void Start()
    {
        enemy = target.GetComponent<Enemy>();
        //transform.position = Camera.main.WorldToScreenPoint(target.transform.position); //transfer worldspace to screenspace
    }

    // Update is called once per frame
    void Update()
    {
        maxHealth = enemy.maxHitpoint;
        currHealth = enemy.hitpoint;

        float completionRatio = (float)currHealth / (float)maxHealth;
        progressBar.localScale = new Vector3(completionRatio, 1, 1);

        text.text= enemy.hitpoint + "/" + enemy.maxHitpoint;

        //add offset to position
        //Vector3 pos = new Vector3(target.transform.position.x + offsetX, target.transform.position.y + offsetY, target.transform.position.z );

        transform.position = Camera.main.WorldToScreenPoint(new Vector3(target.transform.position.x + offsetX, target.transform.position.y + offsetY, target.transform.position.z));
        
    }
}
