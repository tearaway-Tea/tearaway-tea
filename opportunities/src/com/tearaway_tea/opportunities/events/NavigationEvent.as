package com.tearaway_tea.opportunities.events
{
	import flash.events.Event;

	public class NavigationEvent extends Event
	{
		public static const NAVIGATE_LIST_VIEW : String = "navigateListView";
		
		public static const NAVIGATE_EDIT_VIEW : String = "navigateEditView";

		public function NavigationEvent(type : String, bubbles : Boolean = false,
			cancelable : Boolean = false)
		{
			super(type, bubbles, cancelable);
		}
	}
}