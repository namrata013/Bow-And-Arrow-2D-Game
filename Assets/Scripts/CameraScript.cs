using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraScript : MonoBehaviour
{

    public GameObject arrow;
    public GameObject target;
    public Text powerText;
    public GameManager gameManager;
    private Arrow arrowScript;
    private new Camera camera;



    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
        arrowScript = arrow.GetComponent<Arrow>();
        arrowScript.HitTarget.AddListener(OnHitTarget);
        arrowScript.MissTarget.AddListener(OnMissTarget);
    }

    void OnHitTarget()
    {
        gameManager.UpdateHitScore();
        StartCoroutine("ResetArrow");
    }

    void OnMissTarget()
    {
        gameManager.UpdateMissScore();
        StartCoroutine("ResetArrow");
        
    }

    IEnumerator ResetArrow()
    {
        if(gameManager.score==0){
            gameManager.GameOver();
        }
        else{
            yield return new WaitForSeconds(1);
            target.transform.position = new Vector3(Random.Range(-4f, 16f), target.transform.position.y, target.transform.position.z);
            arrowScript.reset();
        }
        
    }

    //Update is called once per frame
    void LateUpdate()
    {

        powerText.text = "Power: " + arrowScript.shotStrength + "%";

    }
}
