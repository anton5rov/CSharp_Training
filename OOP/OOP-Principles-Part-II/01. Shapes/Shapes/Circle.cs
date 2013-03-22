using System;

namespace Shapes
{
	public class Circle:Shape
	{
		public Circle(double radius)
		{
			this.Width = radius*2;
			this.Height = radius*2;
		}
		public override double CalculateSurface()
		{
			return Math.PI*(this.Width/2)*(this.Width/2);
		}		
	}
}