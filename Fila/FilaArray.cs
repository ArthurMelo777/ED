class QueueEmpty : Exception {

}

class Queue {
    private object[] queue = new object[1];
    private int i = 0, f = 0, n = 1;

    public void doub () {
        n *= 2; 
        object[] new_queue = new object[n];

        for (int j = 0; j < size(); j++) {
            new_queue[j] = queue[j];
        }

        queue = new_queue;
    }

    public int size () {
        return (n-(i+f)) % n;
    }

    public bool isEmpty () {
        if (i == f) {
            return true;
        }
        return false;
    }

    public void enqueue (object o) {
        if (size() == n) {
            doub();
        }
        queue[f] = o;
        f = (f+1) % n;
    }

    public object dequeue () {
        if (isEmpty()) {
            throw new QueueEmpty();
        }
        object o = queue[i];
        i = (i+1)%n;

        return o;
    }

    public object first () {
        if (isEmpty()) {
            throw new QueueEmpty();
        }
        return queue[i];
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