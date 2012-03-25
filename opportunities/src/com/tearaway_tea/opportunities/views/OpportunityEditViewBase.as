package com.tearaway_tea.opportunities.views
{
	import com.tearaway_tea.opportunities.events.OpportunityEvent;
	import com.tearaway_tea.opportunities.interfaces.ICommandButtonsProvider;
	import com.tearaway_tea.opportunities.model.OpportunityVO;
	
	import mx.containers.VBox;

	public class OpportunityEditViewBase extends VBox implements ICommandButtonsProvider
	{
		[Bindable]
		public var commandButtons : Array;
		
		[Bindable]
		public function get opportunity() : OpportunityVO
		{
			return _opportunity;
		}
		
		public function set opportunity(value : OpportunityVO) : void
		{
			_opportunity = value;
		}
		
		protected function onSaveClick() : void
		{
			dispatchEvent(new OpportunityEvent(OpportunityEvent.SAVE_OPPORTUNITY, true));
		}
		
		protected function onCloseClick() : void
		{
			dispatchEvent(new OpportunityEvent(OpportunityEvent.CLOSE_OPPORTUNITY, true));
		}
		
		private var _opportunity : OpportunityVO;
		
	}
}