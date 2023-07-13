using System;

// Min Heap

class Node {
    private Node parent;
    private Node leftChild, rightChild;
    private object key;
    private object value;

    public Node (Node p, object k, object v) {
        parent = p;
        leftChild = null;
        rightChild = null;
        key = k;
        value = v;
    }

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

    public int countChilds () {
        if (leftChild == null && rightChild == null) {
            return 0;
        }
        if ((leftChild != null && rightChild == null)
        ||
        (leftChild == null && rightChild != null)) {
            return 1;
        }
        return 2;
    }
}

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
    private Node root, tail;
    private Comparator comp = new Comparator();

    public Heap (Item i) {
        Node newNode = new Node (null, i.getKey(), i.getValue());
        root = newNode;
    }

    public Node getRoot () {
        return root;
    }

    public void swap (Node n, Node p) {
        Node aux = n;
        n.setValue(p.getValue());
        n.setKey(p.getKey());
        p.setValue(aux.getValue());
        p.setKey(aux.getKey());
    }

    public void downHeap (Node n) { // compara pai com filhos
        // no folha
        if (n.countChilds() == 0) {
            return;
        }

        // precisa de swap?
        if ((comp.compare(n.getKey(), n.getLeftChild().getKey()) == 1)
        ||
        (comp.compare(n.getKey(), n.getRightChild().getKey()) == 1)) {
            if (comp.compare(n.getLeftChild().getKey(), n.getRightChild().getKey()) == -1) {
                swap(n, n.getLeftChild());
                downHeap(n.getLeftChild());
            }
            else {
                swap(n, n.getRightChild());
                downHeap(n.getRightChild());
            }
        }
    }

    public void upHeap (Node n) { // compara filho com o pai
        while (n != root) {
            if (comp.compare(n.getKey(), n.getParent().getKey()) == -1) {
                swap(n, n.getParent());
            }
            n = n.getParent();
        }
    }

    public void insert (Item i) {
        tail = findAndInsert(root, i);
        upHeap(tail);
    }

    public Item remove () {
        Item removed = new Item (root.getKey(), root.getValue());
        swap(tail, root);
        if (tail.getParent().getRightChild() == null) {
            tail.getParent().setLeftChild(null);
        }
        else {
            tail.getParent().setRightChild(null);
        }
        downHeap(root);
        return removed;
    }

    public Node findAndInsert (Node r, Item i) {
        Node newNode;

        // so a raiz
        if (r.getLeftChild() == null) {
            newNode = new Node(r, i.getKey(), i.getValue());
            r.setLeftChild(newNode);
            return newNode;
        }

        // sem filho direito
        else if (tail.getParent().getRightChild() == null) {
            newNode = new Node(tail.getParent(), i.getKey(), i.getValue());
            tail.getParent().setRightChild(newNode);
            return newNode;
        }

        // capacidade == tamanho
        else if (capacity(r) == size(r)) {
            Node n = r;
            while (n.getLeftChild() != null) {
                n = n.getLeftChild();
            }
            newNode = new Node(n, i.getKey(), i.getValue());
            n.setLeftChild(newNode);
            return newNode;
        }

        // ultimo caso = todos os anteriores falham
        else {
            return findAndInsert(r.getRightChild(), i);
        }
    }

    public int size (Node r) {
        if (r.getLeftChild() != null) {
            return 1+size(r.getLeftChild());
        }
        if (r.getRightChild() != null) {
            return 1+size(r.getRightChild());
        }
        return 0;
    }

    public int capacity (Node r) {
        int h = height(r);
        int count = 0;
        for (int i = 0; i < h; i++) {
            count += (int) Math.Pow(2, i);
        }

        return count;
    }

    public int height (Node node) { // "feito"
        if (node.countChilds() == 0) {
            return 0;
        }
        else {
            int h = 0;
            int children_height;
            if (node.getLeftChild() != null) {
                children_height = height(node.getLeftChild());
                h = Math.Max(h, children_height);
            }
            if (node.getRightChild() != null) {
                children_height = height(node.getRightChild());
                h = Math.Max(h, children_height);
            }
            return h+1;
        }
    }

    public Item min () {
        Item minItem = new Item (root.getKey(), root.getValue());
        return minItem;
    }

    public void print (Node node) { // "feito"
        if (node != null) {
            if (node.countChilds() != 0) {
                Console.WriteLine(
                $"{node.getKey()} eh pai de{node.getLeftChild().getKey()} e {node.getRightChild().getKey()} "
                );
            }
            else {
                Console.WriteLine($"{node.getKey()} nao tem filhos ");
            }
            print(node.getLeftChild());
            print(node.getRightChild());
        }
    }
}

class PriorityQueue {
    Heap heap;
    int qtd;

    public PriorityQueue (Item i) {
        heap = new Heap(i);
        qtd = 1;
    }

    public void insert (Item i) {
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

    public bool isEmpty () {
        if (qtd == 0) {
            return true;
        }
        return false;
    }
}

class Program {
    public static void Main () {
        Item i = new Item(0, 0);
        Heap h = new Heap(i);
        i = new Item(1, 1);
        h.insert(i);
        i = new Item(2, 2);
        h.insert(i);
        i = new Item(3, 3);
        h.insert(i);
        i = new Item(4, 4);
        h.insert(i);
        i = new Item(9, 9);
        h.insert(i);
        i = new Item(10, 10);
        h.insert(i);
        i = new Item(5, 5);
        h.insert(i);
        i = new Item(6, 6);
        h.insert(i);
        i = new Item(7, 7);
        h.insert(i);
        i = new Item(8, 8);
        h.insert(i);
        h.remove();

        h.print(h.getRoot());
    }
}