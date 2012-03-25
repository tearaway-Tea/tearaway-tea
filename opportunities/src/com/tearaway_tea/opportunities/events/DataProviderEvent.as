package com.tearaway_tea.opportunities.events
{
	import flash.events.Event;

	public class DataProviderEvent extends Event
	{
		public static const OPPORTUNITY_CREATED : String = "opportunityCreated";
		
		public static const OPPORTUNITY_SAVED : String = "opportunitySaved";

		public function DataProviderEvent(type : String, bubbles : Boolean = false,
			cancelable : Boolean = false)
		{
			super(type, bubbles, cancelable);
		}

	}
}