using System;
using Xamarin.Forms;

namespace ToTheMasjid
{
	public class CustomCell : ViewCell
	{
		public CustomCell()
		{
			//instantiate each of our views
			Label lblJoke = new Label();
			lblJoke.LineBreakMode = LineBreakMode.WordWrap;
			lblJoke.SetBinding(Label.TextProperty, "name");
			View = lblJoke;
		}

	}

}
