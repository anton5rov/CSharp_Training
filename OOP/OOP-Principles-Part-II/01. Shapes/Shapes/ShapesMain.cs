using  System;
namespace Shapes
{
	public class ShapesMain
	{
		static void Main()
		{
			Shape[] shapes = new Shape[3];            
			shapes[0] = new Triangle(3, 4);
			shapes[1] = new Rectangle(3, 4);
			shapes[2] = new Circle(3);
			
			for (int i = 0; i < 3; i++)
			{
				Console.WriteLine("The surface of the {0} is {1}.", shapes[i].GetType().Name, shapes[i].CalculateSurface());
			}			
		}
	}
}