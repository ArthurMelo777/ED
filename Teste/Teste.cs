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
        if ((leftChild != null && rightChild == null) || (leftChild == null && rightChild != null)) {
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
    private int qtd;
    private Comparator comp = new Comparator();

    public Heap (Item i) {
        Node newNode = new Node (null, i.getKey(), i.getValue());
        root = newNode;
        tail = newNode;
        qtd = 1;
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
        if ((comp.compare(n.getKey(), n.getLeftChild().getKey()) == 1) ||
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
        
    }

    public void insert (Item i) {
        tail = findAndInsert(root, i);
    }

    public Node findAndInsert (Node r, Item i) {
        Node newNode;

        // so a raiz
        if (r.getLeftChild() == null) {
            newNode = new Node(r, i.getKey(), i.getValue());
            r.setLeftChild(newNode);
            //Console.WriteLine($"caso 1 = {tail.getKey()}");
            return newNode;
        }

        // sem filho direito
        else if (tail.getParent().getRightChild() == null) {
            newNode = new Node(tail.getParent(), i.getKey(), i.getValue());
            tail.getParent().setRightChild(newNode);
            //Console.WriteLine($"caso 2 = {tail.getKey()}");
            return newNode;
        }

        // ultima linha completa?
        else if (capacity(root) == size(root)) {
            //Console.WriteLine($"T = {size(r)}, C = {capacity(r)}");
            Node n = root;
            while (n.getLeftChild() != null) {
                n = n.getLeftChild();
            }
            newNode = new Node(n, i.getKey(), i.getValue());
            //Console.WriteLine(newNode.getKey());
            n.setLeftChild(newNode);
            //Console.WriteLine($"caso 3 = {tail.getKey()}");
            return newNode;
        }

        // ultimo caso = todos os anteriores falham
        else {
            //Console.WriteLine($"caso 4 = {tail.getKey()}");
            return findAndInsert(r.getRightChild(), i);
        }
    }

    public int size (Node r) {
        if (r.getLeftChild() != null) {
            return 1+size(r.getLeftChild());
        }
        if (r.countChilds() == 0) {
            return 0;
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
        int count = 0;

        while (node != null) {
            node = node.getLeftChild();
            count++;
        }

        return count;
    }

    public void print (Node node) { // "feito"
        if (node != null) {
            if (node.countChilds() != 0) {
                Console.WriteLine($"{node.getKey()} eh pai de {node.getLeftChild().getKey()} e {node.getRightChild().getKey()} ");
            }
            else {
                Console.WriteLine($"{node.getKey()} nao tem filhos ");
            }
            print(node.getLeftChild());
            print(node.getRightChild());
        }
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
        i = new Item(5, 5);
        h.insert(i);
        i = new Item(6, 6);
        h.insert(i);
        i = new Item(7, 7);
        h.insert(i);
        i = new Item(8, 8);
        h.insert(i);
        i = new Item(9, 9);
        h.insert(i);
        i = new Item(10, 10);
        h.insert(i);
        i = new Item(11, 11);
        h.insert(i);
        i = new Item(12, 12);
        h.insert(i);

        //h.print(h.getRoot());
    }
}