package com.tearaway_tea.opportunities.data
{
	import com.asfusion.mate.events.Dispatcher;
	import com.tearaway_tea.opportunities.events.DataProviderEvent;
	import com.tearaway_tea.opportunities.model.OpportunityVO;
	import com.tearaway_tea.opportunities.services.OpportunitiesMockService;

	public class OpportunityDataProvider
	{
		[Bindable]
		public var opportunity : OpportunityVO;
		
		public function createOpportunity() : void
		{
			opportunity = new OpportunityVO();
			new Dispatcher().dispatchEvent(
				new DataProviderEvent(DataProviderEvent.OPPORTUNITY_CREATED));
		}
		
		public function editOpportunity(opportunity : OpportunityVO) : void
		{
			this.opportunity = opportunity;
		}
		
		public function saveOpportunity() : void
		{
			opportunity.lastUpdate = new Date();
			new OpportunitiesMockService(onUpdateOpportunity).updateOpportunity(opportunity);
			
			function onUpdateOpportunity(result : OpportunityVO) : void
			{
				opportunity = result;
				new Dispatcher().dispatchEvent(
					new DataProviderEvent(DataProviderEvent.OPPORTUNITY_SAVED));
			}
		}
	}
}