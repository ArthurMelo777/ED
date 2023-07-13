using System;

class Item {
    object value;
    object key;

    public Item (object k, object v) {
        key = k;
        value = v;
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

class Comparator {
    public int compare (object k1, object k2) {
        if ((int) k1 < (int) k2) {
            return -1;
        }
        else if ((int) k1 > (int) k2) {
            return 1;
        }
        return 0;
    }
}

class Heap {
    private Item[] heap;
    private int size;
    private Comparator comp = new Comparator();

    public Heap (int s) {
        heap = new Item[s+1];
        size = 0;
    }

    private int parent (int p) {
        return p/2;
    }

    private int leftChild (int p) {
        return 2*p;
    }

    private int rightChild (int p) {
        return 2*p+1;
    }

    private void swap (int p1, int p2) {
        Item t = heap[p1];
        heap[p1] = heap[p2];
        heap[p2] = t;
    }

    private void downHeap (int p) {
        // no folha?
        if (p >= (size/2) && p <= size) {
            return;
        }

        // precisa de swap?
        if ((comp.compare(heap[p].getKey(), heap[leftChild(p)].getKey()) == 1)
        ||
            comp.compare(heap[p].getKey(), heap[rightChild(p)].getKey()) == 1) {
                if (comp.compare(heap[leftChild(p)].getKey(), heap[rightChild(p)].getKey()) == -1) {
                    swap(p, leftChild(p));
                    downHeap(leftChild(p));
                }
                else {
                    swap(p, rightChild(p));
                    downHeap(rightChild(p));
                }
            }
    }

    private void upHeap (int p) {
        Item t = heap[p];
        while ( (p>0)
                &&
                (comp.compare(t.getKey(), heap[parent(p)].getKey()) == -1)) {
                    heap[p] = heap[parent(p)];
                    p = parent(p);
        }
        heap[p] = t;
    }

    public void insert (Item i) {
        heap[++size] = i;
        int current = size;
        upHeap(current);
    }

    public Item remove () {
        Item removed = heap[1];
        heap[1] = heap[size--];
        downHeap(1);
        return removed;
    }

    public Item min () {
        return heap[1];
    }

    public void print () {
        for (int i = 1; i <= size/2; i++) {
            Console.WriteLine
            (
            $"{heap[i]} eh pai de{heap[leftChild(i)]} e {heap[rightChild(i)]}"
            );
        }
    }
}

class PriorityQueue {
    Heap heap = new Heap(50);
    int qtd;

    public PriorityQueue(Item i) {
        heap.insert(i);
        qtd = 1;
    }

    public void insert (object k, object v) {
        Item i = new Item(k, v);
        heap.insert(i);
        qtd++;
    }

    public Item removeMin () {
        qtd--;
        return heap.remove();
    }

    public Item min () {
        return heap.min();
    }

    public int size () {
        return qtd;
    }

    public bool isEmpty() {
        if (qtd == 0) {
            return true;
        }
        return false;
    }

    public void print () {
        heap.print();
    }
}

class Program {
    public static void Main () {
        Item i;
        i = new Item(5, 5);
        PriorityQueue pq = new PriorityQueue(i);
        pq.print();
        pq.insert(9, 9);
        pq.insert(15, 15);
        pq.insert(20, 20);
        pq.insert(0, 0);
        Console.WriteLine(pq.removeMin());
    }
}