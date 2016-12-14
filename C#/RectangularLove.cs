using System;

// To execute C#, please define "static void Main" on a class
// named Solution.

class Rectangle {
        
        //  Variables
        public int leftX_ { get; private set;}
        public int bottomY_ { get; private set;}
        public int width_ { get; private set;}
        public int height_ { get; private set;}
        
        //  Consturctor 
        public Rectangle(){
            this.leftX_ = 0;
            this.bottomY_ = 0;
            this.width_ = 0;
            this.height_ = 0;
        }
        
        //  Consturctor 
        public Rectangle(int leftX, int bottomY, int width, int height)
        {
            this.leftX_ = leftX;
            this.bottomY_ = bottomY;
            this.width_ = width;
            this.height_ = height;
        }

        
        //    operation == override
        public static bool operator == (Rectangle x, Rectangle y) 
        {
            if (object.ReferenceEquals(x, null) || object.ReferenceEquals(y, null)  )
            {
                return false;
            }
            return x.leftX_ == y.leftX_ &&
                x.bottomY_ == y.bottomY_ &&
                x.width_ == y.width_ &&
                x.height_ == y.height_;
        }
        
        //    oppertion != override
        public static bool operator!= (Rectangle x, Rectangle y) 
        {
            if (object.ReferenceEquals(x, null) || object.ReferenceEquals(y, null)  )
            {
                return false;
            }
            return x.leftX_ != y.leftX_ ||
                x.bottomY_ != y.bottomY_ ||
                x.width_ != y.width_ ||
                x.height_ != y.height_;
        }
    
        //    Equals override
        public override bool Equals(object obj)
        {
            var item = obj as Rectangle;
            if(obj == null)
            {
                return false;
            }
            return this.leftX_.Equals(item.leftX_) &&
                this.bottomY_.Equals(item.bottomY_) &&
                this.width_.Equals(item.width_) &&
                this.height_.Equals(item.height_);
        }

        //    Gethashcode override
        public override int GetHashCode()
        {
          return leftX_.GetHashCode() ^ bottomY_.GetHashCode() ^ width_.GetHashCode() ^ height_.GetHashCode();
        }

    }

class Solution
{

    
 
    //
    //
    // 
    public Rectangle findRectangularOverlap( Rectangle rect1, Rectangle rect2 )
    {
        //    Determine where intersection happens on the X-axis
        // ----------------------------------------------------------------------------------------
        
        //    Get the right most rectangle is the starting point if there is an overlap
        int rightMost = Math.Max( rect1.leftX_ , rect2.leftX_ );
        //    The overlap endpoint will be the right most endpoint
        int rightEndpoint = Math.Min( rect1.leftX_ + rect1.width_ , rect2.leftX_ + rect2.width_ );
        
        int width = 0;
        
        if( rightEndpoint <= rightMost )
        {
            Console.WriteLine( "Rectangles do not overlap on the x-axis.");
            width = -1;
            rightMost = -1;
        }
        else 
        {
            //    The width is the difference
            width = rightEndpoint - rightMost;    
        }
                
        //    Determine where intersection happens on the Y-axis
        // ----------------------------------------------------------------------------------------
        
        //    Get the top most point as it is the starting point of the overlap 
        int topMost = Math.Max( rect1.bottomY_ , rect2.bottomY_ );
        //    The overlap endpoint will be the lowest endpoint
        int lowestEndpoint = Math.Min ( rect1.bottomY_ + rect1.height_ , rect2.bottomY_ + rect2.height_ );
        
        int height = 0;
        
        if( lowestEndpoint <= topMost )
        {
            Console.WriteLine( "Rectangles do not overlap on the y-axis.");
            height = -1;
            topMost = -1;
        }
        else 
        {
            //    The width is the difference
            height = lowestEndpoint - topMost;    
        }
        
        //    Declare answer rectangle
        Rectangle answer = new Rectangle( rightMost , topMost , width , height );        
 

        return answer;
    }
    
    //
    //    Main
    //
    static void Main(string[] args)
    {
        //    Declare a new solution
        Solution mySolution = new Solution();
        
        //    Declare the problem space
        Rectangle rectangle1 = new Rectangle( 0, 4, 5, 3);
        Rectangle rectangle2 = new Rectangle( 2, 6, 7, 3);

        
        Rectangle theAnswer = mySolution.findRectangularOverlap( rectangle1, rectangle2);
        
        Console.WriteLine("Overlapping rectangle at left:{0}, bottom:{1} , width:{2}, height:{3}." , theAnswer.leftX_, theAnswer.bottomY_, theAnswer.width_, theAnswer.height_);
        
    }
}
