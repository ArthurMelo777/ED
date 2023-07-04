using System;

// Min Heap

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

class Item {
    // object value, key;
}

class Heap {
    private Node root, ultimo;
    private int qtd = 0;

    public void swap (Node n, Node p);

    public void downHeapify (Node n);

    public void heapifyUp (Node n);

    public void insert (Item i);

    public object removeMin ();

    public void print ();
}

class PriorityQueue {

}