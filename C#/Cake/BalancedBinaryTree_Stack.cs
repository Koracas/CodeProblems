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
    class NodeDepthPair
    {
        public BinaryTreeNode node;
        public int depth;
        
        public NodeDepthPair( BinaryTreeNode node, int depth ) 
        {
            this.node = node;
            this.depth = depth;
        }
        
    }
    
    
    public bool isBalanced( BinaryTreeNode treeRoot )
    {
        bool balanced = true;
        
        //    Start a stack
        Stack< NodeDepthPair > treeStack = new Stack<NodeDepthPair>();
          
        NodeDepthPair rootNodePair = new NodeDepthPair( treeRoot , 0 );
        
        //    Push in the root
        treeStack.Push(rootNodePair);
        
        //    Declare depth holder
        List< int > numDepths = new List<int> ();
        
        while( treeStack.Count > 0 )
        {
            NodeDepthPair curNodePair = treeStack.Pop();
            
            Console.WriteLine("Looking at node {0}" , curNodePair.node.value);
            
            
            //    Check if this is a leaf node
            if( curNodePair.node.left == null && curNodePair.node.right == null )
            {
                Console.WriteLine("\tIs leaf Node at depth {0}" , curNodePair.depth);
                
                //    Depth is currently not represented 
                if ( !numDepths.Contains( curNodePair.depth ) )
                {
                    numDepths.Add( curNodePair.depth );
                    
                    //    Conidtions for having depths that have diff greater than 1
                    //    Number of depths is greater than 2, then we probably 
                    if( numDepths.Count > 2 )
                    {
                        return false;
                    }
                    //    There are 2 depths and their diff is greater than 1  
                    if( numDepths.Count == 2 ) 
                    {
                        if ( Math.Abs( numDepths[0] - numDepths[1] ) > 1 )
                        {
                            return false;
                        }
                    }
                }
            }
            //    This node has children
            else 
            {
                //    If there is a left node
                if( curNodePair.node.left != null )
                {
                    //    put that on the stack
                    treeStack.Push( new NodeDepthPair( curNodePair.node.left , curNodePair.depth + 1));
                }
                //    If there is a left node
                if( curNodePair.node.right != null )
                {
                    //    put that on the stack
                    treeStack.Push( new NodeDepthPair( curNodePair.node.right , curNodePair.depth + 1));
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
        
        myTreeRoot.right.right.insertRight(7);
        
        myTreeRoot.left.left.insertLeft(8);
        myTreeRoot.left.left.left.insertLeft(9);
        
       
        Solution mySolution = new Solution();
        bool answer = mySolution.isBalanced( myTreeRoot );
        
        Console.WriteLine("Is balanced: {0}", answer );
    }
}
