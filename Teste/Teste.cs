using System;
using System.Collections;

class NodeNotFound : Exception {

}

class Node {
    private Node parent; // pai
    private Node leftChild; // filho esquerdo
    private Node rightChild; // filho direito
    private object key; // chave

    public Node (Node p, object k) {
        parent = p;
        leftChild = null;
        rightChild = null;
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

    public void setKey (object k) {
        key = k;
    }

    public object getKey () {
        return key;
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

    public bool leftOrRight () {
        return (leftChild == null); // se true, left é vazio, se false, right é vazio
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

class BinarySearchTree {
    // atributos
    private Node root;
    private ArrayList els;
    private ArrayList nds;
    private int countSize;
    private Comparator comp;
    private object[,] matriz;
    int x, y;

    //metodos
    public BinarySearchTree (object kr) {
        root = new Node (null, kr);
        countSize = 0;
    }

    public void setComp (Comparator c) {
        comp = c;
    }

    public Comparator getComp () {
        return comp;
    }

    public void setRoot (Node p) {
        root = p;
    }

    public Node getRoot () {
        return root;
    }

    public bool isExternal (Node v) {
        if (v == null) {
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
    
    public Node search (Node node, object key) { // "feito"
        if (isExternal(node)) {
            return node;
        }
        if (comp.compare(key, node.getKey()) == -1) {
            return search(node.getLeftChild(), key);
        }
        else if (comp.compare(key, node.getKey()) == 0) {
            return node;
        }
        else {
            return search(node.getRightChild(), key);
        }
    }

    public Node include (object key) { // "feito"
        Node node = search(root, key).getParent();
        Node n = null;

        Console.WriteLine(node);

        if (comp.compare(key, node.getKey()) == -1) {
            n = new Node(node, key);
            node.setLeftChild(n);
        }

        else if (comp.compare(key, node.getKey()) == 1) {
            n = new Node(node, key);
            node.setRightChild(n);
        }

        return n;
    }

    public object remove (object key) { // "feito"
        int c;
        Node node = search(root, key);
        // no nao existente
        if (isExternal(node)) {
            throw new NodeNotFound();
        }

        // no folha
        if (node.countChilds() == 0) {
            c = comp.compare(node.getKey(), node.getParent().getKey());

            if (c == -1) {
                node.getParent().setLeftChild(null);
            }
            else if (c == 1) {
                node.getParent().setRightChild(null);
            }

            return node.getKey();
        }

        // no com um filho
        if (node.countChilds() == 1) {
            bool lor = node.leftOrRight();
            c = comp.compare(node.getKey(), node.getParent().getKey());

            if (lor) { // se left child for vazio
                if (c == -1) { // e node removido for o node esquerdo
                    node.getParent().setLeftChild(node.getRightChild()); // insira o filho direito do node removido no filho esquerdo do pai do node removido
                }
                else if (c == 1) { // e node removido for o node direito
                    node.getParent().setRightChild(node.getRightChild()); // insira o filho direito do node removido no filho direito do pai do node removido
                }
            }
            else { // se right child for vazio
                if (c == -1) { // e node removido for o node esquerdo
                    node.getParent().setLeftChild(node.getLeftChild()); // insira o filho direito do node removido no filho esquerdo do pai do node removido
                }
                else if (c == 1) { // e node removido for o node direito
                    node.getParent().setRightChild(node.getLeftChild()); // insira o filho direito do node removido no filho direito do pai do node removido
                }
            }

            return node.getKey();

        }

        // no com dois filhos
        if (node.countChilds() == 2) {
            Node suc = sucessor(node, node.getRightChild()); // node a ser removido, node pai do node a ser comparado

            suc.getParent().setLeftChild(suc.getLeftChild());
            node.setKey(suc.getKey());

            return node.getKey();
        }

        return null;
    }

    private Node sucessor (Node node, Node parent) { // "feito"
        // se o filho esquerdo do filho direito for maior que o seu pai && o filho esquerdo do filho direito for menor que o no a ser removido
        if ((comp.compare(parent.getLeftChild().getKey(), parent.getKey()) == -1) && comp.compare(parent.getLeftChild().getKey(), node.getKey()) == 1) {
            return parent.getLeftChild();
        }
        return sucessor(node, parent.getLeftChild());
    }

    public int height (Node node) { // "feito"
        if (isExternal(node)) {
            return 0;
        }
        else {
            int lft = height(node.getLeftChild());
            int rgt = height(node.getRightChild());
            return Math.Max(lft, rgt);
        }
    } 

    public int depth (Node node) { // "feito"
        if (node == root) {
            return 0;
        }
        return 1 + depth(node.getParent());
    }

    public int size () { // "feito"
        return countSize;
    } 

    public bool isEmpty () {  // "feito"
        if (root == null) {
            return true;
        }
        return false;
    }
    
    public void inOrder (Node node) { // "feito"
        if (isInternal(node)) {
            inOrder(node.getLeftChild());
        }
        Console.WriteLine(node.getKey());
        if (isInternal(node)) {
            inOrder(node.getRightChild());
        }
    } 

    public void preOrder (Node node) { // "feito"
        Console.WriteLine(node.getKey());
        if (node.getLeftChild() != null) {
            preOrder(node.getLeftChild());
        }
        if (node.getRightChild() != null) {
            preOrder(node.getRightChild());
        }
    } 

    public void postOrder (Node node) { // "feito"
        if (node.getLeftChild() != null) {
            postOrder(node.getLeftChild());
        }
        if (node.getRightChild() != null) {
            postOrder(node.getRightChild());
        }
        Console.WriteLine(node.getKey());
    }

    public IEnumerator nodes () { // "feito"
        nds = new ArrayList();
        orderNodes(root);
        return nds.GetEnumerator();
    }

    private void orderNodes (Node node) { // "feito"
        nds.Add(node);
        if (node.getLeftChild() != null) {
            orderNodes(node.getLeftChild());
        }
        if (node.getRightChild() != null) {
            orderNodes(node.getRightChild());
        }
    }

    public IEnumerator elements () { // "feito"
        els = new ArrayList();
        orderElements(root);
        return els.GetEnumerator();
    }

    private void orderElements (Node node) { // "feito"
        els.Add(node.getKey());
        if (node.getLeftChild() != null) {
            orderElements(node.getLeftChild());
        }
        if (node.getRightChild() != null) {
            orderElements(node.getRightChild());
        }
    }

    public void print () { // "a fazer"
        x = totalX(root);
        y = height(root)+1;
        Console.WriteLine($"{x}, {y}");
        matriz = new object[x, y];
        Console.WriteLine(matriz);
        Node n;

        var enumerator = nodes();

        for (int i = 0; i < x; i++) {
            for (int j = 0; j < y; j++) {
                matriz[i,j] = null;
            }
        }

        while (enumerator.MoveNext()) {
            n = (Node) enumerator.Current;
            Console.WriteLine($"{n.getKey()} = {foundX(n)+1}, {foundY(n)}");
            matriz[foundX(n)-1, foundY(n)] = n.getKey();
        }

        for (int i = 0; i < x; i++) {
            for (int j = 0; j < y; j++) {
                Console.WriteLine(matriz[i, j]);
            }
        }
    }

    public int totalX (Node node) {
        if (isInternal(node)) {
            return 1+totalX(node.getLeftChild());
        }
        if (isExternal(node)) {
            return 0;
        }
        if (isInternal(node)) {
            return 1+totalX(node.getRightChild());
        }
        return 0;
    }

    private int foundX (Node node) {
        return totalX(node);
    }

    private int foundY (Node node) {
        return height(node);
    }
}

class Program {
    public static void Main () {
        BinarySearchTree bst = new BinarySearchTree(5);
        Comparator c = new Comparator();
        Node n;

        // set comparator
        bst.setComp(c);

        // root
        Console.WriteLine(bst.getRoot().getKey());
        n = new Node(null, 6);
        bst.setRoot(n);
        Console.WriteLine(bst.getRoot().getKey());

        // externo e interno
        Console.WriteLine(bst.isInternal(bst.getRoot()));
        Console.WriteLine(bst.isExternal(bst.getRoot()));

        // search
        Console.WriteLine(bst.search(bst.getRoot(), bst.getRoot().getKey()));
        bst.print();

        // include ERRO

        // remove ERRO

        // height
        Console.WriteLine(bst.height(bst.getRoot()));

        // depth
        Console.WriteLine(bst.depth(bst.getRoot()));

        // size
        Console.WriteLine(bst.size());

        // isEmpty

        // inOrder
        bst.inOrder(bst.getRoot());

        // preOrder
        bst.preOrder(bst.getRoot());

        // postOrder
        bst.postOrder(bst.getRoot());

        // nodes

        // elements

        // print
    }
}