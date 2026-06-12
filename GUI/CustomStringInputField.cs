using Il2Cpp;
using Il2CppInterop.Runtime.Attributes;
using Il2CppInterop.Runtime.Injection;
using UnityEngine;

namespace ModSettings {
	internal class CustomStringInputField : MonoBehaviour {
		static CustomStringInputField() => ClassInjector.RegisterTypeInIl2Cpp<CustomStringInputField>();
		public CustomStringInputField(System.IntPtr intPtr) : base(intPtr) { }

		internal string currentString = string.Empty;
		internal KeyRebindingButton keyRebindingButton;
		internal System.Action OnChange;
		internal string fieldName = "";


        public void Update() {
			if (gameObject.activeSelf && keyRebindingButton.m_ValueLabel.text != currentString) {
				RefreshLabelValue();
			}
		}

		public void OpenInputField()
		{
            InterfaceManager.GetPanel<Panel_Confirmation>().AddConfirmation(Panel_Confirmation.ConfirmationType.Rename, fieldName, currentString, Panel_Confirmation.ButtonLayout.Button_2, "GAMEPLAY_Apply", "GAMEPLAY_Cancel", Panel_Confirmation.Background.Transperent, new Action(MaybeUpdateKey), null);
        }

		[HideFromIl2Cpp]
		internal void OnClick() {
			GameAudioManager.PlayGUIButtonClick();
			OpenInputField();
        }

		[HideFromIl2Cpp]
		internal void RefreshLabelValue() {
			keyRebindingButton.SetValueLabel(currentString);
		}

		[HideFromIl2Cpp]
		private void MaybeUpdateKey() {

            currentString = InterfaceManager.GetPanel<Panel_Confirmation>().m_CurrentGroup.m_InputField.GetText();
			keyRebindingButton.SetValueLabel(currentString);
			OnChange.Invoke();
		}
	}
}
