﻿using UnityEngine;
using System.Collections;
using System;

public class DemPredatorExitTween :DemTween{

  public DemPredatorExitTween(GameObject _tweenObject, int _tweenTime): base(_tweenObject , _tweenTime){
    
    oldPosition = objectTransform.position;
    newPosition = _tweenObject.GetComponent<BuildInfo> ().GetTile ().GetCenter ();
    newPosition.x -= 10;
    Debug.Log (oldPosition);
    Debug.Log (newPosition);

  }

  public override void Update(int id){

    if (complete || !running) {
      //Just in case it gets called after completed
      return;
    }

    deltaTime = (Time.time - initialTime) * 1000;
    progress = deltaTime / tweenTime;

    if (progress >= 1) {
      //Mark for deletion
      complete = true;
      tweenManager.RemoveTween (id);


      turnSystem.PredatorExit (tweenObject);

      return;
    }

    objectTransform.position = Vector3.Lerp(oldPosition, newPosition, progress);

  }



}