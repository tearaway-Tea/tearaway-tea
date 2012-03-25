package com.tearaway_tea.opportunities.services
{
	import com.tearaway_tea.opportunities.model.OpportunityVO;
	
	import mx.collections.ArrayCollection;
	
	public class OpportunitiesMockService
	{
		protected static var opportunities : Array = [
				OpportunityVO.createOpportunity(0, "Get money from the unkle", 
					new Date(2005, 10, 5), new Date(2006, 11, 26)),
				OpportunityVO.createOpportunity(1, "Win a Jack-Pot", 
					new Date(2008, 6, 3), new Date(2010, 10, 13)),
				OpportunityVO.createOpportunity(3, "Found a treasure", 
					new Date(2009, 9, 2), new Date(2011, 7, 25)),
				OpportunityVO.createOpportunity(4, "Get lost in a tropical island", 
					new Date(2010, 5, 17), new Date(2015, 12, 29))
			];
			
		public function OpportunitiesMockService(resultHandler : Function = null, faultHandler : Function = null)
		{
			_resultHandler = resultHandler;
			_faultHandler = faultHandler;
		}
		
		public function getOpportunitiesList() : void
		{
			if (_resultHandler != null)
			{
				_resultHandler(new ArrayCollection(opportunities));
			}
		}
		
		public function updateOpportunity(opportunity : OpportunityVO) : void
		{
			var found : Boolean;
			
			if (!isNaN(opportunity.id))
			{
				for each (var item : OpportunityVO in opportunities)
				{
					if (item.id == opportunity.id)
					{
						found = true;
						break;
					}
				}
			}
			else
			{
				opportunity.id = OpportunityVO(opportunities[opportunities.length - 1]).id + 1;
			}
			
			if (!found)
			{
				opportunities.push(opportunity);
			}
			
			if (_resultHandler != null)
			{
				_resultHandler(opportunity);
			}
		}
		
		private var _resultHandler : Function;
		
		private var _faultHandler : Function;
	}
}