using System;

// To execute C#, please define "static void Main" on a class
// named Solution.

class TempTracker
{
    //    Variables
    private int maxTemp;
    private int minTemp;
    private int sumTemp;
    private int tempCount;
    private int modeTemp;
    private int [] tempuratures;
    private int maxOccurance;
    
    //    Constructor
    public TempTracker()
    {
        this.maxTemp = System.Int32.MinValue;
        this.minTemp = System.Int32.MaxValue;
        this.sumTemp = 0;
        this.tempCount = 0;
        this.tempuratures = new int[111];
        this.maxOccurance = 0;
        this.modeTemp = 0;
    }
    
    
    //    records a new temperature
    public void insert( int newTemp )
    {
        if( newTemp < 0 )
        {
            throw new ArgumentException( "No negative tempurtures" );
        }
        
        if( newTemp >= 110 )
        {
            throw new ArgumentException( "No tempuratures above 110" );
        }
        
        //    Increment record count
        this.tempCount ++;
        //    Increment total temp
        this.sumTemp += newTemp;
        
        //    Determine max temp vs cur temp
        this.maxTemp = Math.Max(this.maxTemp , newTemp );
        
        //    Determine min temp vs cur temp
        this.minTemp = Math.Min( this.minTemp , newTemp );
        
        // Record that this occurance has happened
        this.tempuratures[newTemp] = this.tempuratures[newTemp] + 1;
        
        //    Current occurence is greater than the max 
        if( this.maxOccurance < this.tempuratures[newTemp] )
        {
            //    Record this as the new max 
            this.maxOccurance = this.tempuratures[newTemp];
            
            this.modeTemp = newTemp;            
        }
        
    }
    
    //    returns the highest temp we've seen so far
    public int getMax()
    {
        return this.maxTemp;
    }
    
    //    returns the lowest temp we've seen so far
    public int getMin()
    {
        return this.minTemp;
    }
    //    returns the mean of all temps we've seen so far
    public float getMean()
    {
        if( this.tempCount != 0 )
        {
            return (float)this.sumTemp / (float)this.tempCount;
        }
        else{
            return 0;
        }
    }
    //    returns a mode of all temps we've seen so far
    public int getMode()
    {
        return this.modeTemp;
    }
    
    
    //
    //    MAIN
    //
    static void Main(string[] args)
    {
        TempTracker myTracker = new TempTracker();
        myTracker.insert( 70 );
        myTracker.insert( 71 );
        myTracker.insert( 85 );
        myTracker.insert( 100 );
        myTracker.insert( 20 );
        myTracker.insert( 75 );
        myTracker.insert( 70 );
        myTracker.insert( 99 );
        myTracker.insert( 100 );

        
        Console.WriteLine("TempTracker Output: ");
        Console.WriteLine("\t Max  : {0}" , myTracker.getMax());
        Console.WriteLine("\t Min  : {0}" , myTracker.getMin());
        Console.WriteLine("\t Mean : {0:0.##}" , myTracker.getMean());
        Console.WriteLine("\t Mode : {0}" , myTracker.getMode());
        
    }
    
}

