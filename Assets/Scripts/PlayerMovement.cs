using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    
    [SerializeField] float movementsSpeed;
    [SerializeField] float horizontalSpeed;
    float horizontal;
    public int stackCount;

    public GameObject[] moneyStack;

    public float lerpSpeed;

    new Vector3 startScale;
    public GameObject moneyPrefab;

   


    // PlayerMovement.instance her yerden eriþmek için 
    public static PlayerMovement instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {

        startScale = moneyPrefab.transform.localScale;
        DOTween.Init();
    }

    private void FixedUpdate()
    {

        transform.Translate(Vector3.forward * movementsSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (this.gameObject.transform.position.x > LevelBoundary.leftSide)
            {
                transform.Translate(Vector3.left * horizontalSpeed * Time.deltaTime);
            }
        }


        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (this.gameObject.transform.position.x < LevelBoundary.rightSide)
            {
                transform.Translate(Vector3.left * horizontalSpeed * Time.deltaTime * -1);
            }

        }

        


        for (int i = 0; i < stackCount; i++)
        {
            if (i == 0)
            {
                moneyStack[i].transform.position = Vector3.Lerp(moneyStack[i].transform.position, transform.position + new Vector3(0, 1, 5), Time.deltaTime * lerpSpeed);

            }
            else
            {
                moneyStack[i].transform.position = Vector3.Lerp(moneyStack[i].transform.position, moneyStack[i - 1].transform.position + new Vector3(0, 0, 3), Time.deltaTime * lerpSpeed);
            }
            

            //moneyStack[i].transform.position = Vector3.Lerp(moneyStack[i].transform.position, transform.position, Time.deltaTime * 20);
        }

    }

      

    
    public IEnumerator ScaleMoney()
    {
        
        //Print the time of when the function is first called.
        for (int i = stackCount-1; i >-1; i--)    
        {
            //moneyStack[i].transform.DOScale(new Vector3(moneyStack[i].transform.localScale.x * 2, moneyStack[i].transform.localScale.y * 2, moneyStack[i].transform.localScale.z * 2), 1).OnComplete(() => firstShape(moneyStack[i]));
            if (moneyStack[i] != null)
            {
                moneyStack[i].transform.DOScale(startScale * 2, 0.5f);
            }

            yield return new WaitForSeconds(0.05f);

            if (moneyStack[i]!= null)
            {
                moneyStack[i].transform.DOScale(startScale, 0.5f);
            }
            
          
        }

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }

    public void firstShape(int i)
    {

        moneyStack[i].transform.DOScale(new Vector3(1,1,1), 1);
        Debug.Log(i + "çalýþýyor");
    }

    public void SS()
    {
        StartCoroutine(ScaleMoney());
    }
    

    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "money" && !other.gameObject.GetComponent<Money>().isStackController)
        {
            moneyStack[stackCount] = other.gameObject;
            stackCount++;

            other.gameObject.GetComponent<Money>().isStackController = true;
            //other.gameObject.GetComponent<BoxCollider>().enabled = false;
            SS();
        }
    }
    

    
    /*int tempSC = stackCount;
            minScale = moneyStack[i].gameObject.transform.localScale;
            while (tempSC != 0)
            {
                yield return RepeatLerp(minScale, maxScale, duration);
                yield return RepeatLerp(maxScale, minScale, duration);
            }
    */
}
