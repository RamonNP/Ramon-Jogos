using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract  class GameControllerBase : MonoBehaviour 
{
    public abstract AudioClip GetAudioSelecionado();
    public abstract int lockKK { get; set; }
    public abstract void addRight();
    public abstract void addError();
    public abstract void playFx(AudioClip fxAudio);

    public void resizeColiderMin(BoxCollider2D bc2d)
    {
        bc2d.size = new Vector2(0.00001f, 0.00001f);
    }

    public void resizeColiderMax(BoxCollider2D bc2d, SpriteRenderer spriteRenderer)
    {
        bc2d.size = new Vector2(2f, 3f);
        spriteRenderer.sortingOrder = 5;
    }
}
