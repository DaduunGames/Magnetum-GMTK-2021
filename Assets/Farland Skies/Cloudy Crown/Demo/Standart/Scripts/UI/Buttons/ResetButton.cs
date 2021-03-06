using UnityEngine;
using UnityEngine.UI;

namespace Borodar.FarlandSkies.CloudyCrownPro
{
    public class ResetButton : MonoBehaviour
    {
        [Header("Sky")]
        public Image TopColorImage;
        public Image BottomColorImage;

        [Header("Clouds")]
        public Dropdown CloudsDropdown;
        public Slider CloudsHeightSlider;
        public Slider CloudsOffsetSlider;
        public Slider CloudsRotationSlider;

        [Header("Stars")]
        public Dropdown StarsDropdown;
        public Image StarsTintImage;
        public Slider ExtinctionSlider;
        public Slider TwinklingSpeedSlider;

        [Header("Sun")]
        public Dropdown SunDropdown;
        public Image SunTintImage;
        public Slider SunAlphaSlider;
        public Slider SunSizeSlider;
        public Toggle SunFlareToggle;
        public Slider SunFlareBrightnessSlider;

        [Header("Moon")]
        public Dropdown MoonDropdown;
        public Image MoonTintImage;
        public Slider MoonAlphaSlider;
        public Slider MoonSizeSlider;
        public Toggle MoonFlareToggle;
        public Slider MoonFlareBrightnessSlider;

        [Header("General")]
        public Slider ExposureSlider;
        public Toggle AdjustFogToggle;

        //---------------------------------------------------------------------
        // Messages
        //---------------------------------------------------------------------

        public void Start()
        {
            // Sky
            DefaultValue.TopColor = SkyboxController.Instance.TopColor;
            DefaultValue.BottomColor = SkyboxController.Instance.BottomColor;
            // Stars
            DefaultValue.StarsTint = SkyboxController.Instance.StarsTint;
            DefaultValue.StarsExtinction = SkyboxController.Instance.StarsExtinction;
            DefaultValue.StarsTwinklingSpeed = SkyboxController.Instance.StarsTwinklingSpeed;
            // Sun
            DefaultValue.SunTint = SkyboxController.Instance.SunTint;
            DefaultValue.SunSize = SkyboxController.Instance.SunSize;
            DefaultValue.SunFlare = SkyboxController.Instance.SunFlare;
            DefaultValue.SunFlareBrightness = SkyboxController.Instance.SunFlareBrightness;
            // Moon
            DefaultValue.MoonTint = SkyboxController.Instance.MoonTint;
            DefaultValue.MoonSize = SkyboxController.Instance.MoonSize;
            DefaultValue.MoonFlare = SkyboxController.Instance.MoonFlare;
            DefaultValue.MoonFlareBrightness = SkyboxController.Instance.MoonFlareBrightness;
            // Clouds
            DefaultValue.CloudsHeight = SkyboxController.Instance.CloudsHeight;
            DefaultValue.CloudsOffset = SkyboxController.Instance.CloudsOffset;
            DefaultValue.CloudsRotationSpeed = SkyboxController.Instance.CloudsRotationSpeed;
            // General
            DefaultValue.Exposure = SkyboxController.Instance.Exposure;
            DefaultValue.AdjustFog = SkyboxController.Instance.AdjustFogColor;
        }

        //---------------------------------------------------------------------
        // Public
        //---------------------------------------------------------------------

        public void OnClick()
        {
            // Sky
            SkyboxController.Instance.TopColor = DefaultValue.TopColor;
            TopColorImage.color = DefaultValue.TopColor;        
            SkyboxController.Instance.BottomColor = DefaultValue.BottomColor;
            BottomColorImage.color = DefaultValue.BottomColor;            
            // Stars
            StarsDropdown.value = 0;
            SkyboxController.Instance.StarsTint = DefaultValue.StarsTint;
            StarsTintImage.color = DefaultValue.StarsTint;
            SkyboxController.Instance.StarsExtinction = DefaultValue.StarsExtinction;
            ExtinctionSlider.value = DefaultValue.StarsExtinction;
            SkyboxController.Instance.StarsTwinklingSpeed = DefaultValue.StarsTwinklingSpeed;
            TwinklingSpeedSlider.value = DefaultValue.StarsTwinklingSpeed;
            // Sun
            SunDropdown.value = 0;
            SkyboxController.Instance.SunTint = DefaultValue.SunTint;
            SunTintImage.color = DefaultValue.SunTint;
            SunAlphaSlider.value = DefaultValue.SunTint.a;
            SkyboxController.Instance.SunSize = DefaultValue.SunSize;
            SunSizeSlider.value = DefaultValue.SunSize;
            SkyboxController.Instance.SunFlare = DefaultValue.SunFlare;
            SunFlareToggle.isOn = DefaultValue.SunFlare;
            SkyboxController.Instance.SunFlareBrightness = DefaultValue.SunFlareBrightness;
            SunFlareBrightnessSlider.value = DefaultValue.SunFlareBrightness;
            // Moon
            MoonDropdown.value = 0;
            SkyboxController.Instance.MoonTint = DefaultValue.MoonTint;
            MoonTintImage.color = DefaultValue.MoonTint;
            MoonAlphaSlider.value = DefaultValue.MoonTint.a;
            SkyboxController.Instance.MoonSize = DefaultValue.MoonSize;
            MoonSizeSlider.value = DefaultValue.MoonSize;
            SkyboxController.Instance.MoonFlare = DefaultValue.MoonFlare;
            MoonFlareToggle.isOn = DefaultValue.MoonFlare;
            SkyboxController.Instance.MoonFlareBrightness = DefaultValue.MoonFlareBrightness;
            MoonFlareBrightnessSlider.value = DefaultValue.MoonFlareBrightness;
            // Clouds
            CloudsDropdown.value = 0;
            SkyboxController.Instance.CloudsHeight = DefaultValue.CloudsHeight;
            CloudsHeightSlider.value = DefaultValue.CloudsHeight;
            SkyboxController.Instance.CloudsOffset = DefaultValue.CloudsOffset;
            CloudsOffsetSlider.value = DefaultValue.CloudsOffset;
            SkyboxController.Instance.CloudsRotationSpeed = DefaultValue.CloudsRotationSpeed;
            CloudsRotationSlider.value = DefaultValue.CloudsRotationSpeed;
            // General
            SkyboxController.Instance.Exposure = DefaultValue.Exposure;
            ExposureSlider.value = DefaultValue.Exposure;
            SkyboxController.Instance.AdjustFogColor = DefaultValue.AdjustFog;
            AdjustFogToggle.isOn = DefaultValue.AdjustFog;
        }

        //---------------------------------------------------------------------
        // Nested
        //---------------------------------------------------------------------

        private static class DefaultValue
        {
            // Sky            
            public static Color TopColor;
            public static Color BottomColor;
            // Stars
            public static Color StarsTint;
            public static float StarsExtinction;
            public static float StarsTwinklingSpeed;
            // Sun
            public static Color SunTint;
            public static float SunSize;
            public static bool SunFlare;
            public static float SunFlareBrightness;
            // Moon
            public static Color MoonTint;
            public static float MoonSize;
            public static bool MoonFlare;
            public static float MoonFlareBrightness;
            // Clouds
            public static float CloudsHeight;
            public static float CloudsOffset;
            public static float CloudsRotationSpeed;
            // General
            public static float Exposure;
            public static bool AdjustFog;
        }
    }
}