package com.tearaway_tea.model
{
	import flash.events.EventDispatcher;

	import mx.collections.ArrayCollection;

	import org.goverla.interfaces.IPropertiesInvalidable;
	import org.goverla.managers.PropertiesInvalidationManager;

	public class OpportunityDTO extends EventDispatcher implements IPropertiesInvalidable
	{
		public function get date() : Date
		{
			return _date;
		}

		public function set date(value : Date) : void
		{
			_date = value;
			_dateChanged = true;
			invalidateProperties();
		}

		public function get children() : ArrayCollection
		{
			return _children;
		}

		public function set children(value : ArrayCollection) : void
		{
			_children = value;
			_childrenChanged = true;
			invalidateProperties();
		}

		public function invalidateProperties() : void
		{
			PropertiesInvalidationManager.instance.invalidateProperties(this);
		}

		public function commitProperties() : void
		{
			if (_dateChanged && _childrenChanged)
			{
				_dateChanged = false;
				_childrenChanged = false;

				for each (var item : ItemDTO in children)
				{
					item.name += "/" + date.toString();
				}
			}
		}

		private var _date : Date;

		private var _dateChanged : Boolean;

		private var _children : ArrayCollection;

		private var _childrenChanged : Boolean;
	}
}