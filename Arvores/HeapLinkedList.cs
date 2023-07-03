using System;

class Node {
    private Node parent;
    private Node leftChild, rightChild;
    private object key;
    private object value;

    public void setParent (Node p) {
        parent = p;
    }

    public Node getParent () {
        return parent;
    }

    public void setLeftChild (Node l) {
        leftChild = l;
    }

    public Node getLeftChild () {
        return leftChild;
    }

    public void setRightChild (Node r) {
        rightChild = r;
    }

    public Node getRightChild () {
        return rightChild;
    }

    public void setKey (object k) {
        key = k;
    }

    public object getKey () {
        return key;
    }

    public void setValue (object v) {
        value = v;
    }

    public object getValue () {
        return value;
    }

}

class Heap {
    private Node root;
    private int qtd;

    public Heap (Node r) {
        root = r;
        qtd = 1;
    }

    public void swap (Node n, Node p);

    public void downHeapify (Node n);

    public void heapifyUp (Node n);

    public void insert (object value, object key);

    public object remove (object key);

    public void print ();
}

class PriorityQueue {

}