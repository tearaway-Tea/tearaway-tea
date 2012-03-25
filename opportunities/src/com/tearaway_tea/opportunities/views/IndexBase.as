package com.tearaway_tea.opportunities.views
{
	import com.tearaway_tea.opportunities.interfaces.ICommandButtonsProvider;
	
	import mx.containers.HBox;
	import mx.containers.VBox;
	import mx.containers.ViewStack;
	import mx.core.UIComponent;

	public class IndexBase extends VBox
	{
		public var commandButtonsBox : HBox;
		
		public var viewStack : ViewStack;
		
		[Bindable]
		public var selectedIndex : Number = 0;
		
		protected function onChange() : void
		{
			updateCommandButtons();
		}
		
		protected function onListViewCreationComplete() : void
		{
			updateCommandButtons();
		}
		
		private function updateCommandButtons() : void
		{
			commandButtonsBox.removeAllChildren();
			
			if (viewStack.selectedChild != null)
			{
				for each (var button : UIComponent in 
					ICommandButtonsProvider(viewStack.selectedChild).commandButtons)
				{
					commandButtonsBox.addChild(button);
				}
			}
		}
	}
}