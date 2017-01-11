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
        
        Solution mySolution = new Solution();
        
        
    }
}
