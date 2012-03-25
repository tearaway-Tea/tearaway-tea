package com.tearaway_tea.opportunities.events
{
	import flash.events.Event;

	public class OpportunityEvent extends Event
	{
		public static const CREATE_OPPORTUNITY : String = "createOpportunity";
		
		public static const EDIT_OPPORTUNITY : String = "editOpportunity";
		
		public static const SAVE_OPPORTUNITY : String = "saveOpportunity";
		
		public static const CLOSE_OPPORTUNITY : String = "closeOpportunity";
		
		public var data : Object;

		public function OpportunityEvent(type : String, bubbles : Boolean = false,
			cancelable : Boolean = false)
		{
			super(type, bubbles, cancelable);
		}
	}
}