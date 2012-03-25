package com.tearaway_tea.opportunities.model
{
	import mx.collections.ArrayCollection;
	
	[Bindable]
	public class OpportunityVO
	{
		public static function createOpportunity(id : Number, name : String, 
			startDate : Date, endDate : Date) : OpportunityVO
		{
			var result : OpportunityVO = new OpportunityVO();
			result.id = id;
			result.name = name;
			result.startDate = startDate;
			result.endDate = endDate;
			result.lastUpdate = new Date();
			return result;
		}
				
		public var id : Number;
		
		public var name : String;
		
		public var startDate : Date;
		
		public var endDate : Date;
		
		public var lastUpdate : Date;

	}
}