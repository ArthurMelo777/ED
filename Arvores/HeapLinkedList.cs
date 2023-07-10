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
        qtd = 1;
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
        if (n.countChilds == 0) {
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
        findAndInsert(root, i);
    }

    public void findAndInsert (Node r, Item i) {
        Node newNode;

        // so a raiz
        if (r.getLeftChild() == null) {
            newNode = new Node(r, i.getKey(), i.getValue());
            r.setLeftChild(newNode);
        }

        // sem filho direito
        else if (tail.getParent().getRightChild() == null) {
            newNode = new Node(tail.getParent(), i.getKey(), i.getValue());
            tail.getParent().setRightChild(newNode);
        }

        // capacidade == tamanho
        else if (capacity(r) == size(r)) {
            Node n = r;
            while (n.getLeftChild() != null) {
                n = n.getLeftChild();
            }
            newNode = new Node(n, i.getKey(), i.getValue());
            n.setLeftChild(newNode);
        }

        // ultimo caso = todos os anteriores falham
        else {
            findAndInsert(r.getRightChild(), i);
        }
    }

    public int size (Node r) {
        if (r.getLeftChild() != null) {
            return 1+size(r.getLeftChild());
        }
        return 0;
        if (r.getRightChild() != null) {
            return 1+size(r.getRightChild());
        }
    }

    public int capacity (Node r) {
        int h = height(r);
        int count = 0;
        for (int i = 0; i < h; i++) {
            count += Math.Pow(2, i);
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

    public object removeMin ();

    public void print ();
}

class PriorityQueue {

}