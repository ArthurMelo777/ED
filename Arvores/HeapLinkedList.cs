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
    private Node root, ultimo;
    private int qtd = 0;
    private Comparator comp = new Comparator();

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

    public void upHeap (Item i) { // compara filho com o pai
        
    }

    public void insert (Item i);

    public object removeMin ();

    public void print ();
}

class PriorityQueue {

}