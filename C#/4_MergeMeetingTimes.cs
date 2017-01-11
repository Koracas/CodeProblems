using System;
using System.Collections.Generic;     // Include for lists


// To execute C#, please define "static void Main" on a class// named Solution.


class Solution
{
    public List<int[]> mergeRanges( List<int[]> curMeetingTimes )
    {
        //  Check input
        if( curMeetingTimes.Count == 0 )
        {
            throw new ArgumentException("There needs to be meeting time in order to merge");
        }
       
        //  List of updated meetings times
        List<int []> updatedMeetingTimes  =  new List<int []>();

        //  TODO :: When implementing sort it will go here 
       
        //    Record the currentBlock time
        int[] currentBlock = new int[]{0,0};
     
        //    If I had LINQ I would use foreach cause it allows me to find the last and first
        //    Loop through the inputs to see if there is overlap or touch 

        for( int iMeetTime = 0; iMeetTime < curMeetingTimes.Count; iMeetTime++)
        {
            //  If first element
            if( iMeetTime == 0 ){
                currentBlock[0] = curMeetingTimes[0][0];
                currentBlock[1] = curMeetingTimes[0][1];             
            }
            else {
                //  If startTime of the new block is less or equal to the endTime of the old block = intersection
                if( curMeetingTimes[iMeetTime][0] <= currentBlock[1] )
                {
                    //  Take max of endTime to determine endTime
                    currentBlock[1] = Math.Max(currentBlock[1] , curMeetingTimes[iMeetTime][1]  );
                    //  Take the min of the startTime to determine the startTime
                    currentBlock[0] = Math.Min(currentBlock[0] , curMeetingTimes[iMeetTime][0]  );
                   
                    //  This is the last one
                    if( iMeetTime == curMeetingTimes.Count - 1) 
                    {
                        //    Add this current block to the final answer list
                        updatedMeetingTimes.Add(new int[] { currentBlock[0] , currentBlock[1]});
                        //    Take new block values as current block values
                        currentBlock[0] = curMeetingTimes[iMeetTime][0];
                        currentBlock[1] = curMeetingTimes[iMeetTime][1]; 
                    }
                }
                else // there is no intersection
                {
                    //  Add this current block to the final answer list
                    updatedMeetingTimes.Add(new int[] { currentBlock[0] , currentBlock[1]});
                    //  Take new block values as current block values
                    currentBlock[0] = curMeetingTimes[iMeetTime][0];
                    currentBlock[1] = curMeetingTimes[iMeetTime][1]; 
                }
            }
           
           
            Console.WriteLine("[{0},{1}]" ,curMeetingTimes[iMeetTime][0], curMeetingTimes[iMeetTime][1]);
            Console.WriteLine("currentBlock :: [{0},{1}]" ,currentBlock[0], currentBlock[1]); 
        }
   
        return updatedMeetingTimes;
    }
   
    static void Main(string[] args)
    {
        //  List of meetings :: Assumed to be sorted O(nlgn) worst case
        List<int []> meetingTimes =  new List<int []>();
        meetingTimes.Add( new int[] {0,1});
        meetingTimes.Add( new int[] {3,5});
        meetingTimes.Add( new int[] {4,8});
        meetingTimes.Add( new int[] {9,10});
        meetingTimes.Add( new int[] {10,12});
        meetingTimes.Add( new int[] {12,13});
       
        //    Get the answers
        Solution mySolution = new Solution();
        List<int []> mergedMeetingTimes = mySolution.mergeRanges(meetingTimes);
       
        //    Loop through an output the answers
        foreach( var mergeTime in mergedMeetingTimes)
        {
            Console.WriteLine("[{0},{1}]" ,mergeTime[0], mergeTime[1]);
        }
    }}

