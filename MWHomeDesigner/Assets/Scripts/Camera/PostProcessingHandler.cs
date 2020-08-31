using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

// View
public class PostProcessingHandler : MonoBehaviour
{
    // replace dof with something else

    [SerializeField] PostProcessVolume pPVolume;
    private Bloom _bloom;
    private DepthOfField _dOF;
    private AmbientOcclusion _aO;
    private Vignette _v;

    [SerializeField] Slider[] sliders;

    private void Start()
    {
        pPVolume.profile.TryGetSettings<Bloom>(out _bloom);
        _bloom.intensity.value = 0f;
        pPVolume.profile.TryGetSettings<DepthOfField>(out _dOF);
        pPVolume.profile.TryGetSettings<AmbientOcclusion>(out _aO);
        pPVolume.profile.TryGetSettings<Vignette>(out _v);
    }

    public void changeBloomIntensity()
    {
        _bloom.intensity.value = new FloatParameter { value = sliders[0].value };
    }

    public void changeBloomTreshold()
    {
        _bloom.threshold.value = new FloatParameter { value = sliders[1].value };
    }

    public void changeBloomSoftKnee()
    {
        _bloom.softKnee = new FloatParameter { value = sliders[2].value };
    }

    public void changeDOFFocusDistance()
    {
        _dOF.focusDistance.value = new FloatParameter { value = sliders[3].value };
    }

    public void changeDOFAperture()
    {
        _dOF.aperture.value = new FloatParameter { value = sliders[4].value };
    }
    
    public void changeAOIntensity()
    {
        _aO.intensity.value = new FloatParameter { value = sliders[5].value };
    }

    public void changeAOThicknessModifier()
    {
        _aO.thicknessModifier.value = new FloatParameter { value = sliders[6].value };
    }

}
