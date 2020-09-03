using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class PostProcessingHandler : MonoBehaviour
{
    // the post processing volume of the camera
    [SerializeField] PostProcessVolume pPVolume;
    // variables to set the Bloom, ColorGrading & AmbientOcclusion values
    private Bloom _bloom;
    private ColorGrading _CG;
    private AmbientOcclusion _AO;

    // sliders for user input
    [SerializeField] Slider[] sliders;

    private void Start()
    {
        // try to access the volume settings
        pPVolume.profile.TryGetSettings<Bloom>(out _bloom);
        pPVolume.profile.TryGetSettings<ColorGrading>(out _CG);
        pPVolume.profile.TryGetSettings<AmbientOcclusion>(out _AO);
    }

    // set the bloom intensity with the first slider
    public void changeBloomIntensity() { _bloom.intensity.value = new FloatParameter { value = sliders[0].value }; }

    // set the bloom treshold with the second slider
    public void changeBloomTreshold() { _bloom.threshold.value = new FloatParameter { value = sliders[1].value }; }

    // set the bloom soft knee with the third slider
    public void changeBloomSoftKnee() { _bloom.softKnee = new FloatParameter { value = sliders[2].value }; }

    // set the color grading saturation with the fourth slider
    public void changeCGSaturation() { _CG.saturation.value = new FloatParameter { value = sliders[3].value }; }

    // set the color grading contrast with the fifth slider
    public void changeCGContrast() { _CG.contrast.value = new FloatParameter { value = sliders[4].value }; }

    // set the color grading temperature with the sixth slider
    public void changeCGTemperature() { _CG.temperature.value = new FloatParameter { value = sliders[5].value }; }

    // set the color grading tint with the seventh slider
    public void changeCGTint() { _CG.tint.value = new FloatParameter { value = sliders[6].value }; }

    // set the ambient occlusion intensity with the eighth slider
    public void changeAOIntensity() { _AO.intensity.value = new FloatParameter { value = sliders[7].value }; }

    // set the ambient occlusion thickness with the ninth slider
    public void changeAOThicknessModifier() { _AO.thicknessModifier.value = new FloatParameter { value = sliders[8].value }; }

}
