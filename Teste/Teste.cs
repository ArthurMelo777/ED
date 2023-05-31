using System;

class StackEmpty : Exception {

}

class Node {
    private object element;
    private Node next, prev;

    public Node (object e, Node p, Node n) {
        element = e;
        next = n;
        prev = p;
    }

    public void setElement (object e) {
        element = e;
    }

    public object getElement () {
        return element;
    }

    public void setPrev (Node p) {
        prev = p;
    }

    public Node getPrev () {
        return prev;
    }

    public void setNext (Node n) {
        next = n;
    }

    public Node getNext () {
        return next;
    }
}

class Stack {
    private Node head, tail;
    private int countSize = 0, t = -1;

    public Stack () {
        head = new Node (null, null, tail);
        tail = new Node (null, head, null);
    }

    public int size () {
        return countSize;
    }

    public bool isEmpty () {
        if (countSize==0) {
            return true;
        }
        return false;
    }

    public void push (object o) {
        Node n = new Node(o, tail.getPrev(), tail);
        tail.getPrev().setNext(n);
        tail.setPrev(n);
        countSize++;
    }

    public object pop () {
        if (isEmpty()) {
            throw new StackEmpty();
        }
        Node n = tail.getPrev();
        tail.getPrev().getPrev().setNext(tail);
        tail.setPrev(tail.getPrev().getPrev());
        n.setNext(null);
        n.setPrev(null);
        countSize--;
        return n.getElement();
    }

    public object top () {
        return tail.getPrev().getElement();
    }
}

class Program {
    public static void Main () {
        Stack s = new Stack();

        Console.WriteLine(s.size());
        Console.WriteLine(s.isEmpty());
        s.push(1);
        s.push(2);
        s.push(3);
        Console.WriteLine(s.size());
        Console.WriteLine(s.isEmpty());
        Console.WriteLine(s.pop());
        Console.WriteLine(s.size());
        Console.WriteLine(s.isEmpty());
    }
}