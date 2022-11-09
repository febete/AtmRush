using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Obstacle : MonoBehaviour
{
    public GameObject newMoney;

  
    void Start()
    {

    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "money")
        {
            for (int i = 0; i < PlayerMovement.instance.stackCount; i++)
            {



                if (PlayerMovement.instance.moneyStack[i].gameObject == other.gameObject)
                {
                    if (i == PlayerMovement.instance.stackCount - 1)
                    {
                        PlayerMovement.instance.stackCount--;
                        //other.gameObject.GetComponent<MeshRenderer>().enabled = false;
                        DOTween.Kill(other.gameObject); 
                        Destroy(other.gameObject);

                    }
                    else
                    {
                        int sc = PlayerMovement.instance.stackCount;
                        int ii = i;

                        while (PlayerMovement.instance.stackCount != i)
                        {

                           
                            //DOTween.Kill(PlayerMovement.instance.moneyStack[i].gameObject);
                            //Destroy(PlayerMovement.instance.moneyStack[i]);
                            

                            //Destroy(PlayerMovement.instance.moneyStack[i+1]);
                            PlayerMovement.instance.stackCount--;
                            //other.gameObject.GetComponent<MeshRenderer>().enabled = false;
                            //Destroy(other.gameObject);


                        }
                        
                        while (ii < sc)
                        {
                            DOTween.Kill(PlayerMovement.instance.moneyStack[ii + 1].gameObject);
                            Destroy(PlayerMovement.instance.moneyStack[ii + 1]);
                            ii++;
                            //newMoney= Instantiate(newMoney,PlayerMovement.instance.transform.position+ new Vector3(Random.Range(0.0f, 1.0f), 1, Random.Range(15, 30)),Quaternion.identity);
                            //newMoney = Instantiate(newMoney, transform.position + Vector3.Lerp(PlayerMovement.instance.transform.position,PlayerMovement.instance.transform.position + new Vector3(Random.Range(0.0f, 1.0f), 1, Random.Range(10, 20)), Time.deltaTime*2),Quaternion.identity);


                            //eObject temp = Instantiate(newMoney,transform.position)
                                



                            
                            GameObject temp= Instantiate(newMoney,
                                Vector3.Lerp(new Vector3(0,0,transform.position.z), new Vector3(0, 0, transform.position.z)+ new Vector3(Random.Range(-20,20), 1, Random.Range(50, 100)), Time.deltaTime*10), 
                                Quaternion.identity);
                            
                            //temp.gameObject.GetComponent<Money>().isStackController = true;


                            //PlayerMovement.instance.stackCount--;
                            Debug.Log("son stack count: " + PlayerMovement.instance.stackCount);
                        }
                        




                    }

                }
                //Debug.Log(PlayerMovement.instance.moneyStack[0]);
                //Debug.Log(PlayerMovement.instance.stackCount);
                //Debug.Log(other);  //money (2) vs yazdýrýyor
                //Debug.Log(other.name == PlayerMovement.instance.moneyStack[0].name);
            }

        }
    }
}
