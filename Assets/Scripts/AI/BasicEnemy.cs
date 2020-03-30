using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.AI;

public class BasicEnemy : MonoBehaviour
{
   public int _hp;
   public ParticleSystem bloosPS;
   private void OnParticleCollision(GameObject other)
   {
      //Debug.Log(other.gameObject.name);

      //legger til damageAmount hvis det kommer flere våpen
      _hp--;

      if (_hp <= 0)
      {
         GetComponent<Collider>().enabled = false;
         StartCoroutine(DIE());
      }
   }


   [Header("On Dying")]
   public float speedReductionDuration;
   
   private IEnumerator DIE()
   {
      DOTween.To(()=> GetComponent<NavMeshAgent>().speed,(value=>GetComponent<NavMeshAgent>().speed=value),
         0,
         speedReductionDuration).
         SetEase(Ease.InOutSine);
      
      bloosPS.Play();
      
      
      yield return new WaitForSeconds(speedReductionDuration + 0.5f);

      gameObject.GetComponent<Renderer>().enabled = false;
   }
   
   
}
