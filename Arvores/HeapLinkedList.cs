using System;

class Node {
    private Node parent;
    private Node leftChild, rightChild;
    private object key;
    private object value;
}

class Heap {
    public Node insert (object n, object key);
    public void upHeap ();
    public object remove (Node n);
    public void downHeap ();
}

class PriorityQueue {

}