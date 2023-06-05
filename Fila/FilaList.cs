class QueueEmpty : Exception {

}

class Node {
    private object element;
    private Node next, prev;

    public Node (object e, Node p, Node n) {
        element = e;
        next = n;
        prev = p;
    }

    public void setElement (object e) { element = e; }

    public object getElement () { return element; }

    public void setPrev (Node p) { prev = p; }

    public Node getPrev () { return prev; }

    public void setNext (Node n) { next = n; }

    public Node getNext () { return next; }
}

class LinkedList {
    private Node head, tail;
    public LinkedList () {
        head = new Node (null, null, tail);
        tail = new Node (null, head, null);
    }

    public void setHead (Node h) {
        head = h;
    }

    public Node getHead () {
        return head;
    }

    public void setTail (Node t) {
        tail = t;
    }

    public Node getTail() {
        return tail;
    }
}

class Queue {
    private LinkedList queue = new LinkedList();
    private int countSize = 0;
    public int size () {
        return countSize;
    }

    public bool isEmpty () {
        if (countSize == 0) {
            return true;
        }
        return false;
    }

    public void enqueue (object o) {
        Node n = new Node(o, queue.getTail().getPrev(), queue.getTail());
        queue.getTail().getPrev().setNext(n);
        queue.getTail().setPrev(n);
        countSize++;
    }

    public object dequeue () {
        Node n = queue.getHead().getNext();
        queue.getHead().setNext(n.getNext());
        n.getNext().setPrev(queue.getHead());
        n.setNext(null);
        n.setPrev(null);
        countSize--;

        return n.getElement();
    }
    
    public object first () {
        return queue.getHead().getNext().getElement();
    }
}

class Program {
    public static void Main () {
        Queue q = new Queue();
        Console.WriteLine(q.size());
        Console.WriteLine(q.isEmpty());
        q.enqueue(1);
        q.enqueue(2);
        q.enqueue(3);
        Console.WriteLine(q.size());
        Console.WriteLine(q.isEmpty());
        Console.WriteLine(q.dequeue());
        Console.WriteLine(q.size());
        Console.WriteLine(q.isEmpty());
    }
}