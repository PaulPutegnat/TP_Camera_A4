using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewVolumeBlender : MonoBehaviour
{
    private List<AViewVolume> activeViewVolumes = new List<AViewVolume>();
    private Dictionary<AView, List<AViewVolume>> volumesPerViews = new Dictionary<AView, List<AViewVolume>>();



    public void AddVolume(AViewVolume viewVolume)
    {
        activeViewVolumes.Add(viewVolume);

        AView view = viewVolume.GetComponent<AView>();

        if (view != null)
        {
            if (!volumesPerViews.ContainsKey(view))
            {
                volumesPerViews[view] = new List<AViewVolume>();
                view.SetActive(true);
            }

            volumesPerViews[view].Add(viewVolume);
        }
    }

    public void RemoveVolume(AViewVolume viewVolume)
    {
        activeViewVolumes.Remove(viewVolume);

        AView view = viewVolume.GetComponent<AView>();

        if (view != null && volumesPerViews.ContainsKey(view)) 
        {
            volumesPerViews[view].Remove(viewVolume);

            if (volumesPerViews[view].Count == 0)
            {
                volumesPerViews.Remove(view);
                view.SetActive(false);
            }
        }
    }
}
