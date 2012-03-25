package com.tearaway_tea.opportunities.views
{
	import com.tearaway_tea.opportunities.events.OpportunityEvent;
	import com.tearaway_tea.opportunities.interfaces.ICommandButtonsProvider;
	import com.tearaway_tea.opportunities.model.OpportunityVO;
	
	import mx.collections.ArrayCollection;
	import mx.containers.VBox;
	import mx.controls.DataGrid;
	import mx.controls.dataGridClasses.DataGridColumn;

	public class OpportunitiesListViewBase extends VBox implements ICommandButtonsProvider
	{
		[Bindable]
		public var commandButtons : Array;
		
		[Bindable]
		public var dataGrid : DataGrid;
		
		[Bindable]
		public function get dataProvider() : ArrayCollection
		{
			return _dataProvider;
		}
		
		public function set dataProvider(value : ArrayCollection) : void
		{
			_dataProvider = value;
		}
		
		protected function dateLabelFunction(item : OpportunityVO, column : DataGridColumn) : String
		{
			if (item[column.dataField] != null)
			{
				return (item[column.dataField] as Date).toLocaleDateString();
			}
			else
			{
				return "";
			}
		}
		
		protected function onNewClick() : void
		{
			dispatchEvent(new OpportunityEvent(OpportunityEvent.CREATE_OPPORTUNITY, true));
		}
		
		protected function onEditClick() : void
		{
			var event : OpportunityEvent =
				new OpportunityEvent(OpportunityEvent.EDIT_OPPORTUNITY, true);
			event.data = dataGrid.selectedItem;
			dispatchEvent(event);
		}
		
		protected function onGridDoubleClick() : void
		{
			onEditClick();
		}

		private var _dataProvider : ArrayCollection;
	}
}