package com.tearaway_tea.opportunities.data
{
	import com.tearaway_tea.opportunities.services.OpportunitiesMockService;
	
	import mx.collections.ArrayCollection;

	public class OpportunitiesDataProvider extends ArrayCollection
	{
		public function OpportunitiesDataProvider()
		{
			super();
			populate();
		}
		
		public function populate() : void
		{
			new OpportunitiesMockService(onGetOpportunitiesList).getOpportunitiesList();
		}
		
		private function onGetOpportunitiesList(result : ArrayCollection) : void
		{
			source = result.toArray();
			refresh();
		}
	}
}