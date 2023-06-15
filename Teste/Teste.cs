using System;
using System.Collections;


class Node {
    private Node parent; // pai
    private Node leftChild; // filho esquerdo
    private Node rightChild; // filho direito
    private int key; // chave

    public Node (Node p, Node l, Node r, int k) {
        parent = p;
        leftChild = l;
        rightChild = r;
        key = k;
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

    public void setKey (int k) {
        key = k;
    }

    public int getKey () {
        return key;
    }
}

class BinarySearchTree {
    // atributos
    private Node root;
    private ArrayList els;
    private ArrayList nds;
    private int countSize;

    //metodos
    public BinarySearchTree (int kr) {
        root = new Node (null, null, null, kr);
        countSize = 0;
    }

    public void setRoot (Node p) {
        root = p;
    }

    public Node getRoot () {
        return root;
    }

    public int compare (int k1, int k2) {
        if (k1 < k2) {
            return k1;
        }
        else {
            return k2;
        }
    }

    public bool isExternal (Node v) {
        if (v.getLeftChild() == null && v.getRightChild() == null) {
            return true;
        }
        return false;
    }

    public bool isInternal (Node v) {
        if (isExternal(v)) {
            return false;
        }
        return true;
    }
    public Node search (Node node, int key) { // "feito"
        if (isExternal(node)) {
            return node;
        }
        if (key < node.getKey()) {
            return search(node.getLeftChild(), key);
        }
        else if (key == node.getKey()) {
            return node;
        }
        else {
            return search(node.getRightChild(), key);
        }
    }

    public Node include (int key) { // "feito"
        return include_rec(root, key);
    }

    public Node include_rec (Node node, int key) { // "feito"
        if (isExternal(node)) {
            node = node.getParent();
            Node n;
            if (key < node.getKey()) {
                n = new Node (node, null, null, key);
                node.setLeftChild(n);
            }
            else {
                n = new Node (node, null, null, key);
                node.setRightChild(n);
            }

            return n;
        }

        if (key < node.getKey()) {
            return include_rec(node.getLeftChild(), key);
        }

        else if (key == node.getKey()) {
            return node;
        }

        else {
            return include_rec(node.getRightChild(), key);
        }
    }

    public int remove (int key) { // "a fazer"
        Node node = search(root, key);

    }

    public void inOrder (Node node) {} // "a fazer"

    public void preOrder (Node node) {} // "a fazer"

    public void postOrder (Node node) {} // "a fazer"

    public int height (Node node) {} // "a fazer"

    public int depth (Node node) {} // "a fazer"

    public void print () {} // "a fazer"

    public IEnumerator nodes () {} // "a fazer"

    public IEnumerator elements () {} // "a fazer"

    public int size () {} // "a fazer"

    public bool isEmpty () {} // "a fazer"
    
}