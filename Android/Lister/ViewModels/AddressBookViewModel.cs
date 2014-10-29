﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Lister
{
	public class AddressBookViewModel
	{
		private readonly AddressBook _addressBook;
		private readonly PersonSelection _personSelection;

		public AddressBookViewModel (
			AddressBook addressBook,
			PersonSelection personSelection)
		{
			_addressBook = addressBook;
			_personSelection = personSelection;
		}

		public IEnumerable<PersonViewModel> People
		{
			get
			{
				return _addressBook.People
					.OrderBy (person => person.Name)
					.Select (person => new PersonViewModel (person));
			}
		}

		public string NewName
		{
			get { return _personSelection.NewName; }
			set { _personSelection.NewName = value; }
		}

		public bool CanAddPerson
		{
			get { return !String.IsNullOrEmpty (_personSelection.NewName); }
		}

		public void AddPerson()
		{
			_addressBook.NewPerson().Name = _personSelection.NewName;
			_personSelection.NewName = "";
		}
	}
}

