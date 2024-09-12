using System.Collections.Generic;
using UnityEngine;

namespace BasicModules
{
    public static class AnimatorExtension
    {
        public static Dictionary<string, List<AnimationClip>> GetClipDictionary(this RuntimeAnimatorController animator)
        {
            Dictionary<string, List<AnimationClip>> keyValuePairs = new();
            var clips = animator.animationClips;
            for (int i = 0; i < clips.Length; i++)
            {
                var clip = clips[i];

                if(keyValuePairs.TryGetValue(clip.name, out var existingClips))
                {
                    existingClips.Add(clip);
                }
                else
                {
                    List<AnimationClip> newClipList = new List<AnimationClip>
                    {
                        clip
                    };
                    keyValuePairs.Add(clip.name, newClipList);
                }                
            }
            return keyValuePairs;
        }
    }
}
