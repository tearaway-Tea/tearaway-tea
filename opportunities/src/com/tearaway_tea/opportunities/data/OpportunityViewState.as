package com.tearaway_tea.opportunities.data
{
	public class OpportunityViewState
	{
		[Bindable]
		public var selectedIndex : Number = 0;
		
		public function setSelectedIndex(index : Number) : void
		{
			selectedIndex = index;
		}
	}
}