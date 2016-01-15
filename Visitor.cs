public static class Demo
{
	private static void Main()
	{
		Point p = new Point2D(1, 2);
		IVisitor v = new Chebyshev();
		p.Accept(v);
		Console.WriteLine(p.Metric);
	}
}

internal interface IVisitor
{
	void Visit(Point2D p);
	void Visit(Point3D p);
}

internal abstract class Point
{
	public double Metric { get; set; } = -1;
	public abstract void Accept(IVisitor visitor);
}

internal class Point2D : Point
{
	public Point2D(double x, double y)
	{
		X = x;
		Y = y;
	}

	public double X { get; }
	public double Y { get; }

	public override void Accept(IVisitor visitor)
	{
		visitor.Visit(this);
	}
}

internal class Point3D : Point
{
	public Point3D(double x, double y, double z)
	{
		X = x;
		Y = y;
		Z = z;
	}

	public double X { get; }
	public double Y { get; }
	public double Z { get; }

	public override void Accept(IVisitor visitor)
	{
		visitor.Visit(this);
	}
}

internal class Euclid : IVisitor
{
	public void Visit(Point2D p)
	{
		p.Metric = Math.Sqrt(p.X*p.X + p.Y*p.Y);
	}

	public void Visit(Point3D p)
	{
		p.Metric = Math.Sqrt(p.X*p.X + p.Y*p.Y + p.Z*p.Z);
	}
}

internal class Chebyshev : IVisitor
{
	public void Visit(Point2D p)
	{
		var ax = Math.Abs(p.X);
		var ay = Math.Abs(p.Y);
		p.Metric = ax > ay ? ax : ay;
	}

	public void Visit(Point3D p)
	{
		var ax = Math.Abs(p.X);
		var ay = Math.Abs(p.Y);
		var az = Math.Abs(p.Z);
		var max = ax > ay ? ax : ay;
		if (max < az) max = az;
		p.Metric = max;
	}
}
