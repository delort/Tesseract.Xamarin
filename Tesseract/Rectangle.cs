﻿namespace Tesseract { 
	using System.Diagnostics; 

	using System;
	using System.IO;
	using System.ComponentModel;
	using System.Globalization; 


	[System.Runtime.InteropServices.ComVisible(true)]
	public struct Rectangle { 

		/// <include file="doc\Rectangle.uex" path="docs/doc[@for="Rectangle.Empty"]/*"> 
		/// <devdoc> 
		///    <para>
		///       Stores the location and size of a rectangular region. For 
		///       more advanced region functions use a <see cref="System.Drawing.Region">
		///       object.
		///    </see></para>
		/// </devdoc> 
		public static readonly Rectangle Empty = new Rectangle();

		private int x; 
		private int y;
		private int width; 
		private int height;

		/// <include file="doc\Rectangle.uex" path="docs/doc[@for="Rectangle.Rectangle"]/*">
		/// <devdoc> 
		///    <para>
		///       Initializes a new instance of the <see cref="System.Drawing.Rectangle"> 
		///       class with the specified location and size. 
		///    </see></para>
		/// </devdoc> 
		public Rectangle(int x, int y, int width, int height) {
			this.x = x;
			this.y = y;
			this.width = width; 
			this.height = height;
		}

		/// <include file="doc\Rectangle.uex" path="docs/doc[@for="Rectangle.FromLTRB"]/*"> 
		/// <devdoc>
		///    Creates a new <see cref="System.Drawing.Rectangle"> with 
		///    the specified location and size. 
		/// </see></devdoc>
		// !! Not in C++ version 
		public static Rectangle FromLTRB(int left, int top, int right, int bottom) {
			return new Rectangle(left,
				top,
				right - left, 
				bottom - top);
		}

		/// <include file="doc\Rectangle.uex" path="docs/doc[@for="Rectangle.X"]/*">
		/// <devdoc> 
		///    Gets or sets the x-coordinate of the 
		///    upper-left corner of the rectangular region defined by this <see cref="System.Drawing.Rectangle">.
		/// </see></devdoc> 
		public int X {
			get {
				return x;
			} 
			set {
				x = value; 
			} 
		}

		/// <include file="doc\Rectangle.uex" path="docs/doc[@for="Rectangle.Y"]/*">
		/// <devdoc>
		///    Gets or sets the y-coordinate of the
		///    upper-left corner of the rectangular region defined by this <see cref="System.Drawing.Rectangle">. 
		/// </see></devdoc>
		public int Y { 
			get { 
				return y;
			} 
			set {
				y = value;
			}
		} 

		/// <include file="doc\Rectangle.uex" path="docs/doc[@for="Rectangle.Width"]/*"> 
		/// <devdoc> 
		///    Gets or sets the width of the rectangular
		///    region defined by this <see cref="System.Drawing.Rectangle">. 
		/// </see></devdoc>
		public int Width {
			get {
				return width; 
			}
			set { 
				width = value; 
			}
		} 

		/// <include file="doc\Rectangle.uex" path="docs/doc[@for="Rectangle.Height"]/*">
		/// <devdoc>
		///    Gets or sets the width of the rectangular 
		///    region defined by this <see cref="System.Drawing.Rectangle">.
		/// </see></devdoc> 
		public int Height { 
			get {
				return height; 
			}
			set {
				height = value;
			} 
		}

		/// <include file="doc\Rectangle.uex" path="docs/doc[@for="Rectangle.Left"]/*"> 
		/// <devdoc>
		///    <para> 
		///       Gets the x-coordinate of the upper-left corner of the
		///       rectangular region defined by this <see cref="System.Drawing.Rectangle"> .
		///    </see></para>
		/// </devdoc> 
		public int Left { 
			get { 
				return X;
			} 
		}
		/// <include file="doc\Rectangle.uex" path="docs/doc[@for="Rectangle.Top"]/*">
		/// <devdoc>
		///    <para> 
		///       Gets the y-coordinate of the upper-left corner of the
		///       rectangular region defined by this <see cref="System.Drawing.Rectangle">. 
		///    </see></para> 
		/// </devdoc>
		public int Top {
			get {
				return Y;
			} 
		}

		/// <include file="doc\Rectangle.uex" path="docs/doc[@for="Rectangle.Right"]/*"> 
		/// <devdoc>
		///    <para> 
		///       Gets the x-coordinate of the lower-right corner of the
		///       rectangular region defined by this <see cref="System.Drawing.Rectangle">.
		///    </see></para>
		/// </devdoc> 
		public int Right { 
			get { 
				return X + Width;
			} 
		}

		/// <include file="doc\Rectangle.uex" path="docs/doc[@for="Rectangle.Bottom"]/*">
		/// <devdoc> 
		///    <para>
		///       Gets the y-coordinate of the lower-right corner of the 
		///       rectangular region defined by this <see cref="System.Drawing.Rectangle">. 
		///    </see></para>
		/// </devdoc> 
		public int Bottom {
			get {
				return Y + Height; 
			}
		} 

		/// <include file="doc\Rectangle.uex" path="docs/doc[@for="Rectangle.IsEmpty"]/*">
		/// <devdoc> 
		///    <para>
		///       Tests whether this <see cref="System.Drawing.Rectangle"> has a <see cref="System.Drawing.Rectangle.Width">
		///       or a <see cref="System.Drawing.Rectangle.Height"> of 0.
		///    </see></see></see></para> 
		/// </devdoc>
		public bool IsEmpty { 
			get {
				return height == 0 && width == 0 && x == 0 && y == 0; 
				// C++ uses this definition:
				// return(Width <= 0 )|| (Height <= 0);
			}
		} 

		/// <include file="doc\Rectangle.uex" path="docs/doc[@for="Rectangle.Equals"]/*"> 
		/// <devdoc> 
		///    <para>
		///       Tests whether <paramref name="obj"> is a <see cref="System.Drawing.Rectangle"> with 
		///       the same location and size of this Rectangle.
		///    </see></paramref></para>
		/// </devdoc>
		public override bool Equals(object obj) { 
			if (!(obj is Rectangle))
				return false; 

			Rectangle comp = (Rectangle)obj;

			return(comp.X == this.X) &&
				(comp.Y == this.Y) &&
				(comp.Width == this.Width) &&
				(comp.Height == this.Height); 
		}

		/// <include file="doc\Rectangle.uex" path="docs/doc[@for="Rectangle.operator=="]/*"> 
		/// <devdoc>
		///    <para> 
		///       Tests whether two <see cref="System.Drawing.Rectangle">
		///       objects have equal location and size.
		///    </see></para>
		/// </devdoc> 
		public static bool operator ==(Rectangle left, Rectangle right) {
			return (left.X == right.X 
				&& left.Y == right.Y 
				&& left.Width == right.Width
				&& left.Height == right.Height); 
		}

		/// <include file="doc\Rectangle.uex" path="docs/doc[@for="Rectangle.operator!="]/*">
		/// <devdoc> 
		///    <para>
		///       Tests whether two <see cref="System.Drawing.Rectangle"> 
		///       objects differ in location or size. 
		///    </see></para>
		/// </devdoc> 
		public static bool operator !=(Rectangle left, Rectangle right) {
			return !(left == right);
		}

		/// <include file="doc\Rectangle.uex" path="docs/doc[@for="Rectangle.Contains"]/*">
		/// <devdoc> 
		///    <para> 
		///       Determines if the specfied point is contained within the
		///       rectangular region defined by this <see cref="System.Drawing.Rectangle"> . 
		///    </see></para>
		/// </devdoc>
		public bool Contains(int x, int y) {
			return this.X <= x && 
				x < this.X + this.Width &&
				this.Y <= y && 
				y < this.Y + this.Height; 
		}

		/// <include file="doc\Rectangle.uex" path="docs/doc[@for="Rectangle.Contains2"]/*">
		/// <devdoc> 
		///    <para>
		///       Determines if the rectangular region represented by 
		///    <paramref name="rect"> is entirely contained within the rectangular region represented by 
		///       this <see cref="System.Drawing.Rectangle"> .
		///    </see></paramref></para> 
		/// </devdoc>
		public bool Contains(Rectangle rect) {
			return(this.X <= rect.X) &&
				((rect.X + rect.Width) <= (this.X + this.Width)) && 
				(this.Y <= rect.Y) &&
				((rect.Y + rect.Height) <= (this.Y + this.Height)); 
		} 

		// !! Not in C++ version 
		/// <include file="doc\Rectangle.uex" path="docs/doc[@for="Rectangle.GetHashCode"]/*">
		/// <devdoc>
		///    <para>[To be supplied.]</para>
		/// </devdoc> 
		public override int GetHashCode() {
			return(int)((UInt32)X ^ 
				(((UInt32)Y << 13) | ((UInt32)Y >> 19)) ^ 
				(((UInt32)Width << 26) | ((UInt32)Width >>  6)) ^
				(((UInt32)Height <<  7) | ((UInt32)Height >> 25))); 
		}

		/// <include file="doc\Rectangle.uex" path="docs/doc[@for="Rectangle.Inflate"]/*">
		/// <devdoc> 
		///    <para>
		///       Inflates this <see cref="System.Drawing.Rectangle"> 
		///       by the specified amount. 
		///    </see></para>
		/// </devdoc> 
		public void Inflate(int width, int height) {
			this.X -= width;
			this.Y -= height;
			this.Width += 2*width; 
			this.Height += 2*height;
		}

		/// <include file="doc\Rectangle.uex" path="docs/doc[@for="Rectangle.Inflate2"]/*">
		/// <devdoc> 
		///    <para>
		///       Creates a <see cref="System.Drawing.Rectangle">
		///       that is inflated by the specified amount.
		///    </see></para> 
		/// </devdoc>
		// !! Not in C++ 
		public static Rectangle Inflate(Rectangle rect, int x, int y) { 
			Rectangle r = rect;
			r.Inflate(x, y); 
			return r;
		}

		/// <include file="doc\Rectangle.uex" path="docs/doc[@for="Rectangle.Intersect"]/*"> 
		/// <devdoc> Creates a Rectangle that represents the intersection between this Rectangle and rect.
		/// </devdoc> 
		public void Intersect(Rectangle rect) { 
			Rectangle result = Rectangle.Intersect(rect, this);

			this.X = result.X;
			this.Y = result.Y;
			this.Width = result.Width;
			this.Height = result.Height; 
		}
		/// <include file="doc\Rectangle.uex" path="docs/doc[@for="Rectangle.Intersect1"]/*"> 
		/// <devdoc> 
		///    Creates a rectangle that represents the intersetion between a and
		///    b. If there is no intersection, null is returned. 
		/// </devdoc>
		public static Rectangle Intersect(Rectangle a, Rectangle b) {
			int x1 = Math.Max(a.X, b.X);
			int x2 = Math.Min(a.X + a.Width, b.X + b.Width); 
			int y1 = Math.Max(a.Y, b.Y);
			int y2 = Math.Min(a.Y + a.Height, b.Y + b.Height); 

			if (x2 >= x1
				&& y2 >= y1) { 

				return new Rectangle(x1, y1, x2 - x1, y2 - y1);
			}
			return Rectangle.Empty; 
		}

		/// <include file="doc\Rectangle.uex" path="docs/doc[@for="Rectangle.IntersectsWith"]/*"> 
		/// <devdoc>
		///     Determines if this rectangle intersets with rect. 
		/// </devdoc>
		public bool IntersectsWith(Rectangle rect) {
			return(rect.X < this.X + this.Width) &&
				(this.X < (rect.X + rect.Width)) && 
				(rect.Y < this.Y + this.Height) &&
				(this.Y < rect.Y + rect.Height); 
		} 

		/// <include file="doc\Rectangle.uex" path="docs/doc[@for="Rectangle.Union"]/*"> 
		/// <devdoc>
		///    <para>
		///       Creates a rectangle that represents the union between a and
		///       b. 
		///    </para>
		/// </devdoc> 
		public static Rectangle Union(Rectangle a, Rectangle b) { 
			int x1 = Math.Min(a.X, b.X);
			int x2 = Math.Max(a.X + a.Width, b.X + b.Width); 
			int y1 = Math.Min(a.Y, b.Y);
			int y2 = Math.Max(a.Y + a.Height, b.Y + b.Height);

			return new Rectangle(x1, y1, x2 - x1, y2 - y1); 
		}

		/// <include file="doc\Rectangle.uex" path="docs/doc[@for="Rectangle.Offset1"]/*">
		/// <devdoc> 
		///    Adjusts the location of this rectangle by the specified amount.
		/// </devdoc>
		public void Offset(int x, int y) {
			this.X += x; 
			this.Y += y;
		} 

		/// <include file="doc\Rectangle.uex" path="docs/doc[@for="Rectangle.ToString"]/*">
		/// <devdoc> 
		///    <para>
		///       Converts the attributes of this <see cref="System.Drawing.Rectangle"> to a
		///       human readable string.
		///    </see></para> 
		/// </devdoc>
		public override string ToString() { 
			return "{X=" + X.ToString(CultureInfo.CurrentCulture) + ",Y=" + Y.ToString(CultureInfo.CurrentCulture) + 
				",Width=" + Width.ToString(CultureInfo.CurrentCulture) +
				",Height=" + Height.ToString(CultureInfo.CurrentCulture) + "}"; 
		}
	}
}