using BionicApp.Pages.Add_Device.My_Devices.DeviceSettings;
using Bunit;
using MudBlazor;
using Ossur.Bionics.Common.Models.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BionicAppTestRunner.BionicAppUi
{
    public class SettingsUITest : BionicAppUiTestBase
    {
        [Fact]
        public void BackButton_AreDisplayed()
        {

            var component = RenderComponent<Settings>();
            var button = component.FindComponent<MudButton>();
            var BackButton = component.FindAll("button").FirstOrDefault(b => b.TextContent == "ArrowBack");
            Assert.NotNull(BackButton);
        }

        [Fact]

        public void Device_IsDisplayed() 
        {
            var component = RenderComponent<Settings>();
            var peripheral = new Peripheral();
            var text = component.FindComponent<MudText>();
            var expectedDisplayName = component.FindAll("DisplayName").FirstOrDefault(b => b.TextContent == "MyDevice");
            peripheral.SetValue("displayName", expectedDisplayName);
            var actualDisplayName = peripheral.DisplayName;
            Assert.Equal("expectedDisplayName", actualDisplayName);
        }

        [Fact]

        public void OnRelaxModeClicked()
        { 
            var component = RenderComponent<Settings>();
            var button = component.FindComponent<MudButton>();
            button.Find("#OnRelaxModeClicked").DoubleClick();
            var text = component.FindComponent<MudText>();
            Assert.Null("RelaxMode");
        }
        
         [Fact]

        public void Vibration_feedbackIsShowing()
        {
            var component = RenderComponent<Settings>();
            var text = component.FindComponent<MudText>();
            Assert.Equal("Vibrationfeedback", text.Find("50%").TextContent);
        }

        [Fact]

        public void Name1_Name2_TogglesAreDisplayed()
        {
            var component = RenderComponent<Settings>();
            var text = component.FindComponent<MudText>();
            Assert.Equal("name1", "name2");
            Switch switchControl = new Switch { IsToggled = true };
            var togglebutton = component.FindAll("button").FirstOrDefault(b => b.TextContent == "enabled");
            var istoggleButtonDisabled = togglebutton?.HasAttribute("disabled") ?? false;

            Assert.False(istoggleButtonDisabled);
        }

        [Fact]
        
        public void AllFieldsAndButtons_AreDisplayed()
        {
            var component = RenderComponent<Settings>();
            var text = component.FindComponent<MudText>();
            Assert.Equal("advancesettings", text.Find("h5").TextContent);
            Assert.Equal("RampAdaption",text.Find("value").TextContent);
            var value1 = component.FindAll("value1").FirstOrDefault(b => b.TextContent == "inclined_ua");
            var value2 = component.FindAll("value2").FirstOrDefault(b => b.TextContent == "declined_ua");
            Assert.Equal(value1.TextContent, value2.TextContent);
        }

    }

    

}










