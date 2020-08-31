using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

// View
public class PostProcessingHandler : MonoBehaviour
{
    // replace dof with something else

    [SerializeField] PostProcessVolume pPVolume;
    private Bloom _bloom;
    private ColorGrading _CG;
    private AmbientOcclusion _AO;

    [SerializeField] Slider[] sliders;

    private void Start()
    {
        pPVolume.profile.TryGetSettings<Bloom>(out _bloom);
        pPVolume.profile.TryGetSettings<ColorGrading>(out _CG);
        pPVolume.profile.TryGetSettings<AmbientOcclusion>(out _AO);
    }

    public void changeBloomIntensity() { _bloom.intensity.value = new FloatParameter { value = sliders[0].value }; }

    public void changeBloomTreshold() { _bloom.threshold.value = new FloatParameter { value = sliders[1].value }; }

    public void changeBloomSoftKnee() { _bloom.softKnee = new FloatParameter { value = sliders[2].value }; }

    public void changeCGSaturation() { _CG.saturation.value = new FloatParameter { value = sliders[3].value }; }

    public void changeCGContrast() { _CG.contrast.value = new FloatParameter { value = sliders[4].value }; }

    public void changeCGTemperature() { _CG.temperature.value = new FloatParameter { value = sliders[5].value }; }

    public void changeCGTint() { _CG.tint.value = new FloatParameter { value = sliders[6].value }; }

    public void changeAOIntensity() { _AO.intensity.value = new FloatParameter { value = sliders[7].value }; }

    public void changeAOThicknessModifier() { _AO.thicknessModifier.value = new FloatParameter { value = sliders[8].value }; }

}
