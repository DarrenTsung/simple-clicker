using System;
using UnityEngine;


namespace InControl
{
	/// <summary>
	/// "Custom profiles" are deprecated in favor of the new user bindings API.
	/// See the PlayerAction and PlayerActionSet classes which accomplish the same goal
	/// much more elegantly and supports runtime remapping.
	/// http://www.gallantgames.com/pages/incontrol-binding-actions-to-controls 
	/// </summary>
	[Obsolete( "Custom profiles are deprecated. Use the bindings API instead.", false )]
	public class CustomInputDeviceProfile : InputDeviceProfile
	{
		public CustomInputDeviceProfile()
		{
			Name = "Custom Device Profile";
			Meta = "Custom Device Profile";

			SupportedPlatforms = new[] {
				"Windows",
				"Mac",
				"Linux"
			};

			Sensitivity = 1.0f;
			LowerDeadZone = 0.0f;
			UpperDeadZone = 1.0f;
		}


		public sealed override bool IsKnown
		{ 
			get
			{
				return true;
			}
		}


		public sealed override bool IsJoystick
		{ 
			get
			{ 
				return false; 
			} 
		}


		public sealed override bool HasJoystickName( string joystickName )
		{
			return false;
		}


		public sealed override bool HasLastResortRegex( string joystickName )
		{
			return false;
		}


		public sealed override bool HasJoystickOrRegexName( string joystickName )
		{
			return false;
		}


		#region InputControlSource Helpers

		protected static InputControlSource KeyCodeButton( params KeyCode[] keyCodeList )
		{
			return new UnityKeyCodeSource( keyCodeList );
		}

		protected static InputControlSource KeyCodeComboButton( params KeyCode[] keyCodeList )
		{
			return new UnityKeyCodeComboSource( keyCodeList );
		}

		#endregion
	}
}

