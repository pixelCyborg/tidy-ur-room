using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_RecordPlayer : InteractablesBase
{
    private AudioSource source;
    public List<AudioClip> clips;
    int clipIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        source = GetComponent<AudioSource>();
        source.clip = clips[clipIndex];
        source.loop = true;
    }

    // Update is called once per frame
    public override void Interact()
    {
        clipIndex++;
        if(clipIndex > clips.Count - 1) {
            clipIndex = 0;
        }
        source.clip = clips[clipIndex];
        base.Interact();
    }
}
