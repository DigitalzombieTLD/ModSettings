using Il2Cpp;
using Il2CppInterop;
using Il2CppInterop.Runtime.Injection; 
using Il2CppTLD.Platform;
using MelonLoader;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Reflection;


namespace ModSettings
{
	public class ModSettingsMain : MelonMod
	{
        public override void OnInitializeMelon()
		{
            #if DEBUG
						ModSettingsExample.BasicExample.OnLoad();
						ModSettingsExample.OnChangeExample.OnLoad();
						ModSettingsExample.VisibilityExample.OnLoad();
            #endif      
        }

        public override void OnSceneWasInitialized(int buildIndex, string sceneName)
		{
            if (sceneName.Contains("MainMenu"))
            {
                Camera eventCam = GameManager.GetMainCamera();

                if (eventCam != null)
                {
                    EventSystem eventSystem = eventCam.gameObject.GetComponent<EventSystem>();

                    if (!eventSystem)
                    {
                        eventSystem = eventCam.gameObject.AddComponent<EventSystem>();
                    }

                    StandaloneInputModule inputModule = eventCam.gameObject.GetComponent<StandaloneInputModule>();

                    if (!inputModule)
                    {
                        eventCam.gameObject.AddComponent<StandaloneInputModule>();
                    }
                }
            }            
        }
    }
}