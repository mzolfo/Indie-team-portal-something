using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummoningCirclePuzzleLogic : MonoBehaviour
{
    //this script needs to check the two attached contextual positions to see if the candles are in place
    //if they are it needs to conjure the divination tower model above it and play a particle effect and possibly sound effect as well.
    [SerializeField]
    private ContextualPosition CandleSpot1;
    [SerializeField]
    private ContextualPosition CandleSpot2;
    public bool hasBeenSolved;
    [SerializeField]
    private GameObject DivinationTowerDiorama;
    [SerializeField]
    private ParticleSystem SummonCircleParticles;
    [SerializeField]
    private Transform SummonedObjectSpot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasBeenSolved)
        {
            if (CandleSpot1.keyInPlace && CandleSpot2.keyInPlace)
            {
                //make the tower appear and track that it has been done so it doesnt do it anymore.
                SummonCircleParticles.Play();
                StartCoroutine(SummonDiorama());
                
                hasBeenSolved = true;
            }
        }
       
    }

    IEnumerator SummonDiorama()
    {
        yield return new WaitForSeconds(6.5f);
        DivinationTowerDiorama.SetActive(true);
        DivinationTowerDiorama.transform.position = SummonedObjectSpot.position;
    }
   }
