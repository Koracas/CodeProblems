using System;
using System.Collections.Generic;

// To execute C#, please define "static void Main" on a class
// named Solution.


class BinaryTreeNode {

    public int value;
    public BinaryTreeNode left;
    public BinaryTreeNode right;

    public BinaryTreeNode(int value) {
        this.value = value;
        this.left = null;
        this.right = null;
    }

    public BinaryTreeNode insertLeft(int leftValue) {
        this.left = new BinaryTreeNode(leftValue);
        return this.left;
    }

    public BinaryTreeNode insertRight(int rightValue) {
        this.right = new BinaryTreeNode(rightValue);
        return this.right;
    }
    
}

class Solution
{
    public bool isBalanced( BinaryTreeNode treeNode, int curDepth, List<int> depths )
    {
        //    Determine if balanced
        bool balanced = true;
        
        //Console.WriteLine("Value {0} : Depth {1} | ", treeNode.value , curDepth);

        
        //    If there is no left or right this is a leaf 
        if( treeNode.left == null && treeNode.right == null )
        {
            //Console.WriteLine("\tEnd of the line leaf at depth {0}", curDepth);
            
            //    Check to see if the current depth is contained if not add it
            if( !depths.Contains( curDepth ) )
            {
                depths.Add(curDepth);
                
                //    First condition :: the number of depths is greater than 2, then we have two leafs whos diff is greater than 1
                if( depths.Count > 2 )
                {
                    return false;
                }
                //    Second scenarios is there are two depths and their  difference is great than 1
                else if( depths.Count > 1 )
                {
                    if( Math.Abs( depths[0] - depths[1] ) > 1 )
                    {
                        return false;
                    }
                }        
            }
            
        }
        //    otherwise there are more nodes to go
        else
        {
            if( treeNode.left != null )
            {
                
                //Console.WriteLine("\tNode {0} Going Left", treeNode.value);
                balanced = isBalanced( treeNode.left, curDepth + 1, depths );
                if ( !balanced )
                {
                    return false;
                }
            }
            
            if( treeNode.right != null )
            {
                
                //Console.WriteLine("\tNode {0} Going Right", treeNode.value);
                balanced = isBalanced( treeNode.right, curDepth + 1, depths );
                if ( !balanced )
                {
                    return false;
                }
            }
            
        }        
        return balanced;
    }
    
    static void Main(string[] args)
    {
        //    Mkae the first node the reference to the tree
        BinaryTreeNode myTreeRoot = new BinaryTreeNode(1);
        
        myTreeRoot.insertLeft(2);
        myTreeRoot.insertRight(3);
        
        myTreeRoot.left.insertLeft(4);
        
        myTreeRoot.right.insertLeft(5);
        myTreeRoot.right.insertRight(6);
        
        //myTreeRoot.right.right.insertRight(7);
        
        myTreeRoot.left.left.insertLeft(8);
        myTreeRoot.left.left.left.insertLeft(9);
        
        //    Used ot store depths explored
        List<int> depths = new List<int>();
        
        Solution mySolution = new Solution();
        bool answer = mySolution.isBalanced( myTreeRoot , 0 , depths);
        
        Console.WriteLine("Is balanced: {0}", answer );
    }
}
