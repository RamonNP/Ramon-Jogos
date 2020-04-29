using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract  class GameControllerBase : MonoBehaviour 
{
    public abstract AudioClip GetAudioSelecionado();
    public abstract void addRight();
    public abstract void addError();
    public abstract void playFx(AudioClip fxAudio);
 
}
